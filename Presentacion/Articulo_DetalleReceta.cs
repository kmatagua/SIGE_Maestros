using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Articulo_DetalleReceta : Form
    {
        public int intIdEmp;
        public int intIdUsu;
        //***Datos para el Detalle****
        public int intIdArt;
        public string strNoArt;
        public string strUnidad;
        public decimal decCant;
        public string strAccion;
        //****************************

        public Articulo_DetalleReceta()
        {
            InitializeComponent();
        }

        private void Articulo_DetalleReceta_Load(object sender, EventArgs e)
        {
            txtArticulo.ReadOnly = true;
            if (strAccion == "NUEVO")
            {
                txtBusqueda.Focus();
            }
            else if (strAccion == "EDITAR")
            {
                txtCantidad.Text = decCant.ToString();
                txtArticulo.Text = strNoArt;
                txtUnidad.Text = strUnidad;
                this.txtCantidad.Focus();
            }    
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filtro = txtBusqueda.Text;
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            Negocio.NGComun obj = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ListaFiltrar("ARTICULO", filtro, intIdEmp, intIdUsu, intIdEmp, ref blnTodoOK);
            dgvListadoArticulo.DataSource = tbl;
            dgvListadoArticulo.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim() == string.Empty)
            { MessageBox.Show("No ingresó Artículo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (intIdArt < 0)
            {   MessageBox.Show("No se Seleccionó Artículo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (txtCantidad.Text.Trim() == string.Empty)
            { MessageBox.Show("el campo cantidad no debe estar vacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            //if (txtPrecio.Text.Trim() == string.Empty)
            //{ MessageBox.Show("el campo PU no debe estar vacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            //if (txtPonderado.Text.Trim() == string.Empty)
            //{ MessageBox.Show("el campo ponderado no debe estar vacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            //if (Convert.ToDecimal(txtCantidad.Text.Trim()) <= 0)
            //{ MessageBox.Show("Ingrese una cantidad mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            strNoArt = txtArticulo.Text;
            strUnidad = txtUnidad.Text;
            decCant = Convert.ToDecimal(txtCantidad.Text.Trim());
            
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
                dgvListadoArticulo.Focus();
            }            
        }

        private void dgvListadoArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListadoArticulo.RowCount > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
                    intIdArt = Convert.ToInt32(dgvListadoArticulo.CurrentRow.Cells["Id"].Value);
                    txtArticulo.Text = dgvListadoArticulo.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtUnidad.Text = dgvListadoArticulo.CurrentRow.Cells["strCoUni"].Value.ToString();
                    txtCantidad.Focus();
                }
            }                
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtPonderado.Focus();
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
        }

        private void SoloNumerosDecimal(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                //MessageBox.Show("Solo se Aceptan Numeros", "Mensaje del Sistema");
                e.Handled = true;
            }
            //if (Char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

    }
}
