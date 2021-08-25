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
using Presentacion.Reportes;

namespace Presentacion
{
    public partial class Clientes : Form

    {
        public int intIdCliente;
        public int idUsuario;
        public int idEmpresa;
        public int tipo;
        public int idTipoCliente;
        public int idTipoDocIde;
        public int idTipoPersona;
        public int idListaPrecios;
        public int idGiroNegocio;
        public int idCaliCliente;
        public int idAreaVenta;
        public string strAccion;

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Listar_CondVenta();
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                
                DataTable tbl = new DataTable();
                NGCliente objNeg = new NGCliente(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNeg.BuscarCliente(intIdCliente, ref blnTodoOK);
                
                txtCodigo.Text = tbl.Rows[0]["strCoCliente"].ToString();
                txtTipoPersona.Text = tbl.Rows[0]["strNoTipoPersona"].ToString();
                idTipoPersona = Convert.ToInt32(tbl.Rows[0]["intIdTipoPersona"]);

                txtTipoDocIde.Text = (tbl.Rows[0]["strCoTipoDocIde"] is DBNull) ? "" : tbl.Rows[0]["strCoTipoDocIde"].ToString();

                idTipoDocIde = (tbl.Rows[0]["intIdTipoDocIde"] is DBNull) ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdTipoDocIde"]);
                txtRuc.Text = tbl.Rows[0]["strRuc"].ToString();
                txtDni.Text = tbl.Rows[0]["strDni"].ToString();
                dtpFecha.Value = tbl.Rows[0]["dttFeReg"] is DBNull ? dtpFecha.Value.AddDays(0) : Convert.ToDateTime(tbl.Rows[0]["dttFeReg"].ToString());
                txtApePat.Text = tbl.Rows[0]["strApePat"].ToString();
                txtApeMat.Text = tbl.Rows[0]["strApeMat"].ToString();
                txtPrimerNombre.Text = tbl.Rows[0]["strNom1"].ToString();
                txtSegundoNombre.Text = tbl.Rows[0]["strNom2"].ToString();
                txtRazonSocial.Text = tbl.Rows[0]["strRazSoc"].ToString();
                txtNombreComercial.Text = tbl.Rows[0]["strNoCliente"].ToString();
                idTipoCliente = Convert.ToInt32(tbl.Rows[0]["intIdTipoCliente"]);
                txtTipoCliente.Text = tbl.Rows[0]["strNoTipoCLiente"].ToString();


                txtTlfFijo.Text = tbl.Rows[0]["strTlfFijo"].ToString();
                txtTlfMovil.Text = tbl.Rows[0]["strTlfMovil"].ToString();
                txtContacto.Text = tbl.Rows[0]["strContacto"].ToString();
                txtEmail.Text = tbl.Rows[0]["strMail"].ToString();
                idListaPrecios = Convert.ToInt32(tbl.Rows[0]["intIdTipoListaPrecio"]);
                txtListaPrecios.Text = tbl.Rows[0]["strNoTipoListaPrecio"].ToString();
                //cbxGiroCliente.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdGiroCliente"]);
                txtCalificacion.Text = tbl.Rows[0]["strNoCaliCliente"].ToString();
                idCaliCliente = Convert.ToInt32(tbl.Rows[0]["intIdCaliCliente"]);
                chkAprobado.Checked = Convert.ToBoolean(tbl.Rows[0]["intIdEstadoAprobacion"]);
                idAreaVenta = tbl.Rows[0]["intIdArea"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdArea"]);
                txtArea.Text = tbl.Rows[0]["strCoAreaVenta"].ToString();
                txtZona.Text = tbl.Rows[0]["strZona"].ToString();
                txtRuta.Text = tbl.Rows[0]["strRuta"].ToString();
                txtInterrelacion.Text = tbl.Rows[0]["strInterrelacion"].ToString();
                //txtDireccion.Text = tbl.Rows[0]["strDireccion"].ToString();

                txtLimCre.Text = tbl.Rows[0]["decLimCre"] is DBNull ? string.Empty : tbl.Rows[0]["decLimCre"].ToString();
                cbxFormaPago.SelectedValue = tbl.Rows[0]["intIdFormaPago"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdFormaPago"]);
                //txtNombre.Text = tbl.Rows[0]["strNoCliente"].ToString();
                chkTransporte.Checked = tbl.Rows[0]["intTransportista"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intTransportista"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                actualizaNombre();
                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNeg.ListarDireccion(intIdCliente, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvDireccion.Rows.Count;
                    dgvDireccion.Rows.Add(1);
                    
                    dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionCliente"].Value = row["intIdDireccionCliente"];
                    dgvDireccion.Rows[rowEscribir].Cells["id"].Value = row["intIdCliente"];
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

                //txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGCliente objNeg = new Negocio.NGCliente(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNeg.BuscarCliente(intIdCliente, ref blnTodoOK);

                txtCodigo.Text = tbl.Rows[0]["strCoCliente"].ToString();
                txtTipoPersona.Text = tbl.Rows[0]["strNoTipoPersona"].ToString();

                txtTipoDocIde.Text = (tbl.Rows[0]["strCoTipoDocIde"] is DBNull) ? "" : tbl.Rows[0]["strCoTipoDocIde"].ToString();

                txtRuc.Text = tbl.Rows[0]["strRuc"].ToString();
                txtDni.Text = tbl.Rows[0]["strDni"].ToString();
                dtpFecha.Value = Convert.ToDateTime(tbl.Rows[0]["dttFeReg"].ToString());
                txtApePat.Text = tbl.Rows[0]["strApePat"].ToString();
                txtApeMat.Text = tbl.Rows[0]["strApeMat"].ToString();
                txtPrimerNombre.Text = tbl.Rows[0]["strNom1"].ToString();
                txtSegundoNombre.Text = tbl.Rows[0]["strNom2"].ToString();
                txtRazonSocial.Text = tbl.Rows[0]["strRazSoc"].ToString();
                txtNombreComercial.Text = tbl.Rows[0]["strNoCliente"].ToString();
                txtTipoCliente.Text = tbl.Rows[0]["strNoTipoCLiente"].ToString();


                txtTlfFijo.Text = tbl.Rows[0]["strTlfFijo"].ToString();
                txtTlfMovil.Text = tbl.Rows[0]["strTlfMovil"].ToString();
                txtContacto.Text = tbl.Rows[0]["strContacto"].ToString();
                txtEmail.Text = tbl.Rows[0]["strMail"].ToString();
                txtListaPrecios.Text = tbl.Rows[0]["strNoTipoListaPrecio"].ToString();
                //cbxGiroCliente.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdGiroCliente"]);
                txtCalificacion.Text = tbl.Rows[0]["strNoCaliCliente"].ToString();
                chkAprobado.Checked = Convert.ToBoolean(tbl.Rows[0]["intIdEstadoAprobacion"]);
                idAreaVenta = tbl.Rows[0]["intIdArea"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdArea"]);
                txtArea.Text = tbl.Rows[0]["strCoAreaVenta"].ToString();
                txtZona.Text = tbl.Rows[0]["strZona"].ToString();
                txtRuta.Text = tbl.Rows[0]["strRuta"].ToString();
                txtInterrelacion.Text = tbl.Rows[0]["strInterrelacion"].ToString();
                //txtDireccion.Text = tbl.Rows[0]["strDireccion"].ToString();

                txtLimCre.Text = tbl.Rows[0]["decLimCre"] is DBNull ? string.Empty : tbl.Rows[0]["decLimCre"].ToString();
                cbxFormaPago.SelectedValue = tbl.Rows[0]["intIdFormaPago"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdFormaPago"]);

                chkTransporte.Checked = tbl.Rows[0]["intTransportista"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intTransportista"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                actualizaNombre();
                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNeg.ListarDireccion(intIdCliente, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvDireccion.Rows.Count;
                    dgvDireccion.Rows.Add(1);

                    dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionCliente"].Value = row["intIdDireccionCliente"];
                    dgvDireccion.Rows[rowEscribir].Cells["id"].Value = row["intIdCliente"];
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
                btnGuardar.Visible = false;
               
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                dgvDireccion.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }
                        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if ((dtpFecha.Value.ToString("yyyy") != strCoPeriodo.Substring(0, 4)) || (dtpFecha.Value.ToString("MM") != strCoPeriodo.Substring(4, 2)))
            //{ MessageBox.Show("La fecha ingresada no se encuentra dentro del periodo actual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpFecha.Focus(); return; }

            //if (dgvDetalle.RowCount <= 0)
            //{ MessageBox.Show("No se encontraron detalles para guardar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("¿Desea guardar el Cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    string p_mensaje = string.Empty;
                    bool pBlnTodoOk = false;

                    Negocio.NGCliente objNegocio = new Negocio.NGCliente(Configuracion.Sistema.CadenaConexion);

                    if (strAccion == "NUEVO")
                        objNegocio.InsertarCliente(objENCliente(), lstENDireccionCliente(), idEmpresa, ref p_mensaje, ref pBlnTodoOk);
                    else if (strAccion == "EDITAR")
                        objNegocio.EditarCliente(objENCliente(), lstENDireccionCliente(), ref p_mensaje, ref pBlnTodoOk); // EDITAR ******************

                    if (p_mensaje != string.Empty)
                    { MessageBox.Show(p_mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    if (!pBlnTodoOk)
                    { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    tscTrans.Complete();
                    MessageBox.Show("Se guardó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (strAccion == "NUEVO")
                {
                    if (MessageBox.Show("¿Desea Registrar otro Cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        
        private void btnDireccion_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Debe Guardar el Cliente para Agregar sus Direcciones", "", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                
            //    btnGuardar.PerformClick();
               
            //}
            Direccion_Listado frm = new Direccion_Listado();
            //frm.MdiParent = this;
            frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombreComercial.Text;

            frm.ShowDialog();
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

        #region F1
        
        private void txtTipoDocIde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "TIPODOCIDE";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idTipoDocIde = frm.idEncontrado;
                    txtTipoDocIde.Text = frm.codigoEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtRuc.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtTipoPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "TIPOPERSONA";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idTipoPersona = frm.idEncontrado;
                    txtTipoPersona.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtTipoDocIde.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtListaPrecios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "LISTAPRECIOS";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idListaPrecios = frm.idEncontrado;
                    txtListaPrecios.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtGiroNegocio.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtGiroNegocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "GIRONEGOCIO";
                frm.tipoTabla = "GIRONEGOCIO";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idGiroNegocio = frm.idEncontrado;
                    txtGiroNegocio.Text = frm.codigoEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtCalificacion.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtCalificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "CALICLIENTE";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idCaliCliente = frm.idEncontrado;
                    txtCalificacion.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    chkAprobado.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtTipoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "TIPOCLIENTE";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idTipoCliente = frm.idEncontrado;
                    txtTipoCliente.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtTlfFijo.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Direccion frm = new Direccion();
            frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombreComercial.Text;
            frm.strAccion = "NUEVO";

            if (frm.ShowDialog() == DialogResult.OK)
            {
               
                        int rowEscribir = dgvDireccion.Rows.Count;
                        dgvDireccion.Rows.Add(1);

                        dgvDireccion.Rows[rowEscribir].Cells["id"].Value = intIdCliente;
                        dgvDireccion.Rows[rowEscribir].Cells["intIdDireccionCliente"].Value = 0;
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
            /*********************************************************************************************/
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDireccion.CurrentRow == null)
            { MessageBox.Show("No Hay Dirección para editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            Direccion frm = new Direccion();
            frm.idCliente = intIdCliente;
            frm.strAccion = "EDITAR";
            frm.codigoCliente = txtCodigo.Text;
            frm.nombreCliente = txtNombreComercial.Text;
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDireccion.Rows.Count > 0)
            {
                int index = dgvDireccion.CurrentRow.Index;
                dgvDireccion.Rows.RemoveAt(index);
            }
        }

        public List<ENDireccionCliente> lstENDireccionCliente()
        {
            List<ENDireccionCliente> lstDireccionCliente = new List<ENDireccionCliente>();
            foreach (DataRow item in Dgv_DataTable().Rows)
            {
                ENDireccionCliente ENDirCli = new ENDireccionCliente();
                ENDirCli.intIdCliente = intIdCliente;
                ENDirCli.intIdDireccionCliente = Convert.ToInt32(item["intIdDireccionCliente"]);
                ENDirCli.intIdCalle = Convert.ToInt32(item["intIdCalle"]);
                ENDirCli.strDireccion = item["strDireccion"].ToString();
                ENDirCli.strNoCalle = item["strNoCalle"].ToString();
                ENDirCli.strNro = item["strNro"].ToString();
                ENDirCli.strPabellon = item["strPabellon"].ToString();
                ENDirCli.strMz = item["strMz"].ToString();
                ENDirCli.strLote = item["strLote"].ToString();
                ENDirCli.intIdTipoDep = Convert.ToInt32(item["intIdTipoDep"]);

                ENDirCli.strNoTipoDep = item["strNoTipoDep"].ToString();
                ENDirCli.intIdUrbanismo = Convert.ToInt32(item["intIdUrbanismo"]);
                ENDirCli.strNoUrb = item["strNoUrb"].ToString();
                ENDirCli.intIdSector = Convert.ToInt32(item["intIdSector"]);
                ENDirCli.strNoSector = item["strNoSector"].ToString();
                ENDirCli.intIdUbigeo = Convert.ToInt32(item["intIdUbigeo"]);
                ENDirCli.intDefault = Convert.ToInt32(item["intDefault"]);

                ENDirCli.intIdUsuCr = idUsuario;
                ENDirCli.intIdUsuMf = idUsuario;
                lstDireccionCliente.Add(ENDirCli);
            }

            return lstDireccionCliente;
        }

        public DataTable Dgv_DataTable()
        {
            //Pasando de datagridview a datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("intIdDireccionCliente", typeof(System.String));
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
                row["intIdDireccionCliente"] = rowGrid.Cells["intIdDireccionCliente"].Value.ToString();
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

        public ENCliente objENCliente()
        {
        
            Entidad.ENCliente objEN = new Entidad.ENCliente();
            
            /*Primera fila del formulario*/
            objEN.intIdCliente = intIdCliente;
            objEN.strCoCliente = txtCodigo.Text;
            objEN.intIdTipoPer = idTipoPersona;
            objEN.intIdTipoDocPer = idTipoDocIde;
            objEN.strRuc = txtRuc.Text;
            objEN.strDni = txtDni.Text;
            objEN.dttFeReg = dtpFecha.Value;

            /*segunda fila del formulario*/
            objEN.strApePat = txtApePat.Text;
            objEN.strApeMat = txtApeMat.Text;
            objEN.strNom1 = txtPrimerNombre.Text;
            objEN.strNom2 = txtSegundoNombre.Text;
            
            /*tercera fila del formulario*/
            objEN.strRazSoc = txtRazonSocial.Text;
            objEN.strNoCliente = txtNombreComercial.Text;
            objEN.intIdTipoCliente = idTipoCliente;

            /*Cuarta fila del formulario*/
            objEN.strTlfFijo = txtTlfFijo.Text;
            objEN.strTlfMovil = txtTlfMovil.Text;
            objEN.strContacto = txtContacto.Text;
            objEN.strMail = txtEmail.Text;
            
            /*Quinta fila del Formulario*/
            objEN.intIdTipoListaPrecio = idListaPrecios;
            objEN.intIdGiroCliente = idGiroNegocio;
            objEN.intIdCaliCliente = idCaliCliente;
            objEN.intIdEstadoAprobacion = Convert.ToInt32(chkAprobado.Checked);
            
            /*Sexta fila del formulario*/
            objEN.intIdArea = idAreaVenta;
            objEN.strZona = txtZona.Text;
            objEN.strRuta = txtRuta.Text;
            objEN.strInterrelacion = txtInterrelacion.Text;
            objEN.intTransportista = Convert.ToInt32(chkTransporte.Checked);
            objEN.intIdFormaPago = Convert.ToInt32(cbxFormaPago.SelectedValue);
            objEN.decLimCre = txtLimCre.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtLimCre.Text);

            /*Septima fila del formulario*/
            objEN.intEstado = Convert.ToInt32(chkEstado.Checked);
            objEN.intIdUsuCr = idUsuario;
            objEN.intIdUsuMf = idUsuario;
            return objEN;
        }

        public void Limpiar()
        {
            //intIdUndNegocio = 0;
            txtCodigo.Clear();

            //intIdCenCos = 0;

            dgvDireccion.Rows.Clear();
            dgvDireccion.Refresh();
        }

        private void actualizaNombre()
        {
            txtNombreCompleto.Text = txtApePat.Text + " ";
            txtNombreCompleto.Text = txtNombreCompleto.Text + txtApeMat.Text.Trim() + " ";
            txtNombreCompleto.Text = txtNombreCompleto.Text + txtPrimerNombre.Text.Trim() + " ";
            txtNombreCompleto.Text = txtNombreCompleto.Text + txtSegundoNombre.Text.Trim();
        }

        #region DEJAR FOCO

        private void txtApePat_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        private void txtApeMat_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        private void txtPrimerNombre_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        private void txtSegundoNombre_Leave(object sender, EventArgs e)
        {
            actualizaNombre();
        }

        #endregion

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "AREAVENTA";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idAreaVenta = frm.idEncontrado;
                    txtArea.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtZona.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        public void Listar_CondVenta()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo("FORMA_PAGO", 0, ref pBlnTodoOk);

            cbxFormaPago.DisplayMember = "strDeForPago";
            cbxFormaPago.ValueMember = "intIdForPago";
            cbxFormaPago.DataSource = tbl;
        }

        private void tsImprimir_Click(object sender, EventArgs e)
        {
            //rptVisorReporte2 frm = new rptVisorReporte2();
            //frm.strNoTipoReporte = "CLIENTE";
            //frm.idCliente = intIdCliente;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
        }

    }
}
