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
    public partial class TipoDoc : Form
    {
        public int intIdTipDoc;
        public int tipo;
        public int idUsuario;
        public int idEmpresa;

        public TipoDoc()
        {
            InitializeComponent();
        }

        private void TipoDoc_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGTipoDoc objNg = new Negocio.NGTipoDoc(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarTipoDoc(intIdTipDoc, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdTipDoc"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoTipDoc"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoTipDoc"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGTipoDoc objNg = new Negocio.NGTipoDoc(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarTipoDoc(intIdTipDoc, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdTipDoc"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoTipDoc"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoTipDoc"].ToString();
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

            if (intIdTipDoc == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Unidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENTipoDoc obj = new ENTipoDoc();
                obj.strCoTipDoc = txtCodigo.Text.Trim();
                obj.strNoTipDoc = txtNombre.Text.Trim();
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGTipoDoc objNg = new Negocio.NGTipoDoc(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarTipoDoc(idEmpresa, obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Tipo de Documento guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENTipoDoc obj = new ENTipoDoc();
            obj.intIdTipDoc = intIdTipDoc;
            obj.strCoTipDoc = txtCodigo.Text.Trim();
            obj.strNoTipDoc = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGTipoDoc objNg = new Negocio.NGTipoDoc(Configuracion.Sistema.CadenaConexion);

            objNg.EditarTipoDoc(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Tipo de Documento Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
