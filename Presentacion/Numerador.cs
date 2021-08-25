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
    public partial class Numerador : Form
    {
        public int intIdNumerador;
        public int tipo;
              
        public int idUsuario;
        public int idEmpresa;
        public int idEmpresaBuscada;
        public int idSede;
        public int idAlmacen;
        public int idTipoDoc;
        public int idOperacion;
        public int idTipoOpe;
        public int idSubTipoOpe;

        public Numerador()
        {
            InitializeComponent();
        }

        private void Numerador_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGNumerador objNg = new NGNumerador(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarNumerador(intIdNumerador, ref blnTodoOK);

                idEmpresaBuscada = Convert.ToInt32(tbl.Rows[0]["intIdEmp"]);
                txtEmpresa.Text = tbl.Rows[0]["strNoEmp"].ToString();

                idSede = Convert.ToInt32(tbl.Rows[0]["intIdSede"]);
                txtSede.Text = tbl.Rows[0]["strNoSede"].ToString();

                idAlmacen = Convert.ToInt32(tbl.Rows[0]["intIdAlm"]);
                txtAlmacen.Text = tbl.Rows[0]["strNoAlm"].ToString();

                idTipoDoc = Convert.ToInt32(tbl.Rows[0]["intIdTipDoc"]);
                txtTipoDoc.Text = tbl.Rows[0]["strNoTipDoc"].ToString();

                idOperacion = Convert.ToInt32(tbl.Rows[0]["intIdOperacion"]);
                txtOperacion.Text = tbl.Rows[0]["strNoOperacion"].ToString();

                idTipoOpe = Convert.ToInt32(tbl.Rows[0]["intIdTipoOpe"]);
                txtTipoOpe.Text = tbl.Rows[0]["strNoTipoOpe"].ToString();

                idSubTipoOpe = Convert.ToInt32(tbl.Rows[0]["intIdSubTipoOpe"]);
                txtSubTipoOpe.Text = tbl.Rows[0]["strNoSubTipoOpe"].ToString();
                


                txtSerie.Text = tbl.Rows[0]["strSerie"].ToString();
                txtNumero.Text = tbl.Rows[0]["strNumero"].ToString();
                txtObservacion.Text = tbl.Rows[0]["strObservacion"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGNumerador objNg = new NGNumerador(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarNumerador(intIdNumerador, ref blnTodoOK);

                txtEmpresa.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtAlmacen.Text = tbl.Rows[0]["strNoAlm"].ToString();
                txtSede.Text = tbl.Rows[0]["strNoSede"].ToString();
                txtTipoDoc.Text = tbl.Rows[0]["strNoTipDoc"].ToString();
                txtOperacion.Text = tbl.Rows[0]["strNoOperacion"].ToString();
                txtTipoOpe.Text = tbl.Rows[0]["strNoTipoOpe"].ToString();
                txtSubTipoOpe.Text = tbl.Rows[0]["strNoSubTipoOpe"].ToString();
                txtSerie.Text = tbl.Rows[0]["strSerie"].ToString();
                txtNumero.Text = tbl.Rows[0]["strNumero"].ToString();
                txtObservacion.Text = tbl.Rows[0]["strObservacion"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                txtEmpresa.Enabled = false;
                txtSede.Enabled = false;
                txtAlmacen.Enabled = false;
                txtTipoDoc.Enabled = false;
                txtOperacion.Enabled = false;
                txtTipoOpe.Enabled = false;
                txtSubTipoOpe.Enabled = false;
                txtSerie.Enabled = false;
                txtNumero.Enabled = false;
                chkEstado.Enabled = false;
                txtObservacion.Enabled = false;
                btnGuardar.Visible = false;



            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdNumerador == 0)
            { //NUEVO
                if (txtEmpresa.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtEmpresa.Focus(); return; }
                
                Insertar();
            }
            else //Editar
            {
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
                ENNumerador obj = new ENNumerador();
                obj.intIdEmp = idEmpresaBuscada;
                obj.intIdSede = idSede;
                obj.intIdAlm = idAlmacen;
                obj.intIdTipDoc = idTipoDoc;
                obj.intIdOperacion = idOperacion;
                obj.intIdTipoOpe = idTipoOpe;
                obj.intIdSubTipoOpe = idSubTipoOpe;
                obj.strSerie = txtSerie.Text.Trim();
                obj.strNumero = txtNumero.Text.Trim();
                obj.strObservacion = txtObservacion.Text.Trim();
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGNumerador objNg = new Negocio.NGNumerador(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarNumerador(obj, ref mensaje, ref blnTodoOK);
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
                    MessageBox.Show("Numerador guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENNumerador obj = new ENNumerador();
            obj.intIdNum = intIdNumerador;
            obj.intIdEmp = idEmpresaBuscada;
            obj.intIdSede = idSede;
            obj.intIdAlm = idAlmacen;
            obj.intIdTipDoc = idTipoDoc;
            obj.intIdOperacion = idOperacion;
            obj.intIdTipoOpe = idTipoOpe;
            obj.intIdSubTipoOpe = idSubTipoOpe;
            obj.strSerie = txtSerie.Text.Trim();
            obj.strNumero = txtNumero.Text.Trim();
            obj.strObservacion = txtObservacion.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            Negocio.NGNumerador objNg = new Negocio.NGNumerador(Configuracion.Sistema.CadenaConexion);

            objNg.EditarNumerador(obj, ref mensaje, ref blnTodoOK);
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
                MessageBox.Show("Numerador Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        #endregion

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "EMPRESA";
                //frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                frm.intIdUsu = idUsuario;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idEmpresaBuscada = frm.idEncontrado;
                    txtEmpresa.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtSede.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idEmpresaBuscada = 0;
                txtEmpresa.Text = " ";
                idAlmacen = 0;
                txtAlmacen.Text = " ";
                idTipoDoc = 0;
                txtTipoDoc.Text = " ";
                txtEmpresa.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "ALMACEN_NUMERADOR";
                frm.tipoTabla = "GENERAL";
                frm.intId = idSede;
                frm.intIdUsu = idUsuario;
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idAlmacen = frm.idEncontrado;
                    txtAlmacen.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtTipoDoc.Focus();
                }
                
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idAlmacen = 0;
                txtAlmacen.Text = " ";
                txtTipoDoc.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtTipoDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "TIPODOC";
                //frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresaBuscada;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idTipoDoc = frm.idEncontrado;
                    txtTipoDoc.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtTipoOpe.Focus();
                }
               
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idTipoDoc = 0;
                txtTipoDoc.Text = " ";
                txtTipoOpe.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }
        
        private void txtTipoOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "TIPOOPE";
                //frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idTipoOpe = frm.idEncontrado;
                    txtTipoOpe.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtOperacion.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idTipoOpe = 0;
                txtTipoOpe.Text = " ";
                txtOperacion.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtOperacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "OPERACION";
                //frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresaBuscada;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idOperacion = frm.idEncontrado;
                    txtOperacion.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtSubTipoOpe.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idOperacion = 0;
                txtOperacion.Text = " ";
                idSubTipoOpe = 0;
                txtSubTipoOpe.Text = "";
                txtSubTipoOpe.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtSubTipoOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SUBTIPOOPE";
                //frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresaBuscada;
                //frm.intIdUsu = intIdUsu;
                frm.intId = idOperacion;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSubTipoOpe = frm.idEncontrado;
                    txtSubTipoOpe.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtSerie.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idSubTipoOpe = 0;
                txtSubTipoOpe.Text = " ";
                txtSerie.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtSede_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SEDE_ALM_USU2";
                frm.tipoTabla = "GENERAL";
                frm.idEmpresa = idEmpresaBuscada;
                frm.intIdUsu = idUsuario;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSede = frm.idEncontrado;
                    txtSede.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtAlmacen.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idSede = 0;
                txtSede.Text = " ";
                txtAlmacen.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

    }
}
