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
    public partial class OpeLog : Form
    {
        public int intIdOpeLog;
        public int tipo;
        public int idUsuario;
        public int idEmpresa;
        public int intIdTransOpe;


        public OpeLog()
        {
            InitializeComponent();
        }

        private void OpeLog_Load(object sender, EventArgs e)
        {
            ListarComboTipoOpe();
            //ListarComboOpeLog();
                if (chkTrans.Checked == true || chkTransforma.Checked == true)
                {
                    txtTransOpe.Visible = true;
                    lblCodigo.Visible = true;
                    label4.Visible = true;
                }
                else
                {
                    txtTransOpe.Visible = false;
                    lblCodigo.Visible = false;
                    label4.Visible = false;
                }
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGOpeLog objNg = new Negocio.NGOpeLog(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarOpeLog(intIdOpeLog, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdOpeLog"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoOpeLog"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoOpeLog"].ToString();
                cbxTipo.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTipo"]);
                chkEstado.Checked = tbl.Rows[0]["intEstado"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                chkTrans.Checked = tbl.Rows[0]["intTransAut"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intTransAut"]);
                chkTransforma.Checked = tbl.Rows[0]["intTransformar"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intTransformar"]);
                chkCompra.Checked = tbl.Rows[0]["intCompra"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intCompra"]);
                intIdTransOpe = Convert.ToInt32(tbl.Rows[0]["intIdTransOpe"]);
                txtTransOpe.Text = tbl.Rows[0]["strNoTransOpe"].ToString();
                lblCodigo.Text = tbl.Rows[0]["strCoTransOpe"].ToString();
                
                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGOpeLog objNg = new Negocio.NGOpeLog(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarOpeLog(intIdOpeLog, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdOpeLog"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoOpeLog"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoOpeLog"].ToString();
                

                cbxTipo.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTipo"]);
                chkEstado.Checked = tbl.Rows[0]["intEstado"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                chkTrans.Checked = tbl.Rows[0]["intTransAut"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intTransAut"]);
                chkTransforma.Checked = tbl.Rows[0]["intTransformar"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intTransformar"]);
                chkCompra.Checked = tbl.Rows[0]["intCompra"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intCompra"]);
                txtTransOpe.Text = tbl.Rows[0]["strNoTransOpe"].ToString();
                lblCodigo.Text = tbl.Rows[0]["strCoTransOpe"].ToString();

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtTransOpe.Enabled = false;
                cbxTipo.Enabled = false;
                chkEstado.Enabled = false;
                chkTrans.Enabled = false;
                chkTransforma.Enabled = false;
                chkCompra.Enabled = false;


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdOpeLog == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la OpeLog.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (chkTrans.Checked == true || chkTransforma.Checked == true)
                {
                    if (txtTransOpe.Text.Trim() == string.Empty)
                    { MessageBox.Show("Ingrese Operacion de transferencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtTransOpe.Focus(); return; }

                    Insertar2();
                }
                else {
                    Insertar();
                }
                
            }
            else //Editar
            {
                if (chkTrans.Checked == true || chkTransforma.Checked == true)
                {
                    if (txtTransOpe.Text.Trim() == string.Empty)
                    { MessageBox.Show("Ingrese Operacion de transferencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtTransOpe.Focus(); return; }

                    Editar2();
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

        public void ListarComboTipoOpe()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGTipoOpe obj = new NGTipoOpe(Configuracion.Sistema.CadenaConexion);
            tbl = obj.TipoOpeCombo(ref blnTodoOK);
            cbxTipo.DisplayMember = "strNoTipoOpe";
            cbxTipo.ValueMember = "intIdTipoOpe";
            cbxTipo.DataSource = tbl;

        }

        //public void ListarComboOpeLog()
        //{
        //    bool blnTodoOK = false;
        //    Clases.InicialCls.LeerXml();
        //    DataTable tbl = new DataTable();
        //    NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
        //    tbl = obj.OpeLogCombo(ref blnTodoOK);
        //    cbxOtro.DisplayMember = "strNoOpeLog";
        //    cbxOtro.ValueMember = "intIdOpeLog";
        //    cbxOtro.DataSource = tbl;

        //}

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENOpeLog obj = new ENOpeLog();
                obj.strCoOpeLog = txtCodigo.Text.Trim();
                obj.strNoOpeLog = txtNombre.Text.Trim();
                obj.intIdTipo = Convert.ToInt32(cbxTipo.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intTransAut = Convert.ToInt32(chkTrans.Checked);
                obj.intCompra = Convert.ToInt32(chkCompra.Checked);
                obj.intTransformar = Convert.ToInt32(chkTransforma.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGOpeLog objNg = new Negocio.NGOpeLog(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarOpeLog(obj, ref mensaje, ref blnTodoOK);

                if (!blnTodoOK)
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Operación Logistica guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Insertar2()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENOpeLog obj = new ENOpeLog();
                obj.strCoOpeLog = txtCodigo.Text.Trim();
                obj.strNoOpeLog = txtNombre.Text.Trim();
                obj.intIdTipo = Convert.ToInt32(cbxTipo.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intTransAut = Convert.ToInt32(chkTrans.Checked);
                obj.intTransformar = Convert.ToInt32(chkTransforma.Checked);
                obj.intCompra = Convert.ToInt32(chkCompra.Checked);
                obj.intIdTransOpe = intIdTransOpe;
                obj.intIdUsuCr = idUsuario;

                Negocio.NGOpeLog objNg = new Negocio.NGOpeLog(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarOpeLog2(obj, ref mensaje, ref blnTodoOK);

                if (!blnTodoOK)
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Operación Logistica guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            bool blnTodoOK = false;
            ENOpeLog obj = new ENOpeLog();
            obj.intIdOpeLog = intIdOpeLog;
            obj.strCoOpeLog = txtCodigo.Text.Trim();
            obj.strNoOpeLog = txtNombre.Text.Trim();
            obj.intIdTipo = Convert.ToInt32(cbxTipo.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intTransAut = Convert.ToInt32(chkTrans.Checked);
            obj.intCompra = Convert.ToInt32(chkCompra.Checked);
            obj.intIdTransOpe = 0;
            obj.intTransformar = Convert.ToInt32(chkTransforma.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGOpeLog objNg = new Negocio.NGOpeLog(Configuracion.Sistema.CadenaConexion);

            objNg.EditarOpeLog(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("OpeLog Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        public void Editar2()
        {

            bool blnTodoOK = false;
            ENOpeLog obj = new ENOpeLog();
            obj.intIdOpeLog = intIdOpeLog;
            obj.strCoOpeLog = txtCodigo.Text.Trim();
            obj.strNoOpeLog = txtNombre.Text.Trim();
            obj.intIdTipo = Convert.ToInt32(cbxTipo.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intTransAut = Convert.ToInt32(chkTrans.Checked);
            obj.intTransformar = Convert.ToInt32(chkTransforma.Checked);
            obj.intCompra = Convert.ToInt32(chkCompra.Checked);
            obj.intIdTransOpe = intIdTransOpe;
            obj.intIdUsuMf = idUsuario;

            Negocio.NGOpeLog objNg = new Negocio.NGOpeLog(Configuracion.Sistema.CadenaConexion);

            objNg.EditarOpeLog2(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("OpeLog Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void chkTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrans.Checked == true)
            {
                chkTransforma.Checked = false;
                chkCompra.Checked = false;
                txtTransOpe.Visible = false;
                label4.Visible = false;
                lblCodigo.Visible = false;

                txtTransOpe.Visible = true;
                label4.Visible = true;
                lblCodigo.Visible = true;

                
            }
            else
            {
                txtTransOpe.Visible = false;
                label4.Visible = false;
                lblCodigo.Visible = false;
                //chkTransforma.Checked = true;
            }
        }

        private void txtTransOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "OPELOG";
                //frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresa;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    intIdTransOpe = frm.idEncontrado;
                    txtTransOpe.Text = frm.nombreEncontrado;
                    lblCodigo.Text = frm.codigoEncontrado;
                   
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                intIdOpeLog = 0;
                txtTransOpe.Text = " ";
                lblCodigo.Text = "";
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void chkTransforma_CheckedChanged(object sender, EventArgs e)
        {
                if (chkTransforma.Checked == true)
                {
                    txtTransOpe.Visible = false;
                    label4.Visible = false;
                    lblCodigo.Visible = false;
                    chkTrans.Checked = false;
                    chkCompra.Checked = false;

                    txtTransOpe.Visible = true;
                    label4.Visible = true;
                    lblCodigo.Visible = true;
                }
                else
                {
                    txtTransOpe.Visible = false;
                    label4.Visible = false;
                    lblCodigo.Visible = false;
                    //chkTrans.Checked = true;
                }
        }

        private void chkCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompra.Checked == true)
            {
                txtTransOpe.Visible = false;
                label4.Visible = false;
                lblCodigo.Visible = false;
                chkTrans.Checked = false;
                chkTransforma.Checked = false;

               
            }
            else
            {
                txtTransOpe.Visible = false;
                label4.Visible = false;
                lblCodigo.Visible = false;
                //chkTrans.Checked = true;
            }
        }

        
    }
}
