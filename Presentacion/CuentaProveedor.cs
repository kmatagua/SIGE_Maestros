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
    public partial class CuentaProveedor : Form
    {
        public int intIdCuentaProveedor;
        public int tipo;
              
        public int idUsuario;
        public int idEmpresa;

        public int idProveedor;
        public int idBanco;
        public int idMoneda;

        public CuentaProveedor()
        {
            InitializeComponent();
        }


        private void CuentaProveedor_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGCuentaProveedor objNg = new NGCuentaProveedor(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarCuentaProveedor(intIdCuentaProveedor, ref blnTodoOK);

                idProveedor = Convert.ToInt32(tbl.Rows[0]["intIdProv"]);
                txtProveedor.Text = tbl.Rows[0]["strRazSoc"].ToString();

                idBanco = Convert.ToInt32(tbl.Rows[0]["intIdBancos"]);
                txtBanco.Text = tbl.Rows[0]["strNoBancos"].ToString();

                idMoneda = Convert.ToInt32(tbl.Rows[0]["intIdMoneda"]);
                txtMoneda.Text = tbl.Rows[0]["strCoMoneda"].ToString();

                txtNumero.Text = tbl.Rows[0]["strNroCuenta"].ToString();

                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGCuentaProveedor objNg = new NGCuentaProveedor(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarCuentaProveedor(intIdCuentaProveedor, ref blnTodoOK);

                txtProveedor.Text = tbl.Rows[0]["strRazSoc"].ToString();
                txtBanco.Text = tbl.Rows[0]["strNoBancos"].ToString();
                txtMoneda.Text = tbl.Rows[0]["strCoMoneda"].ToString();
                txtNumero.Text = tbl.Rows[0]["strNroCuenta"].ToString();

                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                txtProveedor.Enabled = false;
                txtBanco.Enabled = false;
                txtMoneda.Enabled = false;
                txtNumero.Enabled = false;
                chkEstado.Enabled = false;

                btnGuardar.Visible = false;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdCuentaProveedor == 0)
            { //NUEVO
                if (txtProveedor.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Proveedor al que desea agregar un numero de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtProveedor.Focus(); return; }
                if (txtBanco.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Banco al que pertenece el numero de cuenta que desea agregar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtBanco.Focus(); return; }
                if (txtNumero.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese un numero de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtNumero.Focus(); return; }
                if (txtMoneda.Text.Trim() == string.Empty)
                { MessageBox.Show("El campo de moneda no debe estár vacío.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtMoneda.Focus(); return; }
                Insertar();
            }
            else //Editar
            {
                if (txtProveedor.Text.Trim() == string.Empty)
                { MessageBox.Show("El campo Proveedor no debe estar vacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtProveedor.Focus(); return; }
                if (txtBanco.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Banco al que pertenece el numero de cuenta que desea agregar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtBanco.Focus(); return; }
                if (txtNumero.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese un numero de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtNumero.Focus(); return; }
                if (txtMoneda.Text.Trim() == string.Empty)
                { MessageBox.Show("El campo de moneda no debe estár vacío.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtMoneda.Focus(); return; }
                Editar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Funciones

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENCuentaProveedor obj = new ENCuentaProveedor();
                obj.intIdProveedor = idProveedor;
                obj.intIdBanco = idBanco;
                obj.strNroCuenta = txtNumero.Text.Trim();
                obj.intIdMoneda = idMoneda;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGCuentaProveedor objNg = new Negocio.NGCuentaProveedor(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarCuentaProveedor(obj, ref mensaje, ref blnTodoOK);
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
                    MessageBox.Show("CuentaProveedor guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENCuentaProveedor obj = new ENCuentaProveedor();
            obj.intIdCuentas = intIdCuentaProveedor;
            obj.intIdProveedor = idProveedor;
            obj.intIdBanco = idBanco;
            obj.strNroCuenta = txtNumero.Text.Trim();
            obj.intIdMoneda = idMoneda;
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            Negocio.NGCuentaProveedor objNg = new Negocio.NGCuentaProveedor(Configuracion.Sistema.CadenaConexion);

            objNg.EditarCuentaProveedor(obj, ref mensaje, ref blnTodoOK);
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
                MessageBox.Show("CuentaProveedor Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        #endregion

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "PROVEEDOR";
                frm.tipoTabla = "PROVEEDOR";
                frm.idEmpresa = idEmpresa;
                //frm.intIdUsu = intIdUsu;
                //frm.intId = idOperacion;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idProveedor = frm.idEncontrado;
                    txtProveedor.Text = frm.nombreEncontrado;
                    ////txtAlmacen.Text = frm.nombreEncontrado;
                    txtBanco.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idProveedor = 0;
                txtProveedor.Text = " ";
                txtProveedor.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "BANCO";
                frm.tipoTabla = "BANCO";
                //frm.idEmpresa = idEmpresa;
                //frm.intIdUsu = intIdUsu;
                //frm.intId = idOperacion;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idBanco = frm.idEncontrado;
                    txtBanco.Text = frm.nombreEncontrado;
                    ////txtAlmacen.Text = frm.nombreEncontrado;
                    txtNumero.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idBanco = 0;
                txtBanco.Text = " ";
                txtBanco.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "MONEDA";
                frm.tipoTabla = "MONEDA";
                //frm.idEmpresa = idEmpresa;
                //frm.intIdUsu = intIdUsu;
                //frm.intId = idOperacion;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idMoneda = frm.idEncontrado;
                    txtMoneda.Text = frm.codigoEncontrado;
                    ////txtAlmacen.Text = frm.nombreEncontrado;
                    //txtSerie.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idMoneda = 0;
                txtMoneda.Text = " ";
                txtMoneda.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

    }
}
