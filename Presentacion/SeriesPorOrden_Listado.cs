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
    
    public partial class SeriesPorOrden_Listado : Form
    {
        public int idSeleccion;
        public int idEmpresa;
        public int idUsuario;

        System.Data.DataTable tbl = new System.Data.DataTable();
        BindingSource src = new BindingSource();
        public SeriesPorOrden_Listado()
        {
            InitializeComponent();
        }

        private void SeriesPorOrden_Listado_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            Clases.InicialCls.LeerXml();

            Listar(idEmpresa);
            bindingNavigator1.BindingSource = src;
            Clases.Reglas.alternarColor(dgvLista);
        }

         

        #region ----- Botones -----

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            SeriesPorOrden frm = new SeriesPorOrden();
            frm.tipo = 1;
            frm.idUsuario = idUsuario;
            frm.ShowDialog();
            Listar(idEmpresa);
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdSede"].Value);

            Sede frm = new Sede();
            frm.intIdSede = idSeleccion;
            frm.tipo = 2;
            frm.idUsuario = idUsuario;
            frm.ShowDialog();
            Listar(idEmpresa);
        }

        private void tsVer_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Ver.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idSeleccion;
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdSede"].Value);
            Sede frm = new Sede();
            frm.intIdSede = idSeleccion;
            frm.tipo = 3;
            frm.idUsuario = idUsuario;
            frm.ShowDialog();
            Listar(idEmpresa);
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            bool blnTodoOK = false;
            int idSeleccion;
            Clases.InicialCls.LeerXml();
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdSede"].Value);

            NGSede obj = new NGSede(Configuracion.Sistema.CadenaConexion);

            string message = "Estas Seguro de Eliminar esta Sede?";
            string caption = "Corfirmar Borrado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // MOSTRAR EL MENSAJE DE CONFIRMACION.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                obj.EliminarSede(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Sede Eliminada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Listar(idEmpresa);
            }

            
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.nombre_maestro = "SEDE"; //VALOR PARA SEDE
            frm.intId = idEmpresa;

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
            Listar(idEmpresa);
        }

        private void tsImprimir_Click(object sender, EventArgs e)
        {
            Reportes.rptMantenimiento frmRpt = new Reportes.rptMantenimiento();
            frmRpt.nombreRpt = "SEDE";
            frmRpt.idEmpresa = idEmpresa;
            frmRpt.Show();
        }

        private void tsExportar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = tbl;
            DataTable data = (DataTable)(dgvLista.DataSource);
            Clases.Reglas.ExportaExcel(data, "LISTA DE SERIES REGISTRADAS");
            dgvLista.DataSource = src;
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ----- Funciones o Metodos -----

        public void Listar(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGSerie obj = new NGSerie(Configuracion.Sistema.CadenaConexion);
            tbl = obj.SeriePorOrden(idEmpresa, ref blnTodoOK);

            
            src.DataSource = tbl;
            dgvLista.DataSource = src;

            if (dgvLista.RowCount <= 0)
            {
                tsEditar.Enabled = false;
                tsVer.Enabled = false;
                tsEliminar.Enabled = false;
                tsBuscar.Enabled = false;
                tsActualizar.Enabled = false;
                tsImprimir.Enabled = false;
                tsExportar.Enabled = false;
            }
            if (dgvLista.RowCount > 0)
            {
                tsEditar.Enabled = true;
                tsVer.Enabled = true;
                tsEliminar.Enabled = true;
                tsBuscar.Enabled = true;
                tsActualizar.Enabled = true;
                tsImprimir.Enabled = true;
                tsExportar.Enabled = true;
            }
        }

        private void ubicarGrilla(int yy)
        {

            string ss = yy.ToString();
            src.Position = src.Find("intIdSeriesPorOrden", ss);
            
        }

       
        #endregion

        

        

       

        

        

        

        

       


       

        

        
    }
}
