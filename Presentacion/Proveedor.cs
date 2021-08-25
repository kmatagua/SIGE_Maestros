using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using System.Transactions;

namespace Presentacion
{
    public partial class Proveedor : Form
    {
        public int intIdEmp;
        public int idUsuario;
        public int tipo;
        public string strAccion;

        public int idProveedor;

        public Proveedor()
        {
            InitializeComponent();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGProveedor objNg = new Negocio.NGProveedor(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarProveedor(idProveedor, ref blnTodoOK);
                txtApePat.Text = tbl.Rows[0]["strApePat"].ToString();
                txtApeMat.Text = tbl.Rows[0]["strApeMat"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNomb"].ToString();
                dtpFecIng.Value = Convert.ToDateTime(tbl.Rows[0]["dttFecIng"]);
                actualizaNombre();
                txtDNI.Text = tbl.Rows[0]["strDNI"].ToString();
                txtTel.Text = tbl.Rows[0]["strTel"].ToString();
                txtContacto.Text = tbl.Rows[0]["strContacto"].ToString();
                txtRazSoc.Text = tbl.Rows[0]["strRazSoc"].ToString();
                txtRUC.Text = tbl.Rows[0]["strRUC"].ToString();
                txtCorreo.Text = tbl.Rows[0]["strCorreo"].ToString();
                //txtDireccion.Text = tbl.Rows[0]["strDir"].ToString();
                
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDireccionProveedor(idProveedor, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvDireccion.Rows.Count;
                    dgvDireccion.Rows.Add(1);

                    dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionProveedor"].Value = row["intIdDireccionProveedor"];
                    dgvDireccion.Rows[rowEscribir].Cells["id"].Value = row["intIdProveedor"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdCalle"].Value = row["intIdCalle"];
                    dgvDireccion.Rows[rowEscribir].Cells["strDireccion"].Value = row["strDireccion"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoCalle"].Value = row["strCoCalle"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoCalle"].Value = row["strNoCalle"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNro"].Value = row["strNro"];
                    dgvDireccion.Rows[rowEscribir].Cells["strPabellon"].Value = row["strPabellon"];
                    dgvDireccion.Rows[rowEscribir].Cells["strMz"].Value = row["strMz"];
                    dgvDireccion.Rows[rowEscribir].Cells["strLote"].Value = row["strLote"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdTipoDep"].Value = row["intIdTipoDep"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoTipoDep"].Value = row["strCoTipoDep"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoTipoDep"].Value = row["strNoTipoDep"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdUrbanismo"].Value = row["intIdUrbanismo"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoUrbanismo"].Value = row["strCoUrbanismo"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoUrb"].Value = row["strNoUrb"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdSector"].Value = row["intIdSector"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoSector"].Value = row["strCoSector"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoSector"].Value = row["strNoSector"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdUbigeo"].Value = row["intIdUbigeo"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoUbigeo"].Value = row["strCoUbigeo"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoUbigeo"].Value = row["strNoUbigeo"];
                    dgvDireccion.Rows[rowEscribir].Cells["intDefault"].Value = row["intDefault"];
                }

            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGProveedor objNg = new Negocio.NGProveedor(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarProveedor(idProveedor, ref blnTodoOK);

                txtApePat.Text = tbl.Rows[0]["strApePat"].ToString();
                txtApeMat.Text = tbl.Rows[0]["strApeMat"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNomb"].ToString();
                dtpFecIng.Value = Convert.ToDateTime(tbl.Rows[0]["dttFecIng"]);
                txtNombProv.Text = tbl.Rows[0]["strNombProv"].ToString();
                txtDNI.Text = tbl.Rows[0]["strDNI"].ToString();
                txtTel.Text = tbl.Rows[0]["strTel"].ToString();
                txtContacto.Text = tbl.Rows[0]["strContacto"].ToString();
                txtRazSoc.Text = tbl.Rows[0]["strRazSoc"].ToString();
                txtRUC.Text = tbl.Rows[0]["strRUC"].ToString();
                txtCorreo.Text = tbl.Rows[0]["strCorreo"].ToString();
                //txtDireccion.Text = tbl.Rows[0]["strDir"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDireccionProveedor(idProveedor, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvDireccion.Rows.Count;
                    dgvDireccion.Rows.Add(1);

                    dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionProveedor"].Value = row["intIdDireccionProveedor"];
                    dgvDireccion.Rows[rowEscribir].Cells["id"].Value = row["intIdProveedor"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdCalle"].Value = row["intIdCalle"];
                    dgvDireccion.Rows[rowEscribir].Cells["strDireccion"].Value = row["strDireccion"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoCalle"].Value = row["strCoCalle"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoCalle"].Value = row["strNoCalle"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNro"].Value = row["strNro"];
                    dgvDireccion.Rows[rowEscribir].Cells["strPabellon"].Value = row["strPabellon"];
                    dgvDireccion.Rows[rowEscribir].Cells["strMz"].Value = row["strMz"];
                    dgvDireccion.Rows[rowEscribir].Cells["strLote"].Value = row["strLote"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdTipoDep"].Value = row["intIdTipoDep"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoTipoDep"].Value = row["strNoTipoDep"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdUrbanismo"].Value = row["intIdUrbanismo"];
                    dgvDireccion.Rows[rowEscribir].Cells["strCoUrbanismo"].Value = row["strCoUrbanismo"];
                    dgvDireccion.Rows[rowEscribir].Cells["strNoUrb"].Value = row["strNoUrb"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdSector"].Value = row["intIdSector"];
                    dgvDireccion.Rows[rowEscribir].Cells["intIdUbigeo"].Value = row["intIdUbigeo"];
                    dgvDireccion.Rows[rowEscribir].Cells["intDefault"].Value = row["intDefault"];
                }

                
                txtApePat.ReadOnly = true;
                txtApeMat.ReadOnly = true;
                txtNombre.ReadOnly = true;
                dtpFecIng.Enabled = false;
                txtNombProv.ReadOnly = true;
                txtDNI.ReadOnly = true;
                txtTel.ReadOnly = true;
                txtContacto.ReadOnly = true;
                txtRazSoc.ReadOnly = true;
                txtRUC.ReadOnly = true;
                txtCorreo.ReadOnly = true;
                //txtDireccion.ReadOnly = true;
                chkEstado.Enabled = false;
                btnGuardar.Visible = false;
                chkEstado.Enabled = false;
                groupBox2.Enabled = false;


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar el proveedor?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    string p_mensaje = string.Empty;
                    bool pBlnTodoOk = false;

                    Negocio.NGProveedor objNegocio = new Negocio.NGProveedor(Configuracion.Sistema.CadenaConexion);

                    if (strAccion == "NUEVO")
                        objNegocio.InsertarProveedor(objENProveedor(), lstENDireccionProveedor(), intIdEmp, ref p_mensaje, ref pBlnTodoOk);
                    else if (strAccion == "EDITAR")
                        objNegocio.EditarProveedor(objENProveedor(), lstENDireccionProveedor(), ref p_mensaje, ref pBlnTodoOk); // EDITAR ******************

                    if (p_mensaje != string.Empty)
                    { MessageBox.Show(p_mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    if (!pBlnTodoOk)
                    { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    tscTrans.Complete();
                    MessageBox.Show("Se guardó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (strAccion == "NUEVO")
                {
                    if (MessageBox.Show("¿Desea Registrar otro Proveedor?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { Limpiar(); return; }
                    else
                    { this.Close(); }
                }
                else if (strAccion == "EDITAR")
                { this.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Configuracion.Libreria.Error_Grabar(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<ENDireccionProveedor> lstENDireccionProveedor()
        {
            List<ENDireccionProveedor> lstDireccionProveedor = new List<ENDireccionProveedor>();
            foreach (DataRow item in Dgv_DataTable().Rows)
            {
                ENDireccionProveedor ENDirProv = new ENDireccionProveedor();
                ENDirProv.intIdProveedor = idProveedor;
                ENDirProv.intIdDireccionProveedor = Convert.ToInt32(item["intIdDireccionProveedor"]);
                ENDirProv.intIdCalle = Convert.ToInt32(item["intIdCalle"]);
                ENDirProv.strDireccion = item["strDireccion"].ToString();
                ENDirProv.strNoCalle = item["strNoCalle"].ToString();
                ENDirProv.strNro = item["strNro"].ToString();
                ENDirProv.strPabellon = item["strPabellon"].ToString();
                ENDirProv.strMz = item["strMz"].ToString();
                ENDirProv.strLote = item["strLote"].ToString();
                ENDirProv.intIdTipoDep = Convert.ToInt32(item["intIdTipoDep"]);
                
                ENDirProv.strNoTipoDep = item["strNoTipoDep"].ToString();
                ENDirProv.intIdUrbanismo = Convert.ToInt32(item["intIdUrbanismo"]);
                ENDirProv.strNoUrb = item["strNoUrb"].ToString();
                ENDirProv.intIdSector = Convert.ToInt32(item["intIdSector"]);
                ENDirProv.strNoSector = item["strNoSector"].ToString();
                ENDirProv.intIdUbigeo = Convert.ToInt32(item["intIdUbigeo"]);
                ENDirProv.intDefault = Convert.ToInt32(item["intDefault"]);

                ENDirProv.intIdUsuCr = idUsuario;
                ENDirProv.intIdUsuMf = idUsuario;
                lstDireccionProveedor.Add(ENDirProv);
            }

            return lstDireccionProveedor;
        }

        public DataTable Dgv_DataTable()
        {
            //Pasando de datagridview a datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("intIdDireccionProveedor", typeof(System.String));
            dt.Columns.Add("intIdCalle", typeof(System.String));
            dt.Columns.Add("strDireccion", typeof(System.String));
            dt.Columns.Add("strCoCalle", typeof(System.String));
            dt.Columns.Add("strNoCalle", typeof(System.String));
            dt.Columns.Add("strNro", typeof(System.String));
            dt.Columns.Add("strPabellon", typeof(System.String));
            dt.Columns.Add("strMz", typeof(System.String));
            dt.Columns.Add("strLote", typeof(System.String));
            dt.Columns.Add("intIdTipoDep", typeof(System.String));
            dt.Columns.Add("strCoTipoDep", typeof(System.String));
            dt.Columns.Add("strNoTipoDep", typeof(System.String));
            dt.Columns.Add("intIdUrbanismo", typeof(System.String));
            dt.Columns.Add("strCoUrbanismo", typeof(System.String));
            dt.Columns.Add("strNoUrb", typeof(System.String));
            dt.Columns.Add("intIdSector", typeof(System.String));
            dt.Columns.Add("strCoSector", typeof(System.String));
            dt.Columns.Add("strNoSector", typeof(System.String));
            dt.Columns.Add("intIdUbigeo", typeof(System.String));
            dt.Columns.Add("intDefault", typeof(System.String));

            foreach (DataGridViewRow rowGrid in dgvDireccion.Rows)
            {
                DataRow row = dt.NewRow();
                row["intIdDireccionProveedor"] = rowGrid.Cells["intIdDireccionProveedor"].Value.ToString();
                row["intIdCalle"] = rowGrid.Cells["intIdCalle"].Value.ToString();
                row["strDireccion"] = rowGrid.Cells["strDireccion"].Value.ToString();
                row["strCoCalle"] = rowGrid.Cells["strCoCalle"].Value.ToString();
                row["strNoCalle"] = rowGrid.Cells["strNoCalle"].Value.ToString();
                row["strNro"] = rowGrid.Cells["strNro"].Value.ToString();
                row["strPabellon"] = rowGrid.Cells["strPabellon"].Value.ToString();
                row["strMz"] = rowGrid.Cells["strMz"].Value.ToString();
                row["strLote"] = rowGrid.Cells["strLote"].Value.ToString();
                row["intIdTipoDep"] = rowGrid.Cells["intIdTipoDep"].Value.ToString();
                row["strCoTipoDep"] = rowGrid.Cells["strCoTipoDep"].Value.ToString();
                row["strNoTipoDep"] = rowGrid.Cells["strNoTipoDep"].Value.ToString();
                row["intIdUrbanismo"] = rowGrid.Cells["intIdUrbanismo"].Value.ToString();
                row["strCoUrbanismo"] = rowGrid.Cells["strCoUrbanismo"].Value.ToString();
                row["strNoUrb"] = rowGrid.Cells["strNoUrb"].Value.ToString();
                row["intIdSector"] = rowGrid.Cells["intIdSector"].Value.ToString();
                row["strCoSector"] = rowGrid.Cells["strCoSector"].Value.ToString();
                row["strNoSector"] = rowGrid.Cells["strNoSector"].Value.ToString();
                row["intIdUbigeo"] = rowGrid.Cells["intIdUbigeo"].Value.ToString();
                row["intDefault"] = rowGrid.Cells["intDefault"].Value;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public void Limpiar()
        {
            //intIdUndNegocio = 0;
            txtNombProv.Clear();

            //intIdCenCos = 0;

            dgvDireccion.Rows.Clear();
            dgvDireccion.Refresh();
        }

        public ENProveedor objENProveedor()
        {

            Entidad.ENProveedor objEN = new Entidad.ENProveedor();

            objEN.intIdProv = idProveedor;
            objEN.dttFeIng = dtpFecIng.Value; 
            objEN.strRazSoc = txtRazSoc.Text.Trim(); 
            objEN.strApePat =  txtApePat.Text.Trim();
            objEN.strApeMat = txtApeMat.Text.Trim();
            objEN.strNomb = txtNombre.Text.Trim(); 
            objEN.strNombProv = txtNombProv.Text.Trim();
            objEN.strRUC = txtRUC.Text.Trim(); 
            objEN.strDNI = txtDNI.Text.Trim(); 
            objEN.strContacto = txtContacto.Text.Trim(); 
            objEN.strTel = txtTel.Text.Trim(); 
            objEN.strCorreo = txtCorreo.Text.Trim(); 

            objEN.intEstado = Convert.ToInt32(chkEstado.Checked);
            objEN.intIdUsuCr = idUsuario;
            objEN.intIdUsuMf = idUsuario;
            return objEN;
        }

        private void actualizaNombre()
        {
            txtNombProv.Text = txtApePat.Text.Trim() + ' ';
            txtNombProv.Text = txtNombProv.Text + txtApeMat.Text.Trim() + " ";
            txtNombProv.Text = txtNombProv.Text + txtNombre.Text.Trim()+ " ";
            txtNombProv.Text = txtNombProv.Text + txtRazSoc.Text.Trim();

        }

        private void txtApePat_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        private void txtApeMat_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Direccion frm = new Direccion();
            //frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombProv.Text;
            frm.strAccion = "NUEVO";

            if (frm.ShowDialog() == DialogResult.OK)
            {

                int rowEscribir = dgvDireccion.Rows.Count;
                dgvDireccion.Rows.Add(1);

                dgvDireccion.Rows[rowEscribir].Cells["id"].Value = idProveedor;
                dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionProveedor"].Value = 0;
                dgvDireccion.Rows[rowEscribir].Cells["intIdCalle"].Value = frm.idCalle;
                dgvDireccion.Rows[rowEscribir].Cells["strDireccion"].Value = frm.txtDireccion.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strCoCalle"].Value = frm.txtCalle.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strNoCalle"].Value = frm.txtNomCalle.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strNro"].Value = frm.txtNro.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strPabellon"].Value = frm.txtPabellon.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strMz"].Value = frm.txtMz.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strLote"].Value = frm.txtLote.Text;
                dgvDireccion.Rows[rowEscribir].Cells["intIdTipoDep"].Value = frm.idTipoDep;
                dgvDireccion.Rows[rowEscribir].Cells["strCoTipoDep"].Value = frm.txtDpto.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strNoTipoDep"].Value = frm.txtNomDpto.Text;
                dgvDireccion.Rows[rowEscribir].Cells["intIdUrbanismo"].Value = frm.idUrbanismo;
                dgvDireccion.Rows[rowEscribir].Cells["strCoUrbanismo"].Value = frm.idUrbanismo;
                dgvDireccion.Rows[rowEscribir].Cells["strNoUrb"].Value = frm.txtNomUrbanismo.Text;
                dgvDireccion.Rows[rowEscribir].Cells["intIdSector"].Value = frm.idEtapa;
                dgvDireccion.Rows[rowEscribir].Cells["strCoSector"].Value = frm.txtEtapa.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strNoSector"].Value = frm.txtSector.Text;
                dgvDireccion.Rows[rowEscribir].Cells["intIdUbigeo"].Value = frm.idUbigeo;
                dgvDireccion.Rows[rowEscribir].Cells["strCoUbigeo"].Value = frm.txtUbigeo.Text;
                dgvDireccion.Rows[rowEscribir].Cells["strNoUbigeo"].Value = frm.txtDistrito.Text;

                dgvDireccion.Rows[rowEscribir].Cells["intDefault"].Value = 0;


            }
        }

        private void dgvDireccion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsHandleCreated)
            {
                if (dgvDireccion.CurrentCell == dgvDireccion.Rows[e.RowIndex].Cells["intDefault"])
                {
                    if (Convert.ToInt32(dgvDireccion.CurrentCell.Value) == 1)
                    {
                        for (int i = 0; i < dgvDireccion.RowCount; i++)
                        {
                            if (dgvDireccion.Rows[i].Cells["intDefault"] != dgvDireccion.CurrentCell)
                            {
                                dgvDireccion.Rows[i].Cells["intDefault"].Value = 0;
                            }
                        }
                    }
                }
            }
        }

        private void dgvDireccion_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvDireccion.IsCurrentCellDirty)
            {
                dgvDireccion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtEditar_Click(object sender, EventArgs e)
        {
            if (dgvDireccion.CurrentRow == null)
            { MessageBox.Show("No Hay Dirección para editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            Direccion frm = new Direccion();
            frm.idCliente = idProveedor;
            frm.strAccion = "EDITAR";
            //frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombProv.Text;
            frm.idCalle = dgvDireccion.CurrentRow.Cells["intIdCalle"].Value is DBNull ? 0 : Convert.ToInt32(dgvDireccion.CurrentRow.Cells["intIdCalle"].Value);
            frm.txtCalle.Text = dgvDireccion.CurrentRow.Cells["strCoCalle"].Value.ToString();
            frm.txtNomCalle.Text = dgvDireccion.CurrentRow.Cells["strNoCalle"].Value.ToString();
            frm.txtNro.Text = dgvDireccion.CurrentRow.Cells["strNro"].Value.ToString();
            frm.txtPabellon.Text = dgvDireccion.CurrentRow.Cells["strPabellon"].Value.ToString();
            frm.txtMz.Text = dgvDireccion.CurrentRow.Cells["strMz"].Value.ToString();
            frm.txtLote.Text = dgvDireccion.CurrentRow.Cells["strLote"].Value.ToString();
            frm.idTipoDep = dgvDireccion.CurrentRow.Cells["intIdTipoDep"].Value is DBNull ? 0 : Convert.ToInt32(dgvDireccion.CurrentRow.Cells["intIdTipoDep"].Value);
            frm.txtDpto.Text = dgvDireccion.CurrentRow.Cells["strCoTipoDep"].Value.ToString();

            frm.txtNomDpto.Text = dgvDireccion.CurrentRow.Cells["strNoTipoDep"].Value.ToString();
            frm.idUrbanismo = dgvDireccion.CurrentRow.Cells["intIdUrbanismo"].Value is DBNull ? 0 : Convert.ToInt32(dgvDireccion.CurrentRow.Cells["intIdUrbanismo"].Value);
            frm.txtUrbanismo.Text = dgvDireccion.CurrentRow.Cells["strCoUrbanismo"].Value.ToString();
            frm.txtNomUrbanismo.Text = dgvDireccion.CurrentRow.Cells["strNoUrb"].Value.ToString();
            frm.idEtapa = dgvDireccion.CurrentRow.Cells["intIdSector"].Value is DBNull ? 0 : Convert.ToInt32(dgvDireccion.CurrentRow.Cells["intIdSector"].Value);
            frm.txtEtapa.Text = dgvDireccion.CurrentRow.Cells["strCoSector"].Value.ToString();
            frm.txtSector.Text = dgvDireccion.CurrentRow.Cells["strNoSector"].Value.ToString();

            frm.idUbigeo = dgvDireccion.CurrentRow.Cells["intIdUbigeo"].Value is DBNull ? 0 : Convert.ToInt32(dgvDireccion.CurrentRow.Cells["intIdUbigeo"].Value);
            frm.txtUbigeo.Text = dgvDireccion.CurrentRow.Cells["strCoUbigeo"].Value.ToString();
            frm.txtDistrito.Text = dgvDireccion.CurrentRow.Cells["strNoUbigeo"].Value.ToString();

            int index = dgvDireccion.CurrentRow.Index;
            if (frm.ShowDialog() == DialogResult.OK)
            {

                dgvDireccion.Rows[index].Cells["intIdCalle"].Value = frm.idCalle;

                dgvDireccion.Rows[index].Cells["strDireccion"].Value = frm.txtDireccion.Text;

                dgvDireccion.Rows[index].Cells["strCoCalle"].Value = frm.txtCalle.Text;
                dgvDireccion.Rows[index].Cells["strNoCalle"].Value = frm.txtNomCalle.Text;
                dgvDireccion.Rows[index].Cells["strNro"].Value = frm.txtNro.Text;
                dgvDireccion.Rows[index].Cells["strPabellon"].Value = frm.txtPabellon.Text;
                dgvDireccion.Rows[index].Cells["strMz"].Value = frm.txtMz.Text;
                dgvDireccion.Rows[index].Cells["strLote"].Value = frm.txtLote.Text;
                dgvDireccion.Rows[index].Cells["intIdTipoDep"].Value = frm.idTipoDep;

                dgvDireccion.Rows[index].Cells["strCoTipoDep"].Value = frm.txtDpto.Text;

                dgvDireccion.Rows[index].Cells["strNoTipoDep"].Value = frm.txtNomDpto.Text;
                dgvDireccion.Rows[index].Cells["intIdUrbanismo"].Value = frm.idUrbanismo;
                dgvDireccion.Rows[index].Cells["strCoUrbanismo"].Value = frm.txtUrbanismo.Text;
                dgvDireccion.Rows[index].Cells["strNoUrb"].Value = frm.txtNomUrbanismo.Text;
                dgvDireccion.Rows[index].Cells["intIdSector"].Value = frm.idEtapa;
                dgvDireccion.Rows[index].Cells["strCoSector"].Value = frm.txtEtapa.Text;
                dgvDireccion.Rows[index].Cells["strNoSector"].Value = frm.txtSector.Text;
                dgvDireccion.Rows[index].Cells["intIdUbigeo"].Value = frm.idUbigeo;
            }
        }

        private void txtQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDireccion.Rows.Count > 0)
            {
                int index = dgvDireccion.CurrentRow.Index;
                dgvDireccion.Rows.RemoveAt(index);
            }
        }

        private void txtRazSoc_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

    }
}
