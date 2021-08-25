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
    public partial class Login : Form
    {
        public int cambiarUsuario;
        public int intIdUsux;
        public string strNoUsux;
        public string p_strMensaje = string.Empty;
        public int p_intIdUsu = 0;

        public int intentos = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (cambiarUsuario != 1)
            {
                this.Close();
                Application.Exit();
            }
            else 
            {
                MessageBox.Show("Usuario o Clave, incorrecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtUsername.Focus();// return; 
                this.Close();
            }
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            { MessageBox.Show("Ingrese Nombre de Usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtUsername.Focus(); return; }
            if (txtPassword.Text.Trim() == string.Empty)
            { MessageBox.Show("Ingrese Contraseña.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtPassword.Focus(); return; }

               ENUsuario objUsuario = new ENUsuario();
            objUsuario.strNoUsu = txtUsername.Text.Trim();
            objUsuario.strClave = txtPassword.Text.Trim();

            
            bool pBlnTodoOk = false;
            Clases.InicialCls.LeerXml();
            NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
            obj.Usuario_V01(objUsuario, ref p_intIdUsu, ref p_strMensaje, ref pBlnTodoOk);
            if (!pBlnTodoOk)
            { MessageBox.Show("Hubo un Error al consultar la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            
            if (p_strMensaje == string.Empty)
            {
                btnIngresar.DialogResult = DialogResult.OK;
                intIdUsux = p_intIdUsu;
               strNoUsux = txtUsername.Text.Trim();
               
               //btnIngresar.DialogResult = DialogResult.OK;
               //this.Close();
               //btnIngresar.PerformClick();
               btnIngresar1.PerformClick();
            }
            else
            {
                MessageBox.Show(p_strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //btnIngresar.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                intentos = intentos +1;
                if (intentos == 3)
                {
                    Application.Exit();
                }
                txtPassword.Focus();
                //return;
            }
             
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnIngresar.PerformClick();

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string cc = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
            if (System.IO.File.Exists(cc) == true)
            { Clases.InicialCls.LeerXml(); }
            else
            { Clases.InicialCls.CrearXml(); Clases.InicialCls.LeerXml(); }
        }

        private void btCU_Click(object sender, EventArgs e)
        {
            

        }

        private void btnIngresar1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            { MessageBox.Show("Ingrese Nombre de Usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtUsername.Focus(); return; }
            if (txtPassword.Text.Trim() == string.Empty)
            { MessageBox.Show("Ingrese Contraseña.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtPassword.Focus(); return; }

            ENUsuario objUsuario = new ENUsuario();
            objUsuario.strNoUsu = txtUsername.Text.Trim();
            objUsuario.strClave = txtPassword.Text.Trim();


            bool pBlnTodoOk = false;
            Clases.InicialCls.LeerXml();
            NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
            obj.Usuario_V01(objUsuario, ref p_intIdUsu, ref p_strMensaje, ref pBlnTodoOk);
            if (!pBlnTodoOk)
            { MessageBox.Show("Hubo un Error al consultar la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


            if (p_strMensaje == string.Empty)
            {
                btnIngresar.DialogResult = DialogResult.OK;
                intIdUsux = p_intIdUsu;
                strNoUsux = txtUsername.Text.Trim();

                //btnIngresar.DialogResult = DialogResult.OK;
                //this.Close();
                //btnIngresar.PerformClick();
                //btnIngresar1.PerformClick();
            }
            else
            {
                MessageBox.Show(p_strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //btnIngresar.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                intentos = intentos + 1;
                if (intentos == 3)
                {
                    Application.Exit();
                }
                txtPassword.Focus();
                //return;
            }
        }
    }
}
