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
    public partial class Familia : Form
    {
        public int intIdFamilia;
        public int tipo;
        public int idUsuario;
        public int idEmpresa;
        public int idClaArt;

        public Familia()
        {
            InitializeComponent();
        }

        private void Familia_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGFamilia objNg = new Negocio.NGFamilia(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarFamilia(intIdFamilia, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdFamilia"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoFamilia"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoFamilia"].ToString();
                txtClaArt.Text = tbl.Rows[0]["strNoClaArt"] is DBNull ? "" : tbl.Rows[0]["strNoClaArt"].ToString();
                idClaArt = tbl.Rows[0]["intIdClaArt"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdClaArt"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGFamilia objNg = new Negocio.NGFamilia(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarFamilia(intIdFamilia, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdFamilia"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoFamilia"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoFamilia"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                txtClaArt.Text = tbl.Rows[0]["strNoClaArt"] is DBNull ? "" : tbl.Rows[0]["strNoClaArt"].ToString();
                idClaArt = tbl.Rows[0]["intIdClaArt"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdClaArt"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;
                txtClaArt.Enabled = false;


            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdFamilia == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Familia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENFamilia obj = new ENFamilia();
                obj.strCoFamilia = txtCodigo.Text.Trim();
                obj.strNoFamilia = txtNombre.Text.Trim();
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;
                obj.intIdClaArt = idClaArt;

                Negocio.NGFamilia objNg = new Negocio.NGFamilia(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarFamilia(obj, idEmpresa, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Familia guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENFamilia obj = new ENFamilia();
            obj.intIdFamilia = intIdFamilia;
            obj.strCoFamilia = txtCodigo.Text.Trim();
            obj.strNoFamilia = txtNombre.Text.Trim();
            obj.intIdClaArt = idClaArt;
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGFamilia objNg = new Negocio.NGFamilia(Configuracion.Sistema.CadenaConexion);

            objNg.EditarFamilia(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Familia Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void txtClaArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "CLASIFICACION_ART";
                frm.tipoTabla = "GENERAL";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idClaArt = frm.idEncontrado;
                    txtClaArt.Text = frm.nombreEncontrado;
                    //txtSubFamilia.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtClaArt.Clear();
                idClaArt = 0;
            }
        }

    }
}
