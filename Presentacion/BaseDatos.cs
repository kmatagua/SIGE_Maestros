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
    public partial class BaseDatos : Form
    {
        #region Variables y Constantes

        private bool blnParamGrabados;
        private bool booExiste;

        #endregion

        public BaseDatos()
        {
            InitializeComponent();
        }

        private void BaseDatos_Load(object sender, EventArgs e)
        {
            string cc = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
            this.blnParamGrabados = false; this.booExiste = false;
            try
            {
                this.tsmiGrabar.Enabled = false;
                if (Configuracion.Sistema.CadenaConexion != string.Empty)
                {
                    if (System.IO.File.Exists(cc) == true)
                    {
                        Clases.InicialCls.LeerXml();
                        this.txtServidor.Text = Configuracion.Sistema.ServidorSQL;
                        this.txtBaseDatos.Text = Configuracion.Sistema.BaseDatosSQL;

                        string vUsuario = Configuracion.Sistema.UsuarioSQL;
                        string vContrasenia = Configuracion.Sistema.PasswordSQL;

                        if (vUsuario == "" || vContrasenia == "")
                        {
                            this.rbtnSQL.Checked = false;
                            this.rbtnWindows.Checked = true;
                        }
                        else
                        {
                            this.rbtnSQL.Checked = true;
                            this.rbtnWindows.Checked = false;
                            this.txtUsuario.Text = Configuracion.Sistema.UsuarioSQL;
                            this.txtContrasenia.Text = Configuracion.Sistema.PasswordSQL;
                        }

                        this.booExiste = true;
                    }
                    else
                    {
                        MessageBox.Show("No se ha conectado a una Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmiProbar_Click(object sender, EventArgs e)
        {
            this.ProbarConexion();
        }

        private void tsmiGrabar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void tsmiCerrar_Click(object sender, EventArgs e)
        {
            string strCC = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
            if (System.IO.File.Exists(strCC) == false)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        #region Metodos y Procedimientos

        private void ProbarConexion()
        {
            bool pAutenticacion = true;

            if (rbtnSQL.Checked)
            {
                pAutenticacion = true;
            }
            if (rbtnWindows.Checked)
            {
                pAutenticacion = false;
            }

            Int32 devFocus = 0;
            if (Configuracion.Libreria.Probar_Conexion(this.txtServidor.Text, this.txtBaseDatos.Text, this.txtUsuario.Text, this.txtContrasenia.Text, this.Text, 1, pAutenticacion, ref devFocus) == true)
            {
                MessageBox.Show("Prueba de conexión a la Base de Datos " + this.txtBaseDatos.Text.Trim() + " satisfactoria.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tsmiGrabar.Enabled = true;
            }
            else
            {
                this.tsmiGrabar.Enabled = false;
                switch (devFocus)
                {
                    case 1:
                        this.txtServidor.Focus();
                        break;
                    case 2:
                        this.txtBaseDatos.Focus();
                        break;
                    case 3:
                        this.txtUsuario.Focus();
                        break;
                    case 4:
                        this.txtContrasenia.Focus();
                        break;
                }
            }
        }

        private void Aceptar()
        {
            try
            {
                if (this.txtServidor.Text != string.Empty & this.txtBaseDatos.Text != string.Empty | this.txtUsuario.Text != string.Empty | this.txtContrasenia.Text != string.Empty)
                {
                    int devFoco = 0;
                    bool pAutenticacion = true;

                    if (rbtnSQL.Checked)
                    {
                        pAutenticacion = true;
                    }
                    if (rbtnWindows.Checked)
                    {
                        pAutenticacion = false;
                    }

                    if (Configuracion.Libreria.Probar_Conexion(this.txtServidor.Text, this.txtBaseDatos.Text, this.txtUsuario.Text, this.txtContrasenia.Text, this.Text, 0, pAutenticacion, ref devFoco) == true)
                    {
                        string strCC = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
                        if (System.IO.File.Exists(strCC) == false)
                        {
                            Presentacion.Clases.InicialCls.CrearXml();
                        }
                        //if (this.booExiste == false)
                        //{
                        //    ModuloPC.Clases.InicialCls.CrearXml();
                        //}
                        Configuracion.Sistema.SistOperativoPDA = "0";
                        Configuracion.Sistema.Impresora = string.Empty;
                        Configuracion.Sistema.RutaFormatos = string.Empty;
                        Configuracion.Sistema.ServidorSQL = this.txtServidor.Text;
                        Configuracion.Sistema.BaseDatosSQL = this.txtBaseDatos.Text;
                        Configuracion.Sistema.UsuarioSQL = this.txtUsuario.Text;
                        Configuracion.Sistema.PasswordSQL = this.txtContrasenia.Text;
                        Configuracion.Sistema.TipoDeConexion = "0";
                        Configuracion.Sistema.CadenaConexion = Configuracion.Libreria.RetornarCadenaConexion(Configuracion.Sistema.ServidorSQL, Configuracion.Sistema.BaseDatosSQL, Configuracion.Sistema.UsuarioSQL, Configuracion.Sistema.PasswordSQL);

                        Presentacion.Clases.InicialCls.ActualizarXml();
                        this.blnParamGrabados = true;
                        this.tsmiCerrar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Los Parámetros son Incorrectos, Grabación cancelada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        this.tsmiGrabar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Debe Ingresar los Parametros Mínimos de Conexión a la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    this.txtServidor.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void rbtnWindows_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUsuario.Enabled = false;
            this.txtContrasenia.Enabled = false;
            this.txtUsuario.Text = string.Empty;
            this.txtContrasenia.Text = string.Empty;
        }

        private void rbtnSQL_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUsuario.Enabled = true;
            this.txtContrasenia.Enabled = true;
            this.txtUsuario.Text = string.Empty;
            this.txtContrasenia.Text = string.Empty;
        }


    }
}
