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
    public partial class Area : Form
    {
        public int intIdArea;
        public int idUsuario;
        public int idEmpresa;
        public int tipo;

        public Area()
        {
            InitializeComponent();
        }


        private void Area_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGArea objNg = new Negocio.NGArea(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarArea(intIdArea, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdArea"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoArea"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoArea"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGUndNegocio objNg = new Negocio.NGUndNegocio(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUndNegocio(intIdArea, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdUndNeg"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUndNeg"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUndNeg"].ToString();
                //txtNivel.Text = tbl.Rows[0]["strNivelUndNeg"].ToString();
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

            if (intIdArea == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre del Area.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtNombre.Focus(); return; }
               
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
                ENArea obj = new ENArea();
                obj.strCoArea = txtCodigo.Text.Trim();
                obj.strNoArea = txtNombre.Text.Trim();
                //obj.strNivelUndNeg = txtNivel.Text.Trim();
                obj.intIdEmp = idEmpresa;
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGArea objNg = new Negocio.NGArea(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarArea(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Area guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENArea obj = new ENArea();
            obj.intIdArea = intIdArea;
            obj.strCoArea = txtCodigo.Text.Trim();
            obj.strNoArea = txtNombre.Text.Trim();
            obj.intIdEmp = idEmpresa;
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            Negocio.NGArea objNg = new Negocio.NGArea(Configuracion.Sistema.CadenaConexion);

            objNg.EditarArea(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Area Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

    }
}
