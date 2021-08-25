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
    
    public partial class Familia_Listado : Form
    {
        public int idSeleccion;
        public int idUsuario;
        public int idEmpresa;

        System.Data.DataTable tbl = new System.Data.DataTable();
        BindingSource src = new BindingSource();
        public Familia_Listado()
        {
            InitializeComponent();
        }

        private void Familia_Listado_Load(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
            Clases.InicialCls.LeerXml();
            ListarComboClasificacion();
            Listar();
            bindingNavigator1.BindingSource = src;
            Clases.Reglas.alternarColor(dgvLista);
        }
        
        

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            Familia frm = new Familia();
            frm.tipo = 1;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = idEmpresa;
            frm.ShowDialog();
            Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdFamilia"].Value);

            Familia frm = new Familia();
            frm.intIdFamilia = idSeleccion;
            frm.tipo = 2;
            frm.ShowDialog();
            Listar();
        }

        private void tsVer_Click(object sender, EventArgs e)
        {
            int idSeleccion;
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdFamilia"].Value);
            Familia frm = new Familia();
            frm.intIdFamilia = idSeleccion;
            frm.tipo = 3;
            frm.ShowDialog();
            Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            bool blnTodoOK = false;
            int idSeleccion;
            Clases.InicialCls.LeerXml();
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdFamilia"].Value);

            NGFamilia obj = new NGFamilia(Configuracion.Sistema.CadenaConexion);

            string message = "Estas Seguro de Eliminar esta Familia?";
            string caption = "Corfirmar Borrado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // MOSTRAR EL MENSAJE DE CONFIRMACION.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                obj.EliminarFamilia(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Familia Eliminada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Listar();
            }


        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.nombre_maestro = "FAMILIA"; //VALOR PARA FAMILIA
            frm.tipoTabla = "GENERAL";
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
            Reportes.rptMantenimiento frmRpt = new Reportes.rptMantenimiento();
            frmRpt.nombreRpt = "FAMILIA";
            frmRpt.Show();
        }

        private void tsExportar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = tbl;
            DataTable data = (DataTable)(dgvLista.DataSource);
            Clases.Reglas.ExportaExcel(data, "LISTA DE FAMILIAS REGISTRADAS");
            dgvLista.DataSource = src;
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Listar()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGFamilia obj = new NGFamilia(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Familia(idEmpresa, ref blnTodoOK);

            src.DataSource = tbl;
            dgvLista.DataSource = src;

            if (Convert.ToInt32(cbxFiltro.SelectedValue) == 0)
            {
                src.Filter = "";
            }
            else
            {
                src.Filter = "strNoClaArt = '" + cbxFiltro.Text + "'";
            }

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
            src.Position = src.Find("intIdFamilia", ss);

        }


        public void ListarComboClasificacion()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGClaArt obj = new NGClaArt(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ClasificacionCombo(ref blnTodoOK);
            cbxFiltro.DisplayMember = "strNoClaArt";
            cbxFiltro.ValueMember = "intIdClaArt";
            cbxFiltro.DataSource = tbl;

        }

        private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar();
        }

        
    }
}
