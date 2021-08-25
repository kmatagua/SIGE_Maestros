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
    public partial class Motivo : Form
    {
        public int intIdMotivo;
        public int idUsuario;
        public int tipo;

        public Motivo()
        {
            InitializeComponent();
        }

        private void Motivo_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGMotivo objNg = new Negocio.NGMotivo(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMotivo(intIdMotivo, ref blnTodoOK);
                txtIdMotivo.Text = tbl.Rows[0]["intIdMot"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoMot"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMot"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGMotivo objNg = new Negocio.NGMotivo(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMotivo(intIdMotivo, ref blnTodoOK);

                txtIdMotivo.Text = tbl.Rows[0]["intIdMot"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoMot"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMot"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdMotivo == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre del Motivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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


        #region

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENMotivo obj = new ENMotivo();
                obj.strCoMot = txtCodigo.Text.Trim();
                obj.strNoMot = txtNombre.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGMotivo objNg = new Negocio.NGMotivo(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarMotivo(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Motivo guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENMotivo obj = new ENMotivo();
            obj.intIdMot = intIdMotivo;
            obj.strCoMot = txtCodigo.Text.Trim();
            obj.strNoMot = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGMotivo objNg = new Negocio.NGMotivo(Configuracion.Sistema.CadenaConexion);

            objNg.EditarMotivo(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Motivo Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
