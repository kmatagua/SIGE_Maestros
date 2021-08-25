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
    public partial class MarcaEmpresa : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Marca = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public MarcaEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("default");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_Marca.Columns.Add("id_Marca");
            tabla_Marca.Columns.Add("nombre_Marca");          
        }

        private void MarcaEmpresa_Load(object sender, EventArgs e)
        {
            ListarMarca();

            txtIdEmp.Text = Convert.ToString(idEmpresa);
            lblEmpresa.Text = nombreEmpresa.ToString();
            Clases.Reglas.alternarColor(dgvListaMarca);
            Clases.Reglas.alternarColor(dgvListaMarcaAcc);
            ListarMarcaAcc();
        }

               
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarMarca()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGMarca obj = new NGMarca(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.MarcaTodo(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Marca.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Marca"] = row1[0].ToString();
                row["nombre_Marca"] = row1[2].ToString();
                tabla_Marca.Rows.Add(row);
            }
            dgvListaMarca.DataSource = tabla_Marca;
        }

        public void ListarMarcaAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGMarca obj = new NGMarca(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.MarcaAcceso(Convert.ToInt32(txtIdEmp.Text), ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaMarcaAcc.DataSource = tabla;
            }
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaMarcaAcc.Rows.Count > 0)
            {
                int index = dgvListaMarcaAcc.CurrentRow.Index;
                dgvListaMarcaAcc.Rows.RemoveAt(index);
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

                    objNgEmp.InsertarMarcaEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Marcas agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                foreach (DataGridViewRow row in dgvListaMarca.Rows)
                {
                    int intIdMarca = Convert.ToInt32(row.Cells["id_Marca"].Value);
                    string strNoMarca = row.Cells["nombre_Marca"].Value.ToString();

                    tabla.Rows.Add(new object[] { intIdMarca, strNoMarca });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaMarca.Rows)
                {
                    int intIdMarca = Convert.ToInt32(row.Cells["id_Marca"].Value);
                    string strNoMarca = row.Cells["nombre_Marca"].Value.ToString();
                    string ss = row.Cells["id_Marca"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdMarca, strNoMarca });
                    }

                }
            }

            dgvListaMarcaAcc.DataSource = tabla;
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdMarca = Convert.ToInt32(dgvListaMarca.CurrentRow.Cells["id_Marca"].Value);
            string strNoMarca = dgvListaMarca.CurrentRow.Cells["nombre_Marca"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdMarca == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Marca ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdMarca, strNoMarca });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaMarcaAcc.DataSource = tabla;
        }
              
    }
}
