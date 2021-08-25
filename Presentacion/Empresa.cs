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
    public partial class Empresa : Form
    {
        public int intIdEmp;
        public int tipo;
        public int idUsuario;
        public string strAccion;

        public Empresa()
        {
            InitializeComponent();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGEmpresa objNg = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarEmpresa(intIdEmp, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdEmp"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoEmp"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtRuc.Text = tbl.Rows[0]["strRuc"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                
                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDireccion(intIdEmp, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvDireccion.Rows.Count;
                    dgvDireccion.Rows.Add(1);

                    dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionEmpresa"].Value = row["intIdDireccionEmpresa"];
                    dgvDireccion.Rows[rowEscribir].Cells["id"].Value = row["intIdEmpresa"];
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
                             
                txtCodigo.Enabled = false;
            }
            else if (tipo == 3)
            {
                DataTable tbl = new DataTable();
                Negocio.NGEmpresa objNg = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarEmpresa(intIdEmp, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdEmp"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoEmp"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtRuc.Text = tbl.Rows[0]["strRuc"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDireccion(intIdEmp, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvDireccion.Rows.Count;
                    dgvDireccion.Rows.Add(1);

                    dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionEmpresa"].Value = row["intIdDireccionEmpresa"];
                    dgvDireccion.Rows[rowEscribir].Cells["id"].Value = row["intIdEmpresa"];
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

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtRuc.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar la Empresa?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    string p_mensaje = string.Empty;
                    bool pBlnTodoOk = false;

                    Negocio.NGEmpresa objNegocio = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);

                    if (strAccion == "NUEVO")
                        objNegocio.InsertarEmpresa(objENEmpresa(), lstENDireccionEmpresa(), intIdEmp, ref p_mensaje, ref pBlnTodoOk);
                    else if (strAccion == "EDITAR")
                        objNegocio.EditarEmpresa(objENEmpresa(), lstENDireccionEmpresa(), ref p_mensaje, ref pBlnTodoOk); // EDITAR ******************

                    if (p_mensaje != string.Empty)
                    { MessageBox.Show(p_mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    if (!pBlnTodoOk)
                    { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    tscTrans.Complete();
                    MessageBox.Show("Se guardó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (strAccion == "NUEVO")
                {
                    if (MessageBox.Show("¿Desea Registrar otra Empresa?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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


        #region

        //public void Insertar()
        //{
        //    try
        //    {
        //        string mensaje = string.Empty;
        //        bool blnTodoOK = false;
        //        ENEmpresa obj = new ENEmpresa();
        //        obj.strCoEmp = txtCodigo.Text.Trim();
        //        obj.strNoEmp = txtNombre.Text.Trim();
        //        obj.strRuc = txtRuc.Text.Trim();
        //        obj.intEstado = Convert.ToInt32(chkEstado.Checked);
        //        obj.intIdUsuCr = idUsuario;

        //        Negocio.NGEmpresa objNg = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);

        //        objNg.InsertarEmpresa(obj, ref mensaje, ref blnTodoOK);

        //        if (mensaje != "")
        //        {
        //            MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        if (!blnTodoOK)
        //        {
        //            MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Empresa guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //public void Editar()
        //{

        //    bool blnTodoOK = false;
        //    ENEmpresa obj = new ENEmpresa();
        //    obj.intIdEmp = intIdEmp;
        //    obj.strCoEmp = txtCodigo.Text.Trim();
        //    obj.strNoEmp = txtNombre.Text.Trim();
        //    obj.strRuc = txtRuc.Text.Trim();
        //    obj.intEstado = Convert.ToInt32(chkEstado.Checked);
        //    obj.intIdUsuMf = idUsuario;
            
        //    Negocio.NGEmpresa objNg = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);

        //    objNg.EditarEmpresa(obj, ref blnTodoOK);

        //    if (blnTodoOK)
        //    {
        //        MessageBox.Show("Empresa Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    this.Close();
        //}

        #endregion

        public ENEmpresa objENEmpresa()
        {

            Entidad.ENEmpresa objEN = new Entidad.ENEmpresa();

            objEN.intIdEmp = intIdEmp;
            objEN.strCoEmp = txtCodigo.Text;
            objEN.strNoEmp = txtNombre.Text;
            objEN.strRuc = txtRuc.Text;

            objEN.intEstado = Convert.ToInt32(chkEstado.Checked);
            objEN.intIdUsuCr = idUsuario;
            objEN.intIdUsuMf = idUsuario;
            return objEN;
        }

        public List<ENDireccionEmpresa> lstENDireccionEmpresa()
        {
            List<ENDireccionEmpresa> lstDireccionEmpresa = new List<ENDireccionEmpresa>();
            foreach (DataRow item in Dgv_DataTable().Rows)
            {
                ENDireccionEmpresa ENDirEmp = new ENDireccionEmpresa();
                ENDirEmp.intIdEmpresa = intIdEmp;
                ENDirEmp.intIdDireccionEmpresa = Convert.ToInt32(item["intIdDireccionEmpresa"]);
                ENDirEmp.intIdCalle = Convert.ToInt32(item["intIdCalle"]);
                ENDirEmp.strDireccion = item["strDireccion"].ToString();
                ENDirEmp.strNoCalle = item["strNoCalle"].ToString();
                ENDirEmp.strNro = item["strNro"].ToString();
                ENDirEmp.strPabellon = item["strPabellon"].ToString();
                ENDirEmp.strMz = item["strMz"].ToString();
                ENDirEmp.strLote = item["strLote"].ToString();
                ENDirEmp.intIdTipoDep = Convert.ToInt32(item["intIdTipoDep"]);

                ENDirEmp.strNoTipoDep = item["strNoTipoDep"].ToString();
                ENDirEmp.intIdUrbanismo = Convert.ToInt32(item["intIdUrbanismo"]);
                ENDirEmp.strNoUrb = item["strNoUrb"].ToString();
                ENDirEmp.intIdSector = Convert.ToInt32(item["intIdSector"]);
                ENDirEmp.strNoSector = item["strNoSector"].ToString();
                ENDirEmp.intIdUbigeo = Convert.ToInt32(item["intIdUbigeo"]);
                ENDirEmp.intDefault = Convert.ToInt32(item["intDefault"]);

                ENDirEmp.intIdUsuCr = idUsuario;
                ENDirEmp.intIdUsuMf = idUsuario;
                lstDireccionEmpresa.Add(ENDirEmp);
            }

            return lstDireccionEmpresa;
        }

        public DataTable Dgv_DataTable()
        {
            //Pasando de datagridview a datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("intIdDireccionEmpresa", typeof(System.String));
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
                row["intIdDireccionEmpresa"] = rowGrid.Cells["intIdDireccionEmpresa"].Value.ToString();
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
            txtCodigo.Clear();

            //intIdCenCos = 0;

            dgvDireccion.Rows.Clear();
            dgvDireccion.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Direccion frm = new Direccion();
            frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombre.Text;
            frm.strAccion = "NUEVO";

            if (frm.ShowDialog() == DialogResult.OK)
            {
               
                        int rowEscribir = dgvDireccion.Rows.Count;
                        dgvDireccion.Rows.Add(1);

                        dgvDireccion.Rows[rowEscribir].Cells["id"].Value = intIdEmp;
                        dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionEmpresa"].Value = 0;
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
            frm.idCliente = intIdEmp;
            frm.strAccion = "EDITAR";
            frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombre.Text;
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

    }
}
