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
    public partial class UnidadEmpresa : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Uni = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public UnidadEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("default");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_Uni.Columns.Add("id_Uni");
            tabla_Uni.Columns.Add("nombre_Uni");          
        }


        private void UnidadEmpresa_Load(object sender, EventArgs e)
        {
            ListarUnidad();

            txtIdEmp.Text = Convert.ToString(idEmpresa);
            lblEmpresa.Text = nombreEmpresa.ToString();
            Clases.Reglas.alternarColor(dgvListaUni);
            Clases.Reglas.alternarColor(dgvListaUniAcc);
            ListarUniAcc();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarUnidad()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUnidad obj = new NGUnidad(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.UnidadTodo(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Uni.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Uni"] = row1[0].ToString();
                row["nombre_Uni"] = row1[2].ToString();
                tabla_Uni.Rows.Add(row);
            }
            dgvListaUni.DataSource = tabla_Uni;
        }

        public void ListarUniAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGUnidad obj = new NGUnidad(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.UnidadAcceso(Convert.ToInt32(txtIdEmp.Text), ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaUniAcc.DataSource = tabla;
            }
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaUniAcc.Rows.Count > 0)
            {
                int index = dgvListaUniAcc.CurrentRow.Index;
                dgvListaUniAcc.Rows.RemoveAt(index);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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

                    NGEmpresa objNgEmp = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

                    objNgEmp.InsertarUniEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Unidades agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdUni = Convert.ToInt32(dgvListaUni.CurrentRow.Cells["id_Uni"].Value);
            string strNoUni = dgvListaUni.CurrentRow.Cells["nombre_Uni"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdUni == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Unidad ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            tabla.Rows.Add(new object[] { intIdUni, strNoUni });

            dgvListaUniAcc.DataSource = tabla;
        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            if (tabla.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in dgvListaUni.Rows)
                {
                    int intIdUni = Convert.ToInt32(row.Cells["id_Uni"].Value);
                    string strNoUni = row.Cells["nombre_Uni"].Value.ToString();
                    tabla.Rows.Add(new object[] { intIdUni, strNoUni });
                }
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dgvListaUni.Rows)
                {
                    int intIdUni = Convert.ToInt32(row.Cells["id_Uni"].Value);
                    string strNoUni = row.Cells["nombre_Uni"].Value.ToString();
                    string ss = row.Cells["id_Uni"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdUni, strNoUni });
                    }
                }
            }
            dgvListaUniAcc.DataSource = tabla;
        }
    }
}
