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
    public partial class Sede : Form
    {
        public int intIdSede;
        public int tipo;
        public int idUsuario;

        public Sede()
        {
            InitializeComponent();
        }

        private void Sede_Load(object sender, EventArgs e)
        {
            ListarCombo();
            if (tipo == 1)
            { //NUEVO
                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGSede objNg = new NGSede(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarSede(intIdSede, ref blnTodoOK);
                //txtIdEmp.Text = tbl.Rows[0]["intIdSede"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoSede"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoSede"].ToString();
                cbxEmpresa.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdEmp"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGSede objNg = new Negocio.NGSede(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarSede(intIdSede, ref blnTodoOK);

                //txtIdEmp.Text = tbl.Rows[0]["intIdSede"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoSede"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoSede"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                cbxEmpresa.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdEmp"]);
                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

              
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdSede == 0) //NUEVO
            { 
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Sede.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
                Insertar();
            }
            else //--------------EDITAR
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
                ENSede obj = new ENSede();
                obj.strCoSede = txtCodigo.Text.Trim();
                obj.strNoSede = txtNombre.Text.Trim();
                obj.intIdEmp = Convert.ToInt32(cbxEmpresa.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGSede objNg = new Negocio.NGSede(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarSede(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Sede guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENSede obj = new ENSede();
            obj.intIdSede = intIdSede;
            obj.strCoSede = txtCodigo.Text.Trim();
            obj.strNoSede = txtNombre.Text.Trim();
            obj.intIdEmp = Convert.ToInt32(cbxEmpresa.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGSede objNg = new Negocio.NGSede(Configuracion.Sistema.CadenaConexion);

            objNg.EditarSede(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Sede Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        public void ListarCombo()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Empresa(idUsuario, ref blnTodoOK);

            cbxEmpresa.DataSource = tbl;
            cbxEmpresa.DisplayMember = "nombre";
            cbxEmpresa.ValueMember = "id";

        }

        #endregion


        
        

        
    }
}
