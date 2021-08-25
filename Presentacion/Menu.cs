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
    public partial class Menu : Form
    {
        public int intIdMenu;
        public int tipo;
        public int idUsuario;

        public Menu()
        {
            InitializeComponent();
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            //ListarComboUsuario();
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGMenu objNg = new Negocio.NGMenu(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMenu(intIdMenu, ref blnTodoOK);
                txtIdMenu.Text = tbl.Rows[0]["intIdMenu"].ToString();
                //cbxUsuario.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdUsu"]);
                txtCodigo.Text = tbl.Rows[0]["strCoMenu"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMenu"].ToString();
                intIdMenu = Convert.ToInt32(tbl.Rows[0]["intIdMenu"].ToString());
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGMenu objNg = new Negocio.NGMenu(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMenu(intIdMenu, ref blnTodoOK);

                txtIdMenu.Text = tbl.Rows[0]["intIdMenu"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoMenu"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMenu"].ToString();


                //cbxTipo.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTipo"]);
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

            if (intIdMenu == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre del Menu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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

        //public void ListarComboUsuario()
        //{
        //    bool blnTodoOK = false;
        //    Clases.InicialCls.LeerXml();
        //    DataTable tbl = new DataTable();
        //    NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
        //    tbl = obj.ComboUsuario(ref blnTodoOK);
        //    cbxUsuario.DisplayMember = "nombre";
        //    cbxUsuario.ValueMember = "id";
        //    cbxUsuario.DataSource = tbl;

        //}


        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENMenu obj = new ENMenu();
                obj.strCoMenu = txtCodigo.Text.Trim();
                obj.strNoMenu = txtNombre.Text.Trim();
                //obj.intIdTipo = Convert.ToInt32(cbxTipo.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGMenu objNg = new Negocio.NGMenu(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarMenu(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Menu guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENMenu obj = new ENMenu();
            obj.intIdMenu = intIdMenu;
            obj.strCoMenu = txtCodigo.Text.Trim();
            obj.strNoMenu = txtNombre.Text.Trim();
            //obj.intIdTipo = Convert.ToInt32(cbxTipo.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            
            Negocio.NGMenu objNg = new Negocio.NGMenu(Configuracion.Sistema.CadenaConexion);

            objNg.EditarMenu(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Menu Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
