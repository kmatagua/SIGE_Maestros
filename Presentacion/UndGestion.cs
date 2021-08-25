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
    public partial class UndGestion : Form
    {
        public int intIdUndGestion;
        public int idUsuario;
        public int idEmpresa;
        public int tipo;

        public UndGestion()
        {
            InitializeComponent();
        }


        private void UndGestion_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGUndGestion objNg = new Negocio.NGUndGestion(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUndGestion(intIdUndGestion, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdUndGestion"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUndGestion"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUndGestion"].ToString();
                txtNivel.Text = tbl.Rows[0]["strNivelUndGestion"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGUndGestion objNg = new Negocio.NGUndGestion(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUndGestion(intIdUndGestion, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdUndGestion"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUndGestion"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUndGestion"].ToString();
                txtNivel.Text = tbl.Rows[0]["strNivelUndGestion"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtNivel.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdUndGestion == 0)
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
                ENUndGestion obj = new ENUndGestion();
                obj.strCoUndGestion = txtCodigo.Text.Trim();
                obj.strNoUndGestion = txtNombre.Text.Trim();
                obj.strNivelUndGestion = txtNivel.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGUndGestion objNg = new Negocio.NGUndGestion(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarUndGestion(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Unidad de Gestión guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENUndGestion obj = new ENUndGestion();
            obj.intIdUndGestion = intIdUndGestion;
            obj.strCoUndGestion = txtCodigo.Text.Trim();
            obj.strNoUndGestion = txtNombre.Text.Trim();
            obj.strNivelUndGestion = txtNivel.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            Negocio.NGUndGestion objNg = new Negocio.NGUndGestion(Configuracion.Sistema.CadenaConexion);

            objNg.EditarUndGestion(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Unidad de Gestión Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        
    }
}
