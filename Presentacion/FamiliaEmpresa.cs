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
    public partial class FamiliaEmpresa : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Familia = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public FamiliaEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("default");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_Familia.Columns.Add("id_Familia");
            tabla_Familia.Columns.Add("nombre_Familia");          
        }

        private void FamiliaEmpresa_Load(object sender, EventArgs e)
        {
            ListarFamilia();

            txtIdEmp.Text = Convert.ToString(idEmpresa);
            lblEmpresa.Text = nombreEmpresa.ToString();
            Clases.Reglas.alternarColor(dgvListaFamilia);
            Clases.Reglas.alternarColor(dgvListaFamiliaAcc);
            ListarFamiliaAcc();
        }

       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarFamilia()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGFamilia obj = new NGFamilia(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.FamiliaTodo(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Familia.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Familia"] = row1[0].ToString();
                row["nombre_Familia"] = row1[2].ToString();
                tabla_Familia.Rows.Add(row);
            }
            dgvListaFamilia.DataSource = tabla_Familia;
        }

        public void ListarFamiliaAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGFamilia obj = new NGFamilia(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.FamiliaAcceso(Convert.ToInt32(txtIdEmp.Text), ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaFamiliaAcc.DataSource = tabla;
            }
        }

       
        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaFamiliaAcc.Rows.Count > 0)
            {
                int index = dgvListaFamiliaAcc.CurrentRow.Index;
                dgvListaFamiliaAcc.Rows.RemoveAt(index);
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

                    objNgEmp.InsertarFamiliaEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Familias agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            if (tabla.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in dgvListaFamilia.Rows)
                {
                    int intIdFamilia = Convert.ToInt32(row.Cells["id_Familia"].Value);
                    string strNoFamilia = row.Cells["nombre_Familia"].Value.ToString();
                    tabla.Rows.Add(new object[] { intIdFamilia, strNoFamilia });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaFamilia.Rows)
                {
                    int intIdFamilia = Convert.ToInt32(row.Cells["id_Familia"].Value);
                    string strNoFamilia = row.Cells["nombre_Familia"].Value.ToString();
                    string ss = row.Cells["id_Familia"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdFamilia, strNoFamilia });
                    }

                }
            }

            dgvListaFamiliaAcc.DataSource = tabla;
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdFamilia = Convert.ToInt32(dgvListaFamilia.CurrentRow.Cells["id_Familia"].Value);
            string strNoFamilia = dgvListaFamilia.CurrentRow.Cells["nombre_Familia"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdFamilia == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Familia ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            tabla.Rows.Add(new object[] { intIdFamilia, strNoFamilia });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaFamiliaAcc.DataSource = tabla;
        }

              
    }
}
