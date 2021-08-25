using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidad;

namespace Presentacion
{
    public partial class CambiarContrasena : Form
    {
        public int idUsuario;
        public string contrasenaActual;
        DataTable tbl = new DataTable();

        public CambiarContrasena()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text.Trim() != txtConfirmarContrasena.Text.Trim())
            { MessageBox.Show("Las Contraseñas deben coincidir.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txtContrasena.Text.Trim() == string.Empty)
            { MessageBox.Show("Ingrese Contraseña.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtContrasena.Focus(); return; }
            if (txtConfirmarContrasena.Text.Trim() == string.Empty)
            { MessageBox.Show("Confirme Contraseña.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtConfirmarContrasena.Focus(); return; }
            if (txtContrasenaActual.Text.Trim() != contrasenaActual)
            { MessageBox.Show("Debe Ingresar su antigua Contraseña.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtContrasenaActual.Focus(); return; }
            
            bool blnTodoOK = false;
            ENUsuario obj = new ENUsuario();
            obj.intIdUsu = idUsuario;
            obj.strClave = txtContrasena.Text.Trim();
            obj.intIdUsuMf = idUsuario;

            NGUsuario objNg = new NGUsuario(Configuracion.Sistema.CadenaConexion);

            objNg.EditarContrasena(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Contraseña Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void CambiarContrasena_Load(object sender, EventArgs e)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            NGUsuario objNgUsu = new NGUsuario(Configuracion.Sistema.CadenaConexion);

            tbl = objNgUsu.BuscarUsuario(idUsuario, ref blnTodoOK);

            lblUsuario.Text = tbl.Rows[0]["strNoUsu"].ToString();
            contrasenaActual = tbl.Rows[0]["strClave"].ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
