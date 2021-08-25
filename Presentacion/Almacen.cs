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
    public partial class Almacen : Form
    {
        public int intIdAlm;
        public int idUsuario;
        public int tipo;
        public int idEmpresa;
        public string nombreEmpresa;

        public Almacen()
        {
            InitializeComponent();
        }

        private void Almacen_Load(object sender, EventArgs e)
        {
            lblEmpresa.Text = nombreEmpresa;
            ListarCombo(idEmpresa);
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGAlmacen objNg = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarAlmacen(intIdAlm, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdAlm"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoAlm"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoAlm"].ToString();
                cbxSede.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdSede"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                chkServicio.Checked = Convert.ToBoolean(tbl.Rows[0]["intServicio"]);

                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGAlmacen objNg = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarAlmacen(intIdAlm, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdAlm"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoAlm"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoAlm"].ToString();
                cbxSede.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdSede"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                chkServicio.Checked = Convert.ToBoolean(tbl.Rows[0]["intServicio"]);

                cbxSede.Enabled = false;
                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;
                chkServicio.Enabled = false;

            }
        }

                      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdAlm == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre del Almacen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENAlmacen obj = new ENAlmacen();
                obj.strCoAlm = txtCodigo.Text.Trim();
                obj.strNoAlm = txtNombre.Text.Trim();
                obj.intIdUsuCr = idUsuario;

                obj.intServicio = Convert.ToInt32(chkServicio.Checked);

                obj.intIdSede = Convert.ToInt32(cbxSede.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGAlmacen objNg = new Negocio.NGAlmacen(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarAlmacen(obj, ref mensaje, ref blnTodoOK);

                
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
                    MessageBox.Show("Almacen guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENAlmacen obj = new ENAlmacen();
            obj.intIdAlm = intIdAlm;
            obj.strCoAlm = txtCodigo.Text.Trim();
            obj.strNoAlm = txtNombre.Text.Trim();
            obj.intIdUsuMf = idUsuario;
            obj.intServicio = Convert.ToInt32(chkServicio.Checked);
            obj.intIdSede = Convert.ToInt32(cbxSede.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            
            Negocio.NGAlmacen objNg = new Negocio.NGAlmacen(Configuracion.Sistema.CadenaConexion);

            objNg.EditarAlmacen(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Almacen Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        public void ListarCombo(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGSede obj = new NGSede(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Sede(idEmpresa, ref blnTodoOK);

            cbxSede.DataSource = tbl;
            cbxSede.DisplayMember = "strNoSede";
            cbxSede.ValueMember = "intIdSede";

        }

        
    }
}
