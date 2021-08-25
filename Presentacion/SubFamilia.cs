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
    public partial class SubFamilia : Form
    {
        public int intIdSubFamilia;
        public int tipo;
        public int idFamilia;
        public int idUsuario;

        public SubFamilia()
        {
            InitializeComponent();
        }

        private void SubFamilia_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGSubFamilia objNg = new NGSubFamilia(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarSubFamilia(intIdSubFamilia, ref blnTodoOK);
                txtIdSubFamilia.Text = tbl.Rows[0]["intIdSubFamilia"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoSubFamilia"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoSubFamilia"].ToString();
                txtFamilia.Text = tbl.Rows[0]["strNoFamilia"].ToString();
                idFamilia = Convert.ToInt32(tbl.Rows[0]["intIdFamilia"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGSubFamilia objNg = new Negocio.NGSubFamilia(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarSubFamilia(intIdSubFamilia, ref blnTodoOK);

                txtIdSubFamilia.Text = tbl.Rows[0]["intIdSubFamilia"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoSubFamilia"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoSubFamilia"].ToString();
                txtFamilia.Text = tbl.Rows[0]["strNoFamilia"].ToString();
                //idFamilia = Convert.ToInt32(tbl.Rows[0]["intIdFamilia"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                //cbxFamilia.Enabled = false;
                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtFamilia.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }


                      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdSubFamilia == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre del SubFamilia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENSubFamilia obj = new ENSubFamilia();
                obj.strCoSubFamilia = txtCodigo.Text.Trim();
                obj.strNoSubFamilia = txtNombre.Text.Trim();
                obj.intIdFamilia = idFamilia;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGSubFamilia objNg = new Negocio.NGSubFamilia(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarSubFamilia(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Sub Familia guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENSubFamilia obj = new ENSubFamilia();
            obj.intIdSubFamilia = intIdSubFamilia;
            obj.strCoSubFamilia = txtCodigo.Text.Trim();
            obj.strNoSubFamilia = txtNombre.Text.Trim();
            obj.intIdFamilia = idFamilia;
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGSubFamilia objNg = new Negocio.NGSubFamilia(Configuracion.Sistema.CadenaConexion);

            objNg.EditarSubFamilia(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("SubFamilia Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

       
        #endregion

        private void txtFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "FAMILIA";
                frm.tipoTabla = "FAMILIA";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idFamilia = frm.idEncontrado;
                    txtFamilia.Text = frm.nombreEncontrado;
                    txtCodigo.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtFamilia.Clear();
                idFamilia = 0;
            }
        }

       

        
        
    }
}
