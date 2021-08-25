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
    public partial class UsuarioAlmacen : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Usu = new DataTable();

        DataTable tblAlmacen = new DataTable();
        BindingSource src = new BindingSource();

        public UsuarioAlmacen()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_Usu.Columns.Add("id_Usu");
            tabla_Usu.Columns.Add("nombre_Usu");          
        }

        private void UsuarioAlmacen_Load(object sender, EventArgs e)
        {
            cbxAlmacen.SelectedIndexChanged -= cbxAlmacen_SelectedIndexChanged;


            lblEmpresa.Text = nombreEmpresa;
            ListarComboAlmacen(idEmpresa);
            ListarUsu(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaUsu);
            Clases.Reglas.alternarColor(dgvListaUsuAcc);
            //txtIdAlm.Text = Convert.ToString(idEmpresa);



            cbxAlmacen.SelectedIndexChanged += cbxAlmacen_SelectedIndexChanged;
        }
                
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarUsu(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
            tblAlmacen = obj.GridUsu(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblAlmacen.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Usu.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Usu"] = row1[0].ToString();
                row["nombre_Usu"] = row1[1].ToString();
                tabla_Usu.Rows.Add(row);
            }
            dgvListaUsu.DataSource = tabla_Usu;
        }

        public void ListarUsuAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblUsuAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
                int idAlmacen = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
                tblUsuAcc = obj.UsuAccesoAlm(idAlmacen, ref blnTodoOK);

                foreach (DataRow row1 in tblUsuAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaUsuAcc.DataSource = tabla;
            }
        }

        public void ListarComboAlmacen(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGAlmacen obj = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
            tblAlmacen = obj.ComboAlmacen(idEmpresa, ref blnTodoOK);

            cbxAlmacen.DataSource = tblAlmacen;
            cbxAlmacen.DisplayMember = "strNoAlm";
            cbxAlmacen.ValueMember = "intIdAlm";
            //src.DataSource = tblAlmacen;
            //dgvLista.DataSource = src;


        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdUsu = Convert.ToInt32(dgvListaUsu.CurrentRow.Cells["id_Usu"].Value);
            string strNoUsu = dgvListaUsu.CurrentRow.Cells["nombre_Usu"].Value.ToString();
            if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdUsu == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("El Usuario ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdUsu, strNoUsu });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaUsuAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaUsuAcc.Rows.Count > 0)
            {
                int index = dgvListaUsuAcc.CurrentRow.Index;
                dgvListaUsuAcc.Rows.RemoveAt(index);
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

                    NGAlmacen objNgAlm = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
                    int idAlmacen = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
                    objNgAlm.InsertarUsuAlmacen(idAlmacen, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cbxAlmacen.SelectedValue = 0;
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
            txtIdAlm.Text = valor.ToString();
            tabla.Clear();
            ListarUsuAcc();
        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tabla.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in dgvListaUsu.Rows)
                {
                    int intIdUsu = Convert.ToInt32(row.Cells["id_Usu"].Value);
                    string strNoUsu = row.Cells["nombre_Usu"].Value.ToString();
                    tabla.Rows.Add(new object[] { intIdUsu, strNoUsu });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaUsu.Rows)
                {
                    int intIdUsu = Convert.ToInt32(row.Cells["id_Usu"].Value);
                    string strNoUsu = row.Cells["nombre_Usu"].Value.ToString();
                    string ss = row.Cells["id_Usu"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdUsu, strNoUsu });
                    }

                }
            }

            dgvListaUsuAcc.DataSource = tabla;
        }
        
    }
}
