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
    public partial class MaquinaAlmacen : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Maq = new DataTable();

        DataTable tblAlmacen = new DataTable();
        BindingSource src = new BindingSource();

        public MaquinaAlmacen()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_Maq.Columns.Add("id_Maq");
            tabla_Maq.Columns.Add("nombre_Maq");          
        }


        private void MaquinaAlmacen_Load(object sender, EventArgs e)
        {
            cbxAlmacen.SelectedIndexChanged -= cbxAlmacen_SelectedIndexChanged;


            lblEmpresa.Text = nombreEmpresa;
            ListarComboAlmacen(idEmpresa);
            ListarMaq(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaMaq);
            Clases.Reglas.alternarColor(dgvListaMaqAcc);
            //txtIdAlm.Text = Convert.ToString(idEmpresa);



            cbxAlmacen.SelectedIndexChanged += cbxAlmacen_SelectedIndexChanged;
        }

             
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarMaq(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGMaquina obj = new NGMaquina(Configuracion.Sistema.CadenaConexion);
            tblAlmacen = obj.GridMaq(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblAlmacen.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Maq.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Maq"] = row1[0].ToString();
                row["nombre_Maq"] = row1[1].ToString();
                tabla_Maq.Rows.Add(row);
            }
            dgvListaMaq.DataSource = tabla_Maq;
        }

        public void ListarMaqAcc(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblMaqAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGMaquina obj = new NGMaquina(Configuracion.Sistema.CadenaConexion);
                int idAlmacen = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
                tblMaqAcc = obj.MaqAccesoAlm(idAlmacen, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblMaqAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaMaqAcc.DataSource = tabla;
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
            int intIdMaq = Convert.ToInt32(dgvListaMaq.CurrentRow.Cells["id_Maq"].Value);
            string strNoMaq = dgvListaMaq.CurrentRow.Cells["nombre_Maq"].Value.ToString();
            if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdMaq == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("Maquina ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdMaq, strNoMaq });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaMaqAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaMaqAcc.Rows.Count > 0)
            {
                int index = dgvListaMaqAcc.CurrentRow.Index;
                dgvListaMaqAcc.Rows.RemoveAt(index);
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
                    objNgAlm.InsertarMaqAlmacen(idAlmacen, tabla, ref blnTodoOK);

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
            ListarMaqAcc(idEmpresa);
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
                foreach (DataGridViewRow row in dgvListaMaq.Rows)
                {
                    int intIdMaq = Convert.ToInt32(row.Cells["id_Maq"].Value);
                    string strNoMaq = row.Cells["nombre_Maq"].Value.ToString();
                    tabla.Rows.Add(new object[] { intIdMaq, strNoMaq });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaMaq.Rows)
                {
                    int intIdMaq = Convert.ToInt32(row.Cells["id_Maq"].Value);
                    string strNoMaq = row.Cells["nombre_Maq"].Value.ToString();
                    string ss = row.Cells["id_Maq"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdMaq, strNoMaq });
                    }

                }
            }

            dgvListaMaqAcc.DataSource = tabla;
        }

        
    }
}
