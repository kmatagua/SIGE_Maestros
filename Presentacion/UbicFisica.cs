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
    public partial class UbicFisica : Form
    {
        public int intIdUbic;
        public int idUsuario;
        public int tipo;

        public int intIdEmp;

        public UbicFisica()
        {
            InitializeComponent();
        }


        private void UbicFisica_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGUbicFisica objNg = new Negocio.NGUbicFisica(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                 tbl = objNg.BuscarUbicFisica(intIdUbic, ref blnTodoOK);

                intIdEmp = Convert.ToInt32(tbl.Rows[0]["intIdEmp"]);
                txtEmpresa.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtIdUbic.Text = tbl.Rows[0]["intIdUbic"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUbic"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUbic"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGUbicFisica objNg = new Negocio.NGUbicFisica(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUbicFisica(intIdUbic, ref blnTodoOK);
                txtEmpresa.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtIdUbic.Text = tbl.Rows[0]["intIdUbic"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUbic"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUbic"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtEmpresa.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdUbic == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la UbicFisica.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENUbicFisica obj = new ENUbicFisica();
                obj.strCoUbic = txtCodigo.Text.Trim();
                obj.strNoUbic = txtNombre.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGUbicFisica objNg = new Negocio.NGUbicFisica(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarUbicFisica(obj, intIdEmp, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Ubicación Fisica guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENUbicFisica obj = new ENUbicFisica();
            obj.intIdUbic = intIdUbic;
            obj.strCoUbic = txtCodigo.Text.Trim();
            obj.strNoUbic = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGUbicFisica objNg = new Negocio.NGUbicFisica(Configuracion.Sistema.CadenaConexion);

            objNg.EditarUbicFisica(obj, intIdEmp, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("UbicFisica Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        #endregion

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "EMPRESA";
                frm.tipoTabla = "EMPRESA";
                //frm.intId = intIdEmp;
                frm.intIdUsu = idUsuario;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    intIdEmp = frm.idEncontrado;
                    txtEmpresa.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    //txtSerie.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            
        }

    }
}
