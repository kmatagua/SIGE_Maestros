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

namespace Presentacion
{
    public partial class Articulo : Form
    {
        public int intIdArticulo;
        public int tipo;
        public int idSubFamilia;
        public int idFamilia;
        public int idUsuario;
        public int idEmpresa;
        public int idUnidad;
        public int idUnidadComp;
        decimal TotalPond = 0;
        public Articulo()
        {
            InitializeComponent();
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            ListarComboClaArt();
            paneles();

            if (tipo == 1)
            { //NUEVO
                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGArticulo objNg = new NGArticulo(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarArticulo(intIdArticulo, ref blnTodoOK);
                //txtIdArticulo.Text = tbl.Rows[0]["intIdArt"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoArt"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoArt"].ToString();
                txtFamilia.Text = tbl.Rows[0]["strNoFamilia"].ToString();
                txtSubFamilia.Text = tbl.Rows[0]["strNoSubFamilia"].ToString();
                idSubFamilia = Convert.ToInt32(tbl.Rows[0]["intIdSubFamilia"]);
                idFamilia = tbl.Rows[0]["intIdFamilia"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdFamilia"]);
                //cbxSubFamilia.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdSubFamilia"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                chkFav.Checked = tbl.Rows[0]["intFav"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intFav"]);
                chkKit.Checked = tbl.Rows[0]["intKit"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intKit"]);
                chkReceta.Checked = tbl.Rows[0]["intReceta"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intReceta"]);
                txtComposicion.Text = tbl.Rows[0]["intComposicion"].ToString();
                txtCodAlt.Text = tbl.Rows[0]["strCodAlt"].ToString();
                txtTag.Text = tbl.Rows[0]["strTag"].ToString();
                cbxClaArt.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdClaArt"]);
                txtUnidad.Text = tbl.Rows[0]["strCoUni"].ToString();
                idUnidad = Convert.ToInt32(tbl.Rows[0]["intIdUni"]);

                txtUnidadComp.Text = tbl.Rows[0]["strCoUniComp"].ToString();
                idUnidadComp = tbl.Rows[0]["intIdUniComp"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdUniComp"]);

                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDetKit(intIdArticulo, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvKit.Rows.Count;
                    dgvKit.Rows.Add(1);
                    dgvKit.Rows[rowEscribir].Cells["intIdArtKit"].Value = row["intIdArtKit"];
                    dgvKit.Rows[rowEscribir].Cells["intIdKit"].Value = row["intIdKit"];
                    dgvKit.Rows[rowEscribir].Cells["intIdArt"].Value = row["intIdArt"];
                    dgvKit.Rows[rowEscribir].Cells["strNoArt"].Value = row["strNoArt"];
                    dgvKit.Rows[rowEscribir].Cells["strCoUni"].Value = row["strCoUni"];
                    dgvKit.Rows[rowEscribir].Cells["decCant"].Value = row["decCant"];
                    dgvKit.Rows[rowEscribir].Cells["decPonderado"].Value = row["decPonderado"];
                    dgvKit.Rows[rowEscribir].Cells["decPU"].Value = row["decPU"];
                }

                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDetReceta(intIdArticulo, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvReceta.Rows.Count;
                    dgvReceta.Rows.Add(1);
                    dgvReceta.Rows[rowEscribir].Cells["intIdArtReceta"].Value = row["intIdArtReceta"];
                    dgvReceta.Rows[rowEscribir].Cells["intIdReceta"].Value = row["intIdReceta"];
                    dgvReceta.Rows[rowEscribir].Cells["intIdArtRec"].Value = row["intIdArt"];
                    dgvReceta.Rows[rowEscribir].Cells["strNoArtRec"].Value = row["strNoArt"];
                    dgvReceta.Rows[rowEscribir].Cells["strCoUniRec"].Value = row["strCoUni"];
                    dgvReceta.Rows[rowEscribir].Cells["decCantRec"].Value = row["decCant"];
                }


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGArticulo objNg = new NGArticulo(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarArticulo(intIdArticulo, ref blnTodoOK);
                //txtIdArticulo.Text = tbl.Rows[0]["intIdArt"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoArt"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoArt"].ToString();
                txtFamilia.Text = tbl.Rows[0]["strNoFamilia"].ToString();
                txtSubFamilia.Text = tbl.Rows[0]["strNoSubFamilia"].ToString();
                idSubFamilia = Convert.ToInt32(tbl.Rows[0]["intIdSubFamilia"]);
                idFamilia = tbl.Rows[0]["intIdFamilia"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdFamilia"]);
                //cbxSubFamilia.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdSubFamilia"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                chkFav.Checked = tbl.Rows[0]["intFav"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intFav"]);
                chkKit.Checked = tbl.Rows[0]["intKit"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intKit"]);
                
                chkReceta.Checked = tbl.Rows[0]["intReceta"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intReceta"]);
                txtComposicion.Text = tbl.Rows[0]["intComposicion"].ToString();
                txtCodAlt.Text = tbl.Rows[0]["strCodAlt"].ToString();
                txtTag.Text = tbl.Rows[0]["strTag"].ToString();
                cbxClaArt.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdClaArt"]);
                txtUnidad.Text = tbl.Rows[0]["strCoUni"].ToString();
                idUnidad = Convert.ToInt32(tbl.Rows[0]["intIdUni"]);

                txtUnidadComp.Text = tbl.Rows[0]["strCoUniComp"].ToString();
                idUnidadComp = tbl.Rows[0]["intIdUniComp"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdUniComp"]);

                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDetKit(intIdArticulo, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvKit.Rows.Count;
                    dgvKit.Rows.Add(1);
                    dgvKit.Rows[rowEscribir].Cells["intIdArtKit"].Value = row["intIdArtKit"];
                    dgvKit.Rows[rowEscribir].Cells["intIdKit"].Value = row["intIdKit"];
                    dgvKit.Rows[rowEscribir].Cells["intIdArt"].Value = row["intIdArt"];
                    dgvKit.Rows[rowEscribir].Cells["strNoArt"].Value = row["strNoArt"];
                    dgvKit.Rows[rowEscribir].Cells["strCoUni"].Value = row["strCoUni"];
                    dgvKit.Rows[rowEscribir].Cells["decCant"].Value = row["decCant"];
                    dgvKit.Rows[rowEscribir].Cells["decPonderado"].Value = row["decPonderado"];
                    dgvKit.Rows[rowEscribir].Cells["decPU"].Value = row["decPU"];
                }

                blnTodoOK = false;
                tbl = new DataTable();
                tbl = objNg.ListarDetReceta(intIdArticulo, ref blnTodoOK);
                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                foreach (DataRow row in tbl.Rows)
                {
                    int rowEscribir = dgvReceta.Rows.Count;
                    dgvReceta.Rows.Add(1);
                    dgvReceta.Rows[rowEscribir].Cells["intIdArtReceta"].Value = row["intIdArtReceta"];
                    dgvReceta.Rows[rowEscribir].Cells["intIdReceta"].Value = row["intIdReceta"];
                    dgvReceta.Rows[rowEscribir].Cells["intIdArtRec"].Value = row["intIdArt"];
                    dgvReceta.Rows[rowEscribir].Cells["strNoArtRec"].Value = row["strNoArt"];
                    dgvReceta.Rows[rowEscribir].Cells["strCoUniRec"].Value = row["strCoUni"];
                    dgvReceta.Rows[rowEscribir].Cells["decCantRec"].Value = row["decCant"];
                }


                btnGuardar.Enabled = false;
                groupBox1.Enabled = false;
                gb2.Enabled = false;
                gb3.Enabled = false;
                
            }
            //cbxFamilia.SelectedIndexChanged += cbxFamilia_SelectedIndexChanged;
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();
            SumaTotal();
            if(chkKit.Checked == true)
            {
                if (TotalPond < 100 || TotalPond > 100) 
                {
                    TotalPond = 0;
                    MessageBox.Show("Total Ponderado debe ser igual a 100.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    return; 
                }
            }
                if (intIdArticulo == 0)
                { //NUEVO
                    if (txtCodigo.Text.Trim() == string.Empty)
                    { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                    if (txtNombre.Text.Trim() == string.Empty)
                    { MessageBox.Show("Ingrese Nombre del Articulo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                    //if (cbxSubFamilia.Text == "")
                    //{ MessageBox.Show("Debe Crear una Sub Familia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                    if (txtUnidad.Text.Trim() == string.Empty)
                    { MessageBox.Show("Seleccione una Unidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                    if (cbxClaArt.Text == "")
                    { MessageBox.Show("Debe Crear una ClaArt.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }

                    if (chkReceta.Checked == true)
                    {
                        InsertarReceta();
                    }
                    else {
                        Insertar();
                    }
                    
                }
                else //Editar
                {
                    if (chkReceta.Checked == true)
                    {
                        EditarReceta();
                    }
                    else
                    {
                        Editar();
                    }
                  
                }
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENArticulo obj = new ENArticulo();
                obj.strCoArt = txtCodigo.Text.Trim();
                obj.strNoArt = txtNombre.Text.Trim();
                obj.intIdSubFamilia = idSubFamilia;
                obj.intIdUni = idUnidad;
                obj.intIdClaArt = Convert.ToInt32(cbxClaArt.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intFav = Convert.ToInt32(chkFav.Checked);
                obj.intKit = Convert.ToInt32(chkKit.Checked);
                obj.intReceta = Convert.ToInt32(chkReceta.Checked);
                obj.intComposicion = (txtComposicion.Text.Trim() == string.Empty) ? 0 : Convert.ToInt32(txtComposicion.Text.Trim());
                obj.intIdUniComp = idUnidadComp;
                obj.strCodAlt = txtCodAlt.Text.Trim();
                obj.strTag = txtTag.Text.Trim();
                obj.intIdUsuCr = idUsuario;

                Negocio.NGArticulo objNg = new Negocio.NGArticulo(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarArticulo(obj, lstENDetKit(), idEmpresa, ref mensaje, ref blnTodoOK);
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!blnTodoOK)
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Articulo guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void InsertarReceta()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENArticulo obj = new ENArticulo();
                obj.strCoArt = txtCodigo.Text.Trim();
                obj.strNoArt = txtNombre.Text.Trim();
                obj.intIdSubFamilia = idSubFamilia;
                obj.intIdUni = idUnidad;
                obj.intIdClaArt = Convert.ToInt32(cbxClaArt.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intFav = Convert.ToInt32(chkFav.Checked);
                obj.intKit = Convert.ToInt32(chkKit.Checked);
                obj.intReceta = Convert.ToInt32(chkReceta.Checked);
                obj.intComposicion = (txtComposicion.Text.Trim() == string.Empty) ? 0 : Convert.ToInt32(txtComposicion.Text.Trim());
                obj.intIdUniComp = idUnidadComp;
                obj.strCodAlt = txtCodAlt.Text.Trim();
                obj.strTag = txtTag.Text.Trim();
                obj.intIdUsuCr = idUsuario;

                Negocio.NGArticulo objNg = new Negocio.NGArticulo(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarArticuloReceta(obj, lstENDetReceta(), idEmpresa, ref mensaje, ref blnTodoOK);
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!blnTodoOK)
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Articulo guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Editar()
        {
            string mensaje = string.Empty;
            bool blnTodoOK = false;
            ENArticulo obj = new ENArticulo();
            obj.intIdArt = intIdArticulo;
            obj.strCoArt = txtCodigo.Text.Trim();
            obj.strNoArt = txtNombre.Text.Trim();
            obj.intIdSubFamilia = idSubFamilia;

            obj.intIdUni = idUnidad;
            obj.intIdUniComp = idUnidadComp;
            
            obj.intIdClaArt = Convert.ToInt32(cbxClaArt.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intFav = Convert.ToInt32(chkFav.Checked);
            obj.intKit = Convert.ToInt32(chkKit.Checked);
            obj.intReceta = Convert.ToInt32(chkReceta.Checked);

            obj.intComposicion = (txtComposicion.Text.Trim() == string.Empty) ? 0 : Convert.ToInt32(txtComposicion.Text.Trim());
            obj.strCodAlt = txtCodAlt.Text.Trim();
            obj.strTag = txtTag.Text.Trim();
            obj.intIdUsuMf = idUsuario;
            Negocio.NGArticulo objNg = new Negocio.NGArticulo(Configuracion.Sistema.CadenaConexion);

            objNg.EditarArticulo(obj, lstENDetKit(), idEmpresa, ref mensaje, ref blnTodoOK);

            if (mensaje != string.Empty)
            { MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!blnTodoOK)
            { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            MessageBox.Show("Se guardó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public void EditarReceta()
        {
            string mensaje = string.Empty;
            bool blnTodoOK = false;
            ENArticulo obj = new ENArticulo();
            obj.intIdArt = intIdArticulo;
            obj.strCoArt = txtCodigo.Text.Trim();
            obj.strNoArt = txtNombre.Text.Trim();
            obj.intIdSubFamilia = idSubFamilia;

            obj.intIdUni = idUnidad;
            obj.intIdUniComp = idUnidadComp;

            obj.intIdClaArt = Convert.ToInt32(cbxClaArt.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intFav = Convert.ToInt32(chkFav.Checked);
            obj.intKit = Convert.ToInt32(chkKit.Checked);
            obj.intReceta = Convert.ToInt32(chkReceta.Checked);

            obj.intComposicion = (txtComposicion.Text.Trim() == string.Empty) ? 0 : Convert.ToInt32(txtComposicion.Text.Trim());
            obj.strCodAlt = txtCodAlt.Text.Trim();
            obj.strTag = txtTag.Text.Trim();
            obj.intIdUsuMf = idUsuario;
            Negocio.NGArticulo objNg = new Negocio.NGArticulo(Configuracion.Sistema.CadenaConexion);

            objNg.EditarArticuloReceta(obj, lstENDetReceta(), idEmpresa, ref mensaje, ref blnTodoOK);

            if (mensaje != string.Empty)
            { MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!blnTodoOK)
            { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            MessageBox.Show("Se guardó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        //public void ListarComboUni()
        //{
        //    bool blnTodoOK = false;
        //    Clases.InicialCls.LeerXml();
        //    DataTable tbl = new DataTable();
        //    NGUnidad obj = new NGUnidad(Configuracion.Sistema.CadenaConexion);
        //    tbl = obj.ComboUnidad(idEmpresa, ref blnTodoOK);
        //    cbxUni.DisplayMember = "strNoUni";
        //    cbxUni.ValueMember = "intIdUni";
        //    cbxUni.DataSource = tbl;

        //}

        public void ListarComboClaArt()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGClaArt obj = new NGClaArt(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ClaArt(ref blnTodoOK);
            cbxClaArt.DisplayMember = "strNoClaArt";
            cbxClaArt.ValueMember = "intIdClaArt";
            cbxClaArt.DataSource = tbl;

        }

        private void txtFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "FAMILIA";
                frm.tipoTabla = "GENERAL";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idFamilia = frm.idEncontrado;
                    txtFamilia.Text = frm.nombreEncontrado;
                    txtSubFamilia.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtFamilia.Clear();
                idFamilia = 0;
                txtSubFamilia.Clear();
                idSubFamilia = 0;
            }
        }

        private void txtSubFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SUBFAMILIA2";
                frm.tipoTabla = "GENERAL";
                frm.intId = idFamilia;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSubFamilia = frm.idEncontrado;
                    txtSubFamilia.Text = frm.nombreEncontrado;
                    //txtSubFamilia.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtSubFamilia.Clear();
                idSubFamilia = 0;
            }
        }

        private void txtUnidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "UNIDAD";
                frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresa;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idUnidad = frm.idEncontrado;
                    txtUnidad.Text = frm.nombreEncontrado;
                    cbxClaArt.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtUnidad.Clear();
                idUnidad = 0;
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Articulo_Detalle frm = new Articulo_Detalle();
            frm.intIdEmp = idEmpresa;
            frm.strAccion = "NUEVO";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.intIdArt > 0)
                {
                    
                    if (frm.decCant > 0)
                    {
                        decimal decNuevoCant = frm.decCant;
                        decimal decNuevoPrecio = frm.decPU;
                        decimal decNuevoPonderado = frm.decPonderado;

                        foreach (DataGridViewRow row in dgvKit.Rows)
                        {
                            int index = row.Index;
                            if (Convert.ToDecimal(row.Cells["intIdArt"].Value) == frm.intIdArt)
                            {
                                if (MessageBox.Show("El Artículo ya se encuentra agregado.¿Desea modificarlo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                else
                                {
                                    dgvKit.Rows[index].Cells["decCant"].Value = decNuevoCant;
                                    dgvKit.Rows[index].Cells["decPonderado"].Value=decNuevoPonderado;
                                    dgvKit.Rows[index].Cells["decPU"].Value = decNuevoPrecio;
                                    return;
                                    
                                }
                            }
                        }

                        int rowEscribir = dgvKit.Rows.Count;
                        dgvKit.Rows.Add(1);
                        dgvKit.Rows[rowEscribir].Cells["intIdArt"].Value = frm.intIdArt;
                        dgvKit.Rows[rowEscribir].Cells["intIdArtKit"].Value = 0;
                        dgvKit.Rows[rowEscribir].Cells["strNoArt"].Value = frm.strNoArt;
                        dgvKit.Rows[rowEscribir].Cells["strCoUni"].Value = frm.strUnidad;
                        dgvKit.Rows[rowEscribir].Cells["decCant"].Value = frm.decCant;
                        dgvKit.Rows[rowEscribir].Cells["decPonderado"].Value = frm.decPonderado;
                        dgvKit.Rows[rowEscribir].Cells["decPU"].Value = frm.decPU;
                        
                    }
                }
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvKit.Rows.Count > 0)
            {
                int index = dgvKit.CurrentRow.Index;
                dgvKit.Rows.RemoveAt(index);
            }
        }

        public List<ENDetKit> lstENDetKit()
        {
            List<ENDetKit> lstDetKit = new List<ENDetKit>();
            foreach (DataRow item in Dgv_DataTable().Rows)
            {
                ENDetKit ENDetKit = new ENDetKit();
                ENDetKit.intIdArt = intIdArticulo;
                ENDetKit.intIdArtKit = Convert.ToInt32(item["intIdArtKit"]);
                ENDetKit.intIdArt = Convert.ToInt32(item["intIdArt"]);
                ENDetKit.decCant = Convert.ToDecimal(item["decCant"]);
                ENDetKit.decPonderado = Convert.ToDecimal(item["decPonderado"]);
                ENDetKit.decPU = Convert.ToDecimal(item["decPU"]);
                ENDetKit.intIdUsuCr = idUsuario;
                ENDetKit.intIdUsuMf = idUsuario;
                lstDetKit.Add(ENDetKit);
            }

            return lstDetKit;
        }

        public List<ENDetReceta> lstENDetReceta()
        {
            List<ENDetReceta> lstDetReceta = new List<ENDetReceta>();
            foreach (DataRow item in Dgv_DataTableReceta().Rows)
            {
                ENDetReceta ENDetReceta = new ENDetReceta();
                ENDetReceta.intIdArt = intIdArticulo;
                ENDetReceta.intIdArtReceta = Convert.ToInt32(item["intIdArtReceta"]);
                ENDetReceta.intIdArt = Convert.ToInt32(item["intIdArtRec"]);
                ENDetReceta.decCant = Convert.ToDecimal(item["decCantRec"]);
                ENDetReceta.intIdUsuCr = idUsuario;
                ENDetReceta.intIdUsuMf = idUsuario;
                lstDetReceta.Add(ENDetReceta);
            }

            return lstDetReceta;
        }

        public DataTable Dgv_DataTable()
        {
            //Pasando de datagridview a datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("intIdArtKit", typeof(System.String));
            dt.Columns.Add("intIdArt", typeof(System.String));
            dt.Columns.Add("strNoArt", typeof(System.String));
            dt.Columns.Add("strCoUni", typeof(System.String));
            dt.Columns.Add("decCant", typeof(System.String));
            dt.Columns.Add("decPonderado", typeof(System.String));
            dt.Columns.Add("decPU", typeof(System.String));

            foreach (DataGridViewRow rowGrid in dgvKit.Rows)
            {
                DataRow row = dt.NewRow();
                row["decCant"] = rowGrid.Cells["decCant"].Value.ToString();
                row["intIdArtKit"] = rowGrid.Cells["intIdArtKit"].Value.ToString();
                row["intIdArt"] = rowGrid.Cells["intIdArt"].Value.ToString();
                row["strNoArt"] = rowGrid.Cells["strNoArt"].Value.ToString();
                row["strCoUni"] = rowGrid.Cells["strCoUni"].Value.ToString();
                row["decPonderado"] = rowGrid.Cells["decPonderado"].Value.ToString();
                row["decPU"] = rowGrid.Cells["decPU"].Value.ToString();
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable Dgv_DataTableReceta()
        {
            //Pasando de datagridview a datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("intIdArtReceta", typeof(System.String));
            dt.Columns.Add("intIdArtRec", typeof(System.String));
            dt.Columns.Add("strNoArtRec", typeof(System.String));
            dt.Columns.Add("strCoUniRec", typeof(System.String));
            dt.Columns.Add("decCantRec", typeof(System.String));

            foreach (DataGridViewRow rowGrid in dgvReceta.Rows)
            {
                DataRow row = dt.NewRow();
                row["decCantRec"] = rowGrid.Cells["decCantRec"].Value.ToString();
                row["intIdArtReceta"] = rowGrid.Cells["intIdArtReceta"].Value.ToString();
                row["intIdArtRec"] = rowGrid.Cells["intIdArtRec"].Value.ToString();
                row["strNoArtRec"] = rowGrid.Cells["strNoArtRec"].Value.ToString();
                row["strCoUniRec"] = rowGrid.Cells["strCoUniRec"].Value.ToString();
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvKit.CurrentRow == null)
            { MessageBox.Show("No Hay Detalles para editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            Articulo_Detalle frm = new Articulo_Detalle();
            frm.intIdEmp = idEmpresa;
            frm.strAccion = "EDITAR";
            frm.intIdArt = Convert.ToInt32(dgvKit.CurrentRow.Cells["intIdArt"].Value);
            frm.strNoArt = dgvKit.CurrentRow.Cells["strNoArt"].Value.ToString();
            frm.strUnidad = dgvKit.CurrentRow.Cells["strCoUni"].Value.ToString();
            frm.decCant = Convert.ToDecimal(dgvKit.CurrentRow.Cells["decCant"].Value);
            frm.decPonderado = Convert.ToDecimal(dgvKit.CurrentRow.Cells["decPonderado"].Value);
            frm.decPU = Convert.ToDecimal(dgvKit.CurrentRow.Cells["decPU"].Value);
            //frm.decTotal = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["decTotal"].Value);
            int index = dgvKit.CurrentRow.Index;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                decimal decNuevoValor = frm.decCant;
                foreach (DataGridViewRow row in dgvKit.Rows)
                {
                    int row_index = row.Index;
                    if (Convert.ToInt32(row.Cells["intIdArt"].Value) == frm.intIdArt)
                    {
                        decNuevoValor = frm.decCant;
                        dgvKit.Rows[row_index].Cells["decCant"].Value = decNuevoValor;
                        dgvKit.Rows[row_index].Cells["decPU"].Value = frm.decPU;
                        dgvKit.Rows[row_index].Cells["decPonderado"].Value = frm.decPonderado;
                        return;
                    }
                }
                dgvKit.Rows[index].Cells["intIdArt"].Value = frm.intIdArt;
                dgvKit.Rows[index].Cells["strNoArt"].Value = frm.strNoArt;
                dgvKit.Rows[index].Cells["strCoUni"].Value = frm.strUnidad;
                dgvKit.Rows[index].Cells["decCant"].Value = frm.decCant;
                dgvKit.Rows[index].Cells["decPU"].Value = frm.decPU;
                dgvKit.Rows[index].Cells["decPonderado"].Value = frm.decPonderado;
            }
        }

        private void SoloNumerosDecimal(object sender, KeyPressEventArgs e)
        {
            // Verificar que la tecla presionada no sea CTRL u otra tecla no numerica
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SumaTotal()
        {
            foreach (DataGridViewRow row in dgvKit.Rows)
            {
                if (Convert.ToDecimal(row.Cells["decPonderado"].Value) > 0)
                    TotalPond += Convert.ToDecimal(row.Cells["decPonderado"].Value);
            }
        }

        private void txtUnidadComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "UNIDAD";
                frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresa;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idUnidadComp = frm.idEncontrado;
                    txtUnidadComp.Text = frm.nombreEncontrado;
                    
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtUnidadComp.Clear();
                idUnidadComp = 0;

            }
        }

        private void chkReceta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceta.Checked == true)
            {
                panelGrid2.Visible = true;
                panelGrid.Visible = false;
                chkKit.Checked = false;
                this.Size = new Size(this.Size.Width, 570);
            }
            else
            {
                panelGrid2.Visible = false;
                this.Size = new Size(this.Size.Width, 320);
            }
        }

        private void chkKit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKit.Checked == true)
            {
                panelGrid.Visible = true;
                panelGrid2.Visible = false;
                chkReceta.Checked = false;
                this.Size = new Size(this.Size.Width, 570);
            }
            else
            {
                panelGrid.Visible = false;
                this.Size = new Size(this.Size.Width, 320);
            }
        }

        private void paneles()
        {
            if (chkKit.Checked == true)
            {
                panelGrid.Visible = true;
                this.Size = new Size(this.Size.Width, 570);
            }
            else
            {
                panelGrid.Visible = false;
                this.Size = new Size(this.Size.Width, 320);
            }
            if (chkReceta.Checked == true)
            {
                panelGrid2.Visible = true;
                this.Size = new Size(this.Size.Width, 570);
            }
            else
            {
                panelGrid2.Visible = false;
                this.Size = new Size(this.Size.Width, 320);
            }
        }

        private void btnAgregarReceta_Click(object sender, EventArgs e)
        {
            Articulo_DetalleReceta frm = new Articulo_DetalleReceta();
            frm.intIdEmp = idEmpresa;
            frm.strAccion = "NUEVO";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.intIdArt > 0)
                {

                    if (frm.decCant > 0)
                    {
                        decimal decNuevoCant = frm.decCant;

                        foreach (DataGridViewRow row in dgvKit.Rows)
                        {
                            int index = row.Index;
                            if (Convert.ToDecimal(row.Cells["intIdArt"].Value) == frm.intIdArt)
                            {
                                if (MessageBox.Show("El Artículo ya se encuentra agregado.¿Desea modificarlo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                else
                                {
                                    dgvReceta.Rows[index].Cells["decCant"].Value = decNuevoCant;
                                    return;

                                }
                            }
                        }

                        int rowEscribir = dgvReceta.Rows.Count;
                        dgvReceta.Rows.Add(1);
                        dgvReceta.Rows[rowEscribir].Cells["intIdArtRec"].Value = frm.intIdArt;
                        dgvReceta.Rows[rowEscribir].Cells["intIdArtReceta"].Value = 0;
                        dgvReceta.Rows[rowEscribir].Cells["strNoArtRec"].Value = frm.strNoArt;
                        dgvReceta.Rows[rowEscribir].Cells["strCoUniRec"].Value = frm.strUnidad;
                        dgvReceta.Rows[rowEscribir].Cells["decCantRec"].Value = frm.decCant;

                    }
                }
            }
        }

        private void btnEditarReceta_Click(object sender, EventArgs e)
        {
            if (dgvReceta.CurrentRow == null)
            { MessageBox.Show("No Hay Detalles para editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            Articulo_DetalleReceta frm = new Articulo_DetalleReceta();
            frm.intIdEmp = idEmpresa;
            frm.strAccion = "EDITAR";
            frm.intIdArt = Convert.ToInt32(dgvReceta.CurrentRow.Cells["intIdArtRec"].Value);
            frm.strNoArt = dgvReceta.CurrentRow.Cells["strNoArtRec"].Value.ToString();
            frm.strUnidad = dgvReceta.CurrentRow.Cells["strCoUniRec"].Value.ToString();
            frm.decCant = Convert.ToDecimal(dgvReceta.CurrentRow.Cells["decCantRec"].Value);
            //frm.decTotal = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["decTotal"].Value);
            int index = dgvReceta.CurrentRow.Index;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                decimal decNuevoValor = frm.decCant;
                foreach (DataGridViewRow row in dgvReceta.Rows)
                {
                    int row_index = row.Index;
                    if (Convert.ToInt32(row.Cells["intIdArtRec"].Value) == frm.intIdArt)
                    {
                        decNuevoValor = frm.decCant;
                        dgvReceta.Rows[row_index].Cells["decCantRec"].Value = decNuevoValor;
                        return;
                    }
                }
                dgvReceta.Rows[index].Cells["intIdArtRec"].Value = frm.intIdArt;
                dgvReceta.Rows[index].Cells["strNoArtRec"].Value = frm.strNoArt;
                dgvReceta.Rows[index].Cells["strCoUniRec"].Value = frm.strUnidad;
                dgvReceta.Rows[index].Cells["decCantRec"].Value = frm.decCant;
            }
        }

        private void btnQuitarReceta_Click(object sender, EventArgs e)
        {
            if (dgvReceta.Rows.Count > 0)
            {
                int index = dgvReceta.CurrentRow.Index;
                dgvReceta.Rows.RemoveAt(index);
            }
        }
    }
}
