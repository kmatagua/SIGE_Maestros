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
    public partial class Busqueda : Form
    {
        public int idEncontrado;
        public int tipoBusqueda;
        public string cambio;
        public int intIdUsu;
        public string nombreEncontrado;
        public string codigoEncontrado;
        public string direccionEncontrado;
        public string dniEncontrado;
        public string rucEncontrado;
        public string nombreProvincia;
        public string nombreDepartamento;
        public int intIdTipoOpe;
        public string nombre_maestro;
        public int intId;
        public int idEmpresa;
        public string tipoTabla;

        public Busqueda()
        {
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            Clases.Reglas.alternarColor(dgvItems);
            InicializaGrilla();
            //if (nombre_maestro == "EMPRESA")
            //{
            //    bool blnTodoOK = false;
            //    Clases.InicialCls.LeerXml();
            //    DataTable tbl = new DataTable();
            //    Negocio.NGEmpresa obj = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);
            //    tbl = obj.Empresa(intIdUsu, ref blnTodoOK);
            //    dgvItems.DataSource = tbl;
            //    dgvItems.Focus();
            //}
            //else 
            if (nombre_maestro == "USUARIO")
            {
                bool blnTodoOK = false;
                Clases.InicialCls.LeerXml();
                DataTable tbl = new DataTable();
                Negocio.NGUsuario obj = new Negocio.NGUsuario(Configuracion.Sistema.CadenaConexion);
                tbl = obj.Usuario(intIdUsu, ref blnTodoOK);
                dgvItems.DataSource = tbl;
                dgvItems.Focus();
            }
           
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count > 0)
            {
                idEncontrado = Convert.ToInt32(dgvItems.CurrentRow.Cells["Id"].Value.ToString());
                codigoEncontrado = dgvItems.CurrentRow.Cells["codigo"].Value.ToString();
                nombreEncontrado = dgvItems.CurrentRow.Cells["nombre"].Value.ToString();

                if (tipoTabla == "CLIENTE")
                {
                    rucEncontrado = dgvItems.CurrentRow.Cells["strRuc"].Value.ToString();
                    dniEncontrado = dgvItems.CurrentRow.Cells["strDni"].Value.ToString();
                }

                if (tipoTabla == "UBIGEO")
                {
                    bool blnTodoOK = false;
                    Clases.InicialCls.LeerXml();
                    Negocio.NGComun obj = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);
                    obj.ListaUbigeo(idEncontrado, ref nombreDepartamento, ref nombreProvincia, ref blnTodoOK);

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay registros para mostrar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ----- FUNCIONES -----

        public void Filtrar()
        {
            var filtro = txtBuscar.Text;
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            Negocio.NGComun obj = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ListaFiltrar(nombre_maestro, filtro, intId, intIdUsu, idEmpresa, ref blnTodoOK);

            dgvItems.DataSource = tbl;
            dgvItems.Focus();
        }

        public void InicializaGrilla()
        {
            dgvItems.Columns.Clear();
            dgvItems.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Regular);

            if (tipoTabla == "GENERAL")
            {
                dgvItems.ColumnCount = 3;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 40; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "Codigo"; dgvItems.Columns[1].Width = 80; dgvItems.Columns[1].DataPropertyName = "Codigo"; dgvItems.Columns[1].HeaderText = "Código";
                dgvItems.Columns[2].Name = "Nombre"; dgvItems.Columns[2].Width = 500; dgvItems.Columns[2].DataPropertyName = "Nombre"; dgvItems.Columns[2].HeaderText = "Descripción";
            }
            else if (tipoTabla == "PROVEEDOR")
            {
                dgvItems.ColumnCount = 4;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                 //Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 50; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 100; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "Codigo"; dgvItems.Columns[1].Visible = false;
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 300; dgvItems.Columns[2].DataPropertyName = "strRazSoc"; dgvItems.Columns[2].HeaderText = "Nombre Proveedor"; 
                dgvItems.Columns[3].Name = "strRUC"; dgvItems.Columns[3].Width = 100; dgvItems.Columns[3].DataPropertyName = "strRUC"; dgvItems.Columns[3].HeaderText = "RUC";
                
            }
            else if (tipoTabla == "CLIENTE")
            {
                dgvItems.ColumnCount = 6;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 80; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "Código";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 100; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "Nombre";
                dgvItems.Columns[3].Name = "strDireccion"; dgvItems.Columns[3].Width = 300; dgvItems.Columns[3].DataPropertyName = "strDireccion"; dgvItems.Columns[3].HeaderText = "Dirección";
                dgvItems.Columns[4].Name = "strRuc"; dgvItems.Columns[4].Width = 80; dgvItems.Columns[4].DataPropertyName = "strRuc"; dgvItems.Columns[4].HeaderText = "RUC";
                dgvItems.Columns[5].Name = "strDni"; dgvItems.Columns[5].Width = 80; dgvItems.Columns[5].DataPropertyName = "strDni"; dgvItems.Columns[5].HeaderText = "DNI";
            }
            else if (tipoTabla == "PEDIDO")
            {
                dgvItems.ColumnCount = 8;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 50; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 150; dgvItems.Columns[1].DataPropertyName = "strNoAlm"; dgvItems.Columns[1].HeaderText = "Almacen";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 50; dgvItems.Columns[2].DataPropertyName = "strSeriePedido"; dgvItems.Columns[2].HeaderText = "Serie";
                dgvItems.Columns[3].Name = "strNroPedido"; dgvItems.Columns[3].Width = 70; dgvItems.Columns[3].DataPropertyName = "strNroPedido"; dgvItems.Columns[3].HeaderText = "Numero";
                dgvItems.Columns[4].Name = "dttFecha"; dgvItems.Columns[4].Width = 80; dgvItems.Columns[4].DataPropertyName = "dttFecha"; dgvItems.Columns[4].HeaderText = "Fecha";
                dgvItems.Columns[5].Name = "dttFeDesp"; dgvItems.Columns[5].Width = 80; dgvItems.Columns[5].DataPropertyName = "dttFeDesp"; dgvItems.Columns[5].HeaderText = "Fecha Desp.";
                dgvItems.Columns[6].Name = "strNoCliente"; dgvItems.Columns[6].Width = 150; dgvItems.Columns[6].DataPropertyName = "strNoCliente"; dgvItems.Columns[6].HeaderText = "Cliente";
                dgvItems.Columns[7].Name = "strNoCondV"; dgvItems.Columns[7].Width = 150; dgvItems.Columns[7].DataPropertyName = "strNoCondV"; dgvItems.Columns[7].HeaderText = "Condic. Pago";

            }
            else if (tipoTabla == "UBIGEO")
            {
                dgvItems.ColumnCount = 5;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 80; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "Almacen";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 300; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "Serie";
                dgvItems.Columns[3].Name = "strNroPedido"; dgvItems.Columns[3].Width = 70; dgvItems.Columns[3].DataPropertyName = "strCoDepartamento"; dgvItems.Columns[3].HeaderText = "departamento"; dgvItems.Columns[3].Visible = false;
                dgvItems.Columns[4].Name = "dttFecha"; dgvItems.Columns[4].Width = 80; dgvItems.Columns[4].DataPropertyName = "strCoProvincia"; dgvItems.Columns[4].HeaderText = "provincia"; dgvItems.Columns[4].Visible = false;

            }
            else if (tipoTabla == "TIPOCAMBIO")
            {
                dgvItems.ColumnCount = 7;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 100; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "Precio Compra"; dgvItems.Columns[1].Visible = false;
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 100; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "Precio Venta"; dgvItems.Columns[2].Visible = false;

                dgvItems.Columns[3].Name = "decPrecioCompra"; dgvItems.Columns[3].Width = 100; dgvItems.Columns[3].DataPropertyName = "decPrecioCompra"; dgvItems.Columns[3].HeaderText = "Precio Compra";
                dgvItems.Columns[4].Name = "decPrecioVenta"; dgvItems.Columns[4].Width = 100; dgvItems.Columns[4].DataPropertyName = "decPrecioVenta"; dgvItems.Columns[4].HeaderText = "Precio Venta";
                dgvItems.Columns[5].Name = "strCoMoneda"; dgvItems.Columns[5].Width = 70; dgvItems.Columns[5].DataPropertyName = "strCoMoneda"; dgvItems.Columns[5].HeaderText = "Moneda"; 
                dgvItems.Columns[6].Name = "dttFeTipoCambio"; dgvItems.Columns[6].Width = 100; dgvItems.Columns[6].DataPropertyName = "dttFeTipoCambio"; dgvItems.Columns[6].HeaderText = "Fecha";

            }
            else if (tipoTabla == "NUMERADOR")
            {
                
                dgvItems.ColumnCount = 6;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 100; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo"; dgvItems.Columns[1].Visible = false;
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 100; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "nombre"; dgvItems.Columns[2].Visible = false;

                dgvItems.Columns[3].Name = "strSerie"; dgvItems.Columns[3].Width = 50; dgvItems.Columns[3].DataPropertyName = "strSerie"; dgvItems.Columns[3].HeaderText = "Serie";
                dgvItems.Columns[4].Name = "strNoOperacion"; dgvItems.Columns[4].Width = 250; dgvItems.Columns[4].DataPropertyName = "strNoOperacion"; dgvItems.Columns[4].HeaderText = "Operacion";
                dgvItems.Columns[5].Name = "strNoAlm"; dgvItems.Columns[5].Width = 200; dgvItems.Columns[5].DataPropertyName = "strNoAlm"; dgvItems.Columns[5].HeaderText = "Almacen";
                
            }
            else if (tipoTabla == "CUENTAPROVEEDOR")
            {

                dgvItems.ColumnCount = 7;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 100; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo"; dgvItems.Columns[1].Visible = false;
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 100; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "nombre"; dgvItems.Columns[2].Visible = false;

                dgvItems.Columns[3].Name = "strNoBancos"; dgvItems.Columns[3].Width = 250; dgvItems.Columns[3].DataPropertyName = "strNoBancos"; dgvItems.Columns[3].HeaderText = "Banco";
                dgvItems.Columns[4].Name = "strCoMoneda"; dgvItems.Columns[4].Width = 70; dgvItems.Columns[4].DataPropertyName = "strCoMoneda"; dgvItems.Columns[4].HeaderText = "Moneda";
                dgvItems.Columns[5].Name = "strNombProv"; dgvItems.Columns[5].Width = 200; dgvItems.Columns[5].DataPropertyName = "strNombProv"; dgvItems.Columns[5].HeaderText = "Proveedor";
                dgvItems.Columns[6].Name = "strNroCuenta"; dgvItems.Columns[6].Width = 150; dgvItems.Columns[6].DataPropertyName = "strNroCuenta"; dgvItems.Columns[6].HeaderText = "Nro. Cuenta";

            }
            else if (tipoTabla == "EMPRESA")
            {
                dgvItems.ColumnCount = 4;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 70; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 250; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "nombre";
                dgvItems.Columns[3].Name = "ruc"; dgvItems.Columns[3].Width = 100; dgvItems.Columns[3].DataPropertyName = "RUC"; dgvItems.Columns[3].HeaderText = "RUC";
            }
            else if (tipoTabla == "UNIDAD")
            {
                dgvItems.ColumnCount = 4;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 70; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 250; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "nombre";
                dgvItems.Columns[3].Name = "estado"; dgvItems.Columns[3].Width = 100; dgvItems.Columns[3].DataPropertyName = "estado"; dgvItems.Columns[3].HeaderText = "estado"; dgvItems.Columns[3].Visible = false;
            }
            else if (tipoTabla == "USUARIO")
            {
                dgvItems.ColumnCount = 4;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 70; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 250; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "nombre";
                dgvItems.Columns[3].Name = "estado"; dgvItems.Columns[3].Width = 100; dgvItems.Columns[3].DataPropertyName = "estado"; dgvItems.Columns[3].HeaderText = "estado"; dgvItems.Columns[3].Visible = false;
            }
            else if (tipoTabla == "ARTICULO")
            {
                dgvItems.ColumnCount = 6;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 70; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 280; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "nombre";
                dgvItems.Columns[3].Name = "SUBFAMILIA"; dgvItems.Columns[3].Width = 100; dgvItems.Columns[3].DataPropertyName = "SUBFAMILIA"; dgvItems.Columns[3].HeaderText = "SUBFAMILIA"; dgvItems.Columns[3].Visible = false;
                dgvItems.Columns[4].Name = "CLASIFICACION"; dgvItems.Columns[4].Width = 100; dgvItems.Columns[4].DataPropertyName = "CLASIFICACION"; dgvItems.Columns[4].HeaderText = "CLASIFICACION"; dgvItems.Columns[4].Visible = false;
                dgvItems.Columns[5].Name = "strCoUni"; dgvItems.Columns[5].Width = 70; dgvItems.Columns[5].DataPropertyName = "strCoUni"; dgvItems.Columns[5].HeaderText = "Unidad";
            }
            else if (tipoTabla == "PERIODO")
            {
                dgvItems.ColumnCount = 3;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; dgvItems.Columns[0].Width = 30; dgvItems.Columns[0].DataPropertyName = "Id"; dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; dgvItems.Columns[1].Width = 70; dgvItems.Columns[1].DataPropertyName = "codigo"; dgvItems.Columns[1].HeaderText = "codigo";
                dgvItems.Columns[2].Name = "nombre"; dgvItems.Columns[2].Width = 70; dgvItems.Columns[2].DataPropertyName = "nombre"; dgvItems.Columns[2].HeaderText = "codigo"; dgvItems.Columns[2].Visible = false;
            }
            else if (tipoTabla == "CENTRO_COSTO_BUSQUEDA")
            {
                dgvItems.ColumnCount = 4;
                dgvItems.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                // Set the column header names.
                dgvItems.Columns[0].Name = "Id"; 
                    dgvItems.Columns[0].Width = 30; 
                    dgvItems.Columns[0].DataPropertyName = "Id"; 
                    dgvItems.Columns[0].HeaderText = "Id";
                dgvItems.Columns[1].Name = "codigo"; 
                    dgvItems.Columns[1].Width = 70; 
                    dgvItems.Columns[1].DataPropertyName = "codigo"; 
                    dgvItems.Columns[1].HeaderText = "Código";
                dgvItems.Columns[2].Name = "nombre"; 
                    dgvItems.Columns[2].Width = 350; 
                    dgvItems.Columns[2].DataPropertyName = "nombre"; 
                    dgvItems.Columns[2].HeaderText = "Centro de Costo"; 
                    //dgvItems.Columns[2].Visible = false;
                dgvItems.Columns[3].Name = "strNivelCenCos";
                    dgvItems.Columns[3].Width = 70;
                    dgvItems.Columns[3].DataPropertyName = "strNivelCenCos";
                    dgvItems.Columns[3].HeaderText = "Nivel";
                    //dgvItems.Columns[2].Visible = false;
            }
        }

        #endregion
               
    }
}
