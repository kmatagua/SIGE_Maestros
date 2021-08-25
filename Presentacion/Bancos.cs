using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;

namespace Presentacion
{
    public partial class Bancos : Form
    {
        public int intIdBanco;
        public int tipo;
        public int idUsuario;
        public int idEmpresa;

        public Bancos()
        {
            InitializeComponent();
        }

        private void Bancos_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGBancos objNg = new Negocio.NGBancos(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarBancos(intIdBanco, ref blnTodoOK);
               
                txtCodigo.Text = tbl.Rows[0]["strCoBancos"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoBancos"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGBancos objNg = new Negocio.NGBancos(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarBancos(intIdBanco, ref blnTodoOK);

                txtCodigo.Text = tbl.Rows[0]["strCoBancos"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoBancos"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Visible = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdBanco == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre del Banco.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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


        #region FUNCIONES

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENBancos obj = new ENBancos();
                obj.strCoBancos = txtCodigo.Text.Trim();
                obj.strNoBancos = txtNombre.Text.Trim();
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGBancos objNg = new Negocio.NGBancos(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarBancos(obj, idEmpresa, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Banco guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENBancos obj = new ENBancos();
            obj.intIdBancos = intIdBanco;
            obj.strCoBancos = txtCodigo.Text.Trim();
            obj.strNoBancos = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGBancos objNg = new Negocio.NGBancos(Configuracion.Sistema.CadenaConexion);

            objNg.EditarBancos(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Banco Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        #endregion

       

        

        

        
    }
}
