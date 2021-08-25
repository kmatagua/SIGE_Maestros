using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Direccion : Form
    {
        public int idCliente;
        public string codigoCliente;
        public string nombreCliente;

        public int idDireccion;
        public int idCalle;
        public int idTipoDep;
        public int idUrbanismo;
        public int idEtapa;
        public int idUbigeo;

        public string strAccion;

        public Direccion()
        {
            InitializeComponent();
        }

        private void Direccion_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = codigoCliente;
            txtNombre.Text = nombreCliente;
            if(strAccion == "EDITAR")
            {
                string nombreDepartamento = string.Empty;
                string nombreProvincia = string.Empty;
                bool blnTodoOK = false;
                Clases.InicialCls.LeerXml();
                Negocio.NGComun obj = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);
                obj.ListaUbigeo(idUbigeo, ref nombreDepartamento, ref nombreProvincia, ref blnTodoOK);
                txtDepartamento.Text = nombreDepartamento;
                txtProvincia.Text = nombreProvincia;
                actualizaDireccion();
            }
        }
      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region F1

        private void txtCalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "CALLE";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idCalle = frm.idEncontrado;
                    txtCalle.Text = frm.codigoEncontrado;
                    txtNomCalle.Focus();
                    //actualizaDireccion();

                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            
            }
        }

        private void txtDpto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "TIPODEP";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idTipoDep = frm.idEncontrado;
                    txtDpto.Text = frm.codigoEncontrado;
                    txtNomDpto.Focus();

                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void txtUrbanismo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "URBANISMO";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idUrbanismo = frm.idEncontrado;
                    txtUrbanismo.Text = frm.codigoEncontrado;
                    txtNomUrbanismo.Focus();

                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtEtapa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SECTOR";
                frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idEtapa = frm.idEncontrado;
                    txtEtapa.Text = frm.codigoEncontrado;
                    txtSector.Focus();

                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtUbigeo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "UBIGEO";
                frm.tipoTabla = "UBIGEO";
                //frm.intId = intIdEmp;
                //frm.intIdUsu = intIdUsu;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idUbigeo = frm.idEncontrado;
                    txtUbigeo.Text = frm.codigoEncontrado;
                    txtDistrito.Text = frm.nombreEncontrado;
                    txtProvincia.Text = frm.nombreProvincia;
                    txtDepartamento.Text = frm.nombreDepartamento;

                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        #endregion

        private void actualizaDireccion()
        {
            txtDireccion.Text = txtCalle.Text.Trim() + ' ';
            txtDireccion.Text = txtDireccion.Text + txtNomCalle.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtNro.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtPabellon.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtMz.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtLote.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtDpto.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtNomDpto.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtUrbanismo.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtNomUrbanismo.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtEtapa.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtSector.Text.Trim() + " ";
            //txtDireccion.Text = txtDireccion.Text + txtUbigeo.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtDistrito.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtProvincia.Text.Trim() + " ";
            txtDireccion.Text = txtDireccion.Text + txtDepartamento.Text.Trim();
        }

        #region DEJAR FOCO DE TEXTBOX
        private void txtCalle_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtNomCalle_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtNro_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtPabellon_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtMz_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtLote_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtDpto_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtNomDpto_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtUrbanismo_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtNomUrbanismo_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtEtapa_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtSector_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }

        private void txtUbigeo_Leave(object sender, EventArgs e)
        {
            actualizaDireccion();
        }
        #endregion


    }
}
