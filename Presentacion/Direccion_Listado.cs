using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Direccion_Listado : Form
    {
        public string codigoCliente;
        public string nombreCliente;
        public int intIdEmp;
        public int intIdUsu;
        
        

        DataTable dtable = new DataTable();
        BindingSource src = new BindingSource();

        public Direccion_Listado()
        {
            InitializeComponent();
        }

        private void Direccion_Listado_Load(object sender, EventArgs e)
        {
            //*******************************************************************************
            //intIdUsu = 10;
            //intIdEmp = 2;
            //intIdSede = 2;
            //intIdTipoOpe = 2;
            //*******************************************************************************
            string anio = DateTime.Today.ToString("yyyy");
            string mes = DateTime.Today.ToString("MM");
            alternarColor(dgvListado);
            EnlazaComponentes();
            //Listar_Periodo(anio + mes);
            Listar();
        }

            
        private void tsNuevo_Click(object sender, EventArgs e)
        {
            Direccion frm = new Direccion();            
            //frm.intIdUsu = intIdUsu;
            //frm.intIdEmp = intIdEmp;
            //frm.intIdTipoOrden = intIdTipoOrden;
            //frm.strAccion = "NUEVO";
            //frm.intIdPeriodo = intIdPeriodo;
            //frm.strCoPeriodo = strCoPeriodo;
            frm.ShowDialog();
            Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count <= 0)
                return;

            int intIdPedido = Convert.ToInt32(dgvListado.CurrentRow.Cells["intIdDireccionCliente"].Value);

            if (intIdPedido <= 0)
            { MessageBox.Show("Seleccione un Pedido para Editar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            ////Pedido frm = new Pedido();
            //frm.intIdUsu = intIdUsu;
            //frm.intIdEmp = intIdEmp;
            //frm.p_intIdPedido = intIdPedido;
            //frm.strAccion = "EDITAR";
            ////frm.intIdPeriodo = intIdPeriodo;
            ////frm.strCoPeriodo = strCoPeriodo;
            //frm.ShowDialog();
            Listar();
        }

        private void tsVer_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count <= 0)
                return;

            int intIdOrdCom = Convert.ToInt32(dgvListado.CurrentRow.Cells["intIdPedido"].Value);

            if (intIdOrdCom <= 0)
            { MessageBox.Show("Seleccione una Orden de Compra para Ver", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                //Pedido frm = new Pedido();
                //Pedido frm = new Pedido();
                // frm.intIdUsu = intIdUsu;
                //frm.intIdEmp = intIdEmp;
                ////frm.intIdSede = intIdSede;
                ////frm.intIdTipoOrden = intIdTipoOrden;
                //frm.p_intIdPedido = intIdOrdCom;
                //frm.strAccion = "VER";
                ////frm.intIdPeriodo = intIdPeriodo;
                ////frm.strCoPeriodo = strCoPeriodo;
                //frm.ShowDialog();
            Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count <= 0)
                return;            

            if (MessageBox.Show("¿Desea Eliminar el Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int intIdPedido = Convert.ToInt32(dgvListado.CurrentRow.Cells["intIdPedido"].Value);
            string mensaje = string.Empty;
            bool pBlnTodoOk = false;

            if (intIdPedido <= 0)
            { MessageBox.Show("Seleccione un Pedido para eliminar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            Clases.InicialCls.LeerXml();
            //Negocio.NGPedido objNego = new NGPedido(Configuracion.Sistema.CadenaConexion);
            //objNego.EliminarPedido(intIdPedido, intIdUsu, ref mensaje, ref pBlnTodoOk);
            if (!pBlnTodoOk)
            { MessageBox.Show("Hubo un Error al consultar la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if(mensaje != string.Empty)
            { MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            MessageBox.Show("Se eliminó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            if (dgvListado.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Buscar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Busqueda frm = new Busqueda(); 
            frm.nombre_maestro = "PEDIDO";
            frm.intId = intIdEmp;
            //frm.intIdUsu = intIdPeriodo;
            frm.tipoTabla = "PEDIDO";
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.idEncontrado == 0) return;
                int xbuscar = frm.idEncontrado;
                ubicarGrilla(xbuscar);
                tsEditar.PerformClick();
            }
        }

        private void tsActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsImprimir_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count <= 0)
                return;
            
            //rptVisorReporte frm = new rptVisorReporte();
            //frm.intIdEmp = intIdEmp;
            ////frm.intIdTipoOpe = intIdTipoOpe;
            ////frm.intIdPeriodo = intIdPeriodo;
            ////frm.strNoEmpresa = strNoEmpresa;
            //frm.strNombreRpt = "PEDIDO";
            //frm.Show();

        }

        private void tsExportar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count <= 0)
                return;

            DataTable data = (DataTable)(src.DataSource);
            Clases.Reglas.ExportaExcel(data, "Listado de Pedidos");
            
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsPeriodo_Click(object sender, EventArgs e)
        {
            Periodo frm = new Periodo();
            //frm.p_intIdPeriodo = intIdPeriodo;
            //frm.p_strCoPeriodo = strCoPeriodo;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //intIdPeriodo= frm.p_intIdPeriodo;
                //strCoPeriodo = frm.p_strCoPeriodo;

                //lblPeriodo.Text = "Periodo: " + strCoPeriodo.Substring(0, 4) + " / " + strCoPeriodo.Substring(4, 2);
                Listar();
            }
        }

        private void ubicarGrilla(int yy)
        {
            string ss = yy.ToString();
            src.Position = src.Find("intIdPedido", ss);
        }

        public void Listar()
        {
            Clases.InicialCls.LeerXml();
            //**************************************************************************************************            
            bool pBlnTodoOk = false;
            DataTable dtable = new DataTable();

            Negocio.NGCliente obj = new Negocio.NGCliente(Configuracion.Sistema.CadenaConexion);
            //dtable = obj.ListarPedido(intIdEmp, intIdPeriodo, ref pBlnTodoOk);
            //if (!pBlnTodoOk)
            //{ MessageBox.Show("Hubo un Error al consultar la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            src.DataSource = dtable;
            dgvListado.DataSource = src;
        }

        //public void Listar_Periodo(string p_strCoPeriodo)
        //{
        //    Clases.InicialCls.LeerXml();
        //    //**************************************************************************************************            
        //    bool pBlnTodoOk = false;
        //    DataTable tbl = new DataTable();
        //    NGPedido objNeg = new NGPedido(Configuracion.Sistema.CadenaConexion);
        //    tbl = objNeg.Listar_Periodo(p_strCoPeriodo, ref pBlnTodoOk);
        //    if (!pBlnTodoOk)
        //    { MessageBox.Show("Hubo un Error al consultar la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

        //    //intIdPeriodo = Convert.ToInt32(tbl.Rows[0]["intIdPeriodo"]);
        //    //strCoPeriodo = tbl.Rows[0]["strCoPeriodo"].ToString();

        //    //lblPeriodo.Text = "Periodo: " + strCoPeriodo.Substring(0, 4) + " / " + strCoPeriodo.Substring(4, 2);
        //}

        public void alternarColor(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0ECF8");
            //dgv.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0174DF");
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
         
        }

        private void EnlazaComponentes()
        {
            binNvgListado.BindingSource = src;
        }

       

        

       

    }
}
