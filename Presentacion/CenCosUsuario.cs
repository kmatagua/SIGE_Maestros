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
    public partial class CenCosUsuario : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_CenCos = new DataTable();

        DataTable tblUsuario = new DataTable();
        BindingSource src = new BindingSource();
        BindingSource src2 = new BindingSource();

        public CenCosUsuario()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idCenCos");

            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idCenCos"];
            tabla.PrimaryKey = colPk1;

            tabla_CenCos.Columns.Add("id_CenCos");
            tabla_CenCos.Columns.Add("nombre_CenCos");          
        }

        private void CenCosUsuario_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarCenCos(idEmpresa);

            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }
                      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarCenCos(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGCentroCosto obj = new NGCentroCosto(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.GridCenCos(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblUsuario.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_CenCos.NewRow();
                //asignas el dato a cada columna de la row
                row["id_CenCos"] = row1[1].ToString();
                row["nombre_CenCos"] = row1[2].ToString();
                tabla_CenCos.Rows.Add(row);
            }
            src.DataSource = tabla_CenCos;
            dgvListaCenCos.DataSource = tabla_CenCos;
        }

        public void ListarCenCosAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblCenCosAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGCentroCosto obj = new NGCentroCosto(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblCenCosAcc = obj.CenCosAccesoUsu(idUsuario, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblCenCosAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuCenCos"].ToString();
                    row["nombre"] = row1["strNoCenCos"].ToString();
                    row["idCenCos"] = row1["intIdCenCos"].ToString();
                    
                    tabla.Rows.Add(row);
                }
                src2.DataSource = tabla;
                dgvListaCenCosAcc.DataSource = tabla;
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
            int intIdCenCos = Convert.ToInt32(dgvListaCenCos.CurrentRow.Cells["id_CenCos"].Value);
            string strNoCenCos = dgvListaCenCos.CurrentRow.Cells["nombre_CenCos"].Value.ToString();
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdCenCos == Convert.ToInt32(row2["idCenCos"].ToString()))
                {
                    MessageBox.Show("El Centro de Costo ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoCenCos, intIdCenCos});

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaCenCosAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaCenCosAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaCenCosAcc.CurrentRow.Cells["id"].Value);

                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Centro de Costo?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarCenCos(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Centro de Costo Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarCenCosAcc();
                }
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
                    objNgAlm.InsertarCenCosUsuario(idUsuario, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Centro de Costo agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ListarCenCosAcc();
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
                foreach (DataGridViewRow row in dgvListaCenCos.Rows)
                {
                    int intIdCenCos = Convert.ToInt32(row.Cells["id_CenCos"].Value);
                    string strNoCenCos = row.Cells["nombre_CenCos"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoCenCos, intIdCenCos });
                }
                return;
            }

            else{
                foreach (DataGridViewRow row in dgvListaCenCos.Rows)
                {
                    int intIdCenCos = Convert.ToInt32(row.Cells["id_CenCos"].Value);
                    string strNoCenCos = row.Cells["nombre_CenCos"].Value.ToString();
                   
                    string ss = row.Cells["id_CenCos"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);
                    
                    if (foundRow1 != null)
                    {
                       
                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoCenCos, intIdCenCos }); 
                    }

                }
            }
            
            dgvListaCenCosAcc.DataSource = tabla;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            src.Filter = string.Format("nombre_CenCos LIKE '%" + txtBuscar.Text + "%'");
            dgvListaCenCos.Refresh();
            lblfiltro.Text = txtBuscar.Text;
        }

        public void filtrar()
        {
            //int intIdFamilia = idFamilia;
            //int intIdSubFamilia = idSubFamilia;

            //if (intIdFamilia > 0 && intIdSubFamilia > 0)
            //{
            //    src.Filter = "idFamilia = '" + intIdFamilia + "' AND idSubFamilia = '" + intIdSubFamilia + "' AND (nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%')";
            //}
            //if (intIdFamilia > 0 && intIdSubFamilia <= 0)
            //{
            //    src.Filter = "idFamilia = '" + intIdFamilia + "' AND (nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%')";
            //}
            //if (intIdFamilia <= 0 && intIdSubFamilia > 0)
            //{
            //    src.Filter = "idSubFamilia = '" + intIdSubFamilia + "' AND (nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%')";
            //}
            //if (intIdFamilia <= 0 && intIdSubFamilia <= 0)
            //{
            //    src.Filter = "nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%'";
            //}

        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            src2.Filter = string.Format("nombre LIKE '%" + txtBuscar2.Text + "%'");
            dgvListaCenCosAcc.Refresh();
            lblFiltro2.Text = txtBuscar2.Text;
        }

    }
}
