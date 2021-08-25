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
    public partial class Maquina : Form
    {
        public int intIdEmp;
        public int idUsuario;
        public int tipo;
        public int intIdMaq;

        public Maquina()
        {
            InitializeComponent();
        }

        private void Maquina_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGMaquina objNg = new Negocio.NGMaquina(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMaquina(intIdMaq, ref blnTodoOK);
                
                txtCodigo.Text = tbl.Rows[0]["strCoMaq"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMaq"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGMaquina objNg = new Negocio.NGMaquina(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarMaquina(intIdMaq, ref blnTodoOK);

               
                txtCodigo.Text = tbl.Rows[0]["strCoMaq"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoMaq"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENMaquina obj = new ENMaquina();
                obj.strCoMaq = txtCodigo.Text.Trim();
                obj.strNoMaq = txtNombre.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGMaquina objNg = new Negocio.NGMaquina(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarMaquina(obj, intIdEmp, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Maquina guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENMaquina obj = new ENMaquina();
            obj.intIdMaq = intIdMaq;
            obj.strCoMaq = txtCodigo.Text.Trim();
            obj.strNoMaq = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            Negocio.NGMaquina objNg = new Negocio.NGMaquina(Configuracion.Sistema.CadenaConexion);

            objNg.EditarMaquina(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Maquina Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdMaq == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Maquina.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }

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

    }
}
