using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using Negocio;
using System.Transactions;

namespace Presentacion
{
    public partial class AlmacenUsuario : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Almacen = new DataTable();

        DataTable tblUsuario = new DataTable();
        BindingSource src = new BindingSource();

        public AlmacenUsuario()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("codigo");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("default");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_Almacen.Columns.Add("id_Almacen");
            tabla_Almacen.Columns.Add("codigo_Almacen");
            tabla_Almacen.Columns.Add("nombre_Almacen");
        }


        private void AlmacenUsuario_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarAlmacen(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaAlmacen);
            Clases.Reglas.alternarColor(dgvListaAlmacenAcc);
            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarAlmacen(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGAlmacen obj = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.GridAlmacen(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblUsuario.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Almacen.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Almacen"] = row1[0].ToString();
                row["codigo_Almacen"] = row1[1].ToString();
                row["nombre_Almacen"] = row1[2].ToString();
                tabla_Almacen.Rows.Add(row);
            }
            dgvListaAlmacen.DataSource = tabla_Almacen;
        }

        public void ListarAlmacenAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblAlmacenAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGAlmacen obj = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblAlmacenAcc = obj.AlmacenAccesoUsu(idUsuario, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblAlmacenAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["codigo"] = row1[1].ToString();
                    row["nombre"] = row1[2].ToString();
                    row["default"] = row1[3].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaAlmacenAcc.DataSource = tabla;
            }
        }

        public void ListarComboUsuario(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.ComboUsuario(idEmpresa, ref blnTodoOK);

            cbxUsuario.DataSource = tblUsuario;
            cbxUsuario.DisplayMember = "nombre";
            cbxUsuario.ValueMember = "id";
            //src.DataSource = tblUsuario;
            //dgvLista.DataSource = src;


        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdAlmacen = Convert.ToInt32(dgvListaAlmacen.CurrentRow.Cells["id_Almacen"].Value);
            string strCoAlmacen = dgvListaAlmacen.CurrentRow.Cells["codigo_Almacen"].Value.ToString();
            string strNoAlmacen = dgvListaAlmacen.CurrentRow.Cells["nombre_Almacen"].Value.ToString();

            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdAlmacen == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("El Almacen ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdAlmacen, strCoAlmacen, strNoAlmacen, 0 });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaAlmacenAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaAlmacenAcc.Rows.Count > 0)
            {
                int index = dgvListaAlmacenAcc.CurrentRow.Index;
                dgvListaAlmacenAcc.Rows.RemoveAt(index);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if(tabla.Rows.Count == 0){

            //} 
            Insertar();
        }

        public void Insertar()
        {
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    bool blnTodoOK = false;
                    Clases.InicialCls.LeerXml();

                    NGUsuario objNgAlm = new NGUsuario(Configuracion.Sistema.CadenaConexion);
                    int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                    objNgAlm.InsertarAlmacenUsuario(idUsuario, tabla, idEmpresa, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Almacenes agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cbxUsuario.SelectedValue = 0;
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
            txtIdAlm.Text = valor.ToString();
            tabla.Clear();
            ListarAlmacenAcc();
        }

        private void dgvListaAlmacenAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsHandleCreated)
            {
                if (dgvListaAlmacenAcc.CurrentCell == dgvListaAlmacenAcc.Rows[e.RowIndex].Cells["intDefault"])
                {
                    if (Convert.ToInt32(dgvListaAlmacenAcc.CurrentCell.Value) == 1)
                    {
                        for (int i = 0; i < dgvListaAlmacenAcc.RowCount; i++)
                        {
                            if (dgvListaAlmacenAcc.Rows[i].Cells["intDefault"] != dgvListaAlmacenAcc.CurrentCell)
                            {
                                dgvListaAlmacenAcc.Rows[i].Cells["intDefault"].Value = 0;
                            }
                        }
                    }

                }
            }
        }

        private void dgvListaAlmacenAcc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvListaAlmacenAcc.IsCurrentCellDirty)
            {
                dgvListaAlmacenAcc.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tabla.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in dgvListaAlmacen.Rows)
                {
                    int intIdAlmacen = Convert.ToInt32(row.Cells["id_Almacen"].Value);
                    string strCoAlmacen = row.Cells["codigo_Almacen"].Value.ToString();
                    string strNoAlmacen = row.Cells["nombre_Almacen"].Value.ToString();
                    tabla.Rows.Add(new object[] { intIdAlmacen, strCoAlmacen, strNoAlmacen });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaAlmacen.Rows)
                {
                    int intIdAlmacen = Convert.ToInt32(row.Cells["id_Almacen"].Value);
                    string strCoAlmacen = row.Cells["codigo_Almacen"].Value.ToString();
                    string strNoAlmacen = row.Cells["nombre_Almacen"].Value.ToString();
                    string ss = row.Cells["id_Almacen"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdAlmacen, strCoAlmacen, strNoAlmacen });
                    }

                }
            }

            dgvListaAlmacenAcc.DataSource = tabla;
        }

    }
}
