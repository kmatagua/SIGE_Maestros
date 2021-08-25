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
    public partial class Condicion : Form
    {
        public int intIdCondic;
        public int idUsuario;
        public int tipo;

        public Condicion()
        {
            InitializeComponent();
        }


        private void Condicion_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGCondicion objNg = new Negocio.NGCondicion(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarCondicion(intIdCondic, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdCondic"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoCondic"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoCondic"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGCondicion objNg = new Negocio.NGCondicion(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarCondicion(intIdCondic, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdCondic"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoCondic"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoCondic"].ToString();
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

            if (intIdCondic == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Condicion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENCondicion obj = new ENCondicion();
                obj.strCoCondic = txtCodigo.Text.Trim();
                obj.strNoCondic = txtNombre.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGCondicion objNg = new Negocio.NGCondicion(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarCondicion(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Condición guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENCondicion obj = new ENCondicion();
            obj.intIdCondic = intIdCondic;
            obj.strCoCondic = txtCodigo.Text.Trim();
            obj.strNoCondic = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGCondicion objNg = new Negocio.NGCondicion(Configuracion.Sistema.CadenaConexion);

            objNg.EditarCondicion(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Condicion Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
