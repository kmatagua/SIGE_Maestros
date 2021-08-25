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
    public partial class OpeLogAlmacen : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_OpeLog = new DataTable();

        DataTable tblAlmacen = new DataTable();
        BindingSource src = new BindingSource();

        public OpeLogAlmacen()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");

            tabla_OpeLog.Columns.Add("id_OpeLog");
            tabla_OpeLog.Columns.Add("nombre_OpeLog");          
        }

        private void OpeLogAlmacen_Load(object sender, EventArgs e)
        {
            cbxAlmacen.SelectedIndexChanged -= cbxAlmacen_SelectedIndexChanged;


            lblEmpresa.Text = nombreEmpresa;
            ListarComboAlmacen(idEmpresa);
            ListarOpeLog(idEmpresa);

            //txtIdAlm.Text = Convert.ToString(idEmpresa);

            

            cbxAlmacen.SelectedIndexChanged += cbxAlmacen_SelectedIndexChanged;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarOpeLog(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
            tblAlmacen = obj.GridOpeLog(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblAlmacen.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_OpeLog.NewRow();
                //asignas el dato a cada columna de la row
                row["id_OpeLog"] = row1[0].ToString();
                row["nombre_OpeLog"] = row1[1].ToString();
                tabla_OpeLog.Rows.Add(row);
            }
            dgvListaOpeLog.DataSource = tabla_OpeLog;
        }

        public void ListarOpeLogAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblOpeLogAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
                int idAlmacen = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
                tblOpeLogAcc = obj.OpeLogAccesoAlm(idAlmacen, ref blnTodoOK);

                foreach (DataRow row1 in tblOpeLogAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaOpeLogAcc.DataSource = tabla;
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
            int intIdOpeLog = Convert.ToInt32(dgvListaOpeLog.CurrentRow.Cells["id_OpeLog"].Value);
            string strNoOpeLog = dgvListaOpeLog.CurrentRow.Cells["nombre_OpeLog"].Value.ToString();
            if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdOpeLog == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Operación ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdOpeLog, strNoOpeLog });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaOpeLogAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaOpeLogAcc.Rows.Count > 0)
            {
                int index = dgvListaOpeLogAcc.CurrentRow.Index;
                dgvListaOpeLogAcc.Rows.RemoveAt(index);
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
                    objNgAlm.InsertarOpeLogAlmacen(idAlmacen, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("OpeLoges agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ListarOpeLogAcc();
        }

        
    }
}
