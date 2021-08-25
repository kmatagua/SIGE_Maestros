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
    public partial class CentroCosto : Form
    {
        public int intIdEmp;
        public int intIdCenCos;
        public int idUsuario;
        public int tipo;
        public int intIdUnidadNegocio;

        public CentroCosto()
        {
            InitializeComponent();
        }

        private void CentroCosto_Load(object sender, EventArgs e)
        {

            Listar_Unidad_Negocio();
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGCentroCosto objNg = new Negocio.NGCentroCosto(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarCentroCosto(intIdCenCos, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdCenCos"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoCenCos"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoCenCos"].ToString();
                txtNivel.Text = tbl.Rows[0]["strNivelCenCos"].ToString();
                cbxUnidadNegocio.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdUndNeg"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGCentroCosto objNg = new Negocio.NGCentroCosto(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarCentroCosto(intIdCenCos, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdCenCos"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoCenCos"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoCenCos"].ToString();
                txtNivel.Text = tbl.Rows[0]["strNivelCenCos"].ToString();
                cbxUnidadNegocio.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdUndNeg"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtNivel.ReadOnly = true;
                cbxUnidadNegocio.Enabled = false;
                chkEstado.Enabled = false;


            }
        }



        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdCenCos == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la CentroCosto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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


        #region FUNCIONES

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENCentroCosto obj = new ENCentroCosto();
                obj.strCoCenCos = txtCodigo.Text.Trim();
                obj.strNoCenCos = txtNombre.Text.Trim();
                obj.strNivelCenCos = txtNivel.Text.Trim();
                obj.intIdUnidadNegocio = Convert.ToInt32(cbxUnidadNegocio.SelectedValue);
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGCentroCosto objNg = new Negocio.NGCentroCosto(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarCentroCosto(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Centro de Costo guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENCentroCosto obj = new ENCentroCosto();
            obj.intIdCenCos = intIdCenCos;
            obj.strCoCenCos = txtCodigo.Text.Trim();
            obj.strNoCenCos = txtNombre.Text.Trim();
            obj.strNivelCenCos = txtNivel.Text.Trim();
            obj.intIdUnidadNegocio = Convert.ToInt32(cbxUnidadNegocio.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            Negocio.NGCentroCosto objNg = new Negocio.NGCentroCosto(Configuracion.Sistema.CadenaConexion);

            objNg.EditarCentroCosto(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("CentroCosto Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        public void Listar_Unidad_Negocio()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo("UND_NEGOCIO", intIdEmp, ref pBlnTodoOk);

            cbxUnidadNegocio.DisplayMember = "strNoUndNeg";
            cbxUnidadNegocio.ValueMember = "intIdUndNeg";
            cbxUnidadNegocio.DataSource = tbl;
        }

        #endregion

    
    }
}
