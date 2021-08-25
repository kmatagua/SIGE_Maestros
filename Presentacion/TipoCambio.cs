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
    public partial class TipoCambio : Form
    {
        public int intIdTipoCambio;
        public int idUsuario;
        public int tipo;
        public int idEmpresa;
        public string nombreEmpresa;

        public TipoCambio()
        {
            InitializeComponent();
        }

        private void TipoCambio_Load(object sender, EventArgs e)
        {
            //lblEmpresa.Text = nombreEmpresa;
            ListarCombo();
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGTipoCambio objNg = new NGTipoCambio(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarTipoCambio(intIdTipoCambio, ref blnTodoOK);

                txtPrecioCompra.Text = tbl.Rows[0]["decPrecioCompra"].ToString();
                txtPrecioVenta.Text = tbl.Rows[0]["decPrecioVenta"].ToString();
                dtpFeTipoCambio.Value = Convert.ToDateTime(tbl.Rows[0]["dttFeTipoCambio"].ToString());
                cbxMoneda.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdMoneda"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGTipoCambio objNg = new NGTipoCambio(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarTipoCambio(intIdTipoCambio, ref blnTodoOK);

                txtPrecioCompra.Text = tbl.Rows[0]["decPrecioCompra"].ToString();
                txtPrecioVenta.Text = tbl.Rows[0]["decPrecioVenta"].ToString();
                dtpFeTipoCambio.Value = Convert.ToDateTime(tbl.Rows[0]["dttFeTipoCambio"].ToString());
                cbxMoneda.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdMoneda"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                cbxMoneda.Enabled = false;
                btnGuardar.Enabled = false;
                groupBox1.Enabled = false;
                //txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

                              
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdTipoCambio == 0)
            { //NUEVO
                if (txtPrecioCompra.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Precio de Compra.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtPrecioCompra.Focus(); return; }
                if (txtPrecioVenta.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Precio de Venta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtPrecioVenta.Focus(); return; }
               
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


        #region funciones

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENTipoCambio obj = new ENTipoCambio();
                obj.decPrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text.Trim());
                obj.decPrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text.Trim());
                obj.dttFeTipoCambio = dtpFeTipoCambio.Value;
                obj.intIdUsuCr = idUsuario;
                obj.intIdMoneda = Convert.ToInt32(cbxMoneda.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGTipoCambio objNg = new Negocio.NGTipoCambio(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarTipoCambio(obj, ref mensaje, ref blnTodoOK);

                
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
                    MessageBox.Show("TipoCambio guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENTipoCambio obj = new ENTipoCambio();
            obj.intIdTipoCambio = intIdTipoCambio;
            obj.decPrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text.Trim());
            obj.decPrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text.Trim());
            obj.dttFeTipoCambio = dtpFeTipoCambio.Value;
            obj.intIdUsuMf = idUsuario;
            obj.intIdMoneda = Convert.ToInt32(cbxMoneda.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            
            Negocio.NGTipoCambio objNg = new Negocio.NGTipoCambio(Configuracion.Sistema.CadenaConexion);

            objNg.EditarTipoCambio(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("TipoCambio Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            NGMoneda obj = new NGMoneda(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Moneda(ref blnTodoOK);

            cbxMoneda.DataSource = tbl;
            cbxMoneda.DisplayMember = "strCoMoneda";
            cbxMoneda.ValueMember = "intIdMoneda";

        }
        #endregion

        

        
    }
}
