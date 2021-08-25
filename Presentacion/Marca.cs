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
    public partial class Marca : Form
    {
        public int intIdMarca;
        public int idUsuario;
        public int idEmpresa;
        public int tipo;

        public Marca()
        {
            InitializeComponent();
        }



        private void Marca_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGMarca objNg = new Negocio.NGMarca(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMarca(intIdMarca, ref blnTodoOK);
                txtIdMarca.Text = tbl.Rows[0]["intIdMarca"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoMarca"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMarca"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGMarca objNg = new Negocio.NGMarca(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMarca(intIdMarca, ref blnTodoOK);

                txtIdMarca.Text = tbl.Rows[0]["intIdMarca"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoMarca"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMarca"].ToString();
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

            if (intIdMarca == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Marca.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENMarca obj = new ENMarca();
                obj.strCoMarca = txtCodigo.Text.Trim();
                obj.strNoMarca = txtNombre.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGMarca objNg = new Negocio.NGMarca(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarMarca(obj, idEmpresa, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Marca guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENMarca obj = new ENMarca();
            obj.intIdMarca = intIdMarca;
            obj.strCoMarca = txtCodigo.Text.Trim();
            obj.strNoMarca = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGMarca objNg = new Negocio.NGMarca(Configuracion.Sistema.CadenaConexion);

            objNg.EditarMarca(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Marca Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
