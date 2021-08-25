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
    public partial class UndNegocio : Form
    {
        public int intIdUndNeg;
        public int idUsuario;
        public int idEmpresa;
        public int tipo;

        public UndNegocio()
        {
            InitializeComponent();
        }

        private void UndNegocio_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGUndNegocio objNg = new Negocio.NGUndNegocio(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUndNegocio(intIdUndNeg, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdUndNeg"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUndNeg"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUndNeg"].ToString();
                txtNivel.Text = tbl.Rows[0]["strNivelUndNeg"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGUndNegocio objNg = new Negocio.NGUndNegocio(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUndNegocio(intIdUndNeg, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdUndNeg"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUndNeg"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUndNeg"].ToString();
                txtNivel.Text = tbl.Rows[0]["strNivelUndNeg"].ToString();
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

            if (intIdUndNeg == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Unidad de Negocio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENUndNegocio obj = new ENUndNegocio();
                obj.strCoUndNeg = txtCodigo.Text.Trim();
                obj.strNoUndNeg = txtNombre.Text.Trim();
                obj.strNivelUndNeg = txtNivel.Text.Trim();
                obj.intIdEmp = idEmpresa;
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGUndNegocio objNg = new Negocio.NGUndNegocio(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarUndNegocio(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Unidad de Negocio guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENUndNegocio obj = new ENUndNegocio();
            obj.intIdUndNeg = intIdUndNeg;
            obj.strCoUndNeg = txtCodigo.Text.Trim();
            obj.strNoUndNeg = txtNombre.Text.Trim();
            obj.strNivelUndNeg = txtNivel.Text.Trim();
            obj.intIdEmp = idEmpresa;
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            Negocio.NGUndNegocio objNg = new Negocio.NGUndNegocio(Configuracion.Sistema.CadenaConexion);

            objNg.EditarUndNegocio(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Unidad de negocio Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

    }
}
