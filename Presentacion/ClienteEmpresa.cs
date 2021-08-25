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
    public partial class ClienteEmpresa : Form
    {
        //public int idEmpresa;
        //public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Cliente = new DataTable();

        DataTable tbl = new DataTable();
        BindingSource src = new BindingSource();

        public ClienteEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");

            tabla_Cliente.Columns.Add("id_Cli");
            tabla_Cliente.Columns.Add("nombre_Cli");          
        }


        private void ClienteEmpresa_Load(object sender, EventArgs e)
        {
            cbxEmpresa.SelectedIndexChanged -= cbxEmpresa_SelectedIndexChanged;


            //lblEmpresa.Text = nombreEmpresa;
            ListarComboEmpresa();
            ListarCliente();
            Clases.Reglas.alternarColor(dgvListaCliente);
            Clases.Reglas.alternarColor(dgvListaClienteAcc);
            //txtIdAlm.Text = Convert.ToString(idEmpresa);



            cbxEmpresa.SelectedIndexChanged += cbxEmpresa_SelectedIndexChanged;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarCliente()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGCliente obj = new NGCliente(Configuracion.Sistema.CadenaConexion);
            //tbl = obj.GridCliente(ref blnTodoOK);
            foreach (DataRow row1 in tbl.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Cliente.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Cli"] = row1[0].ToString();
                row["nombre_Cli"] = row1[1].ToString();
                tabla_Cliente.Rows.Add(row);
            }
            dgvListaCliente.DataSource = tabla_Cliente;
        }

        public void ListarClienteAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblClienteAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGCliente obj = new NGCliente(Configuracion.Sistema.CadenaConexion);
                int idEmpresa = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                //tblClienteAcc = obj.ClienteAccesoEmp(idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblClienteAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaClienteAcc.DataSource = tabla;
            }
        }

        public void ListarComboEmpresa()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ComboEmpresa(ref blnTodoOK);

            cbxEmpresa.DataSource = tbl;
            cbxEmpresa.DisplayMember = "strNoEmp";
            cbxEmpresa.ValueMember = "intIdEmp";
            //src.DataSource = tblAlmacen;
            //dgvLista.DataSource = src;


        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdCli = Convert.ToInt32(dgvListaCliente.CurrentRow.Cells["id_Cli"].Value);
            string strNoCli = dgvListaCliente.CurrentRow.Cells["nombre_Cli"].Value.ToString();
            if (Convert.ToInt32(cbxEmpresa.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdCli == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("El Cliente ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdCli, strNoCli });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaClienteAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaClienteAcc.Rows.Count > 0)
            {
                int index = dgvListaClienteAcc.CurrentRow.Index;
                dgvListaClienteAcc.Rows.RemoveAt(index);
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
                    int idEmpresa = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                    objNgEmp.InsertarClienteEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Clientes agregados con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
            txtIdEmp.Text = valor.ToString();
            tabla.Clear();
            ListarClienteAcc();
        }



    }
}
