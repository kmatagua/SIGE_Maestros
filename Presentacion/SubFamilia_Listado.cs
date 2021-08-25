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
    public partial class SubFamilia_Listado : Form
    {
        
        public int idSeleccion;
        public int idFamilia;
        public int idUsuario;
        public int idEmpresa;

        System.Data.DataTable tbl = new System.Data.DataTable();
        BindingSource src = new BindingSource();

        public SubFamilia_Listado()
        {
            InitializeComponent();
        }


        private void SubFamilia_Listado_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            Clases.InicialCls.LeerXml();
            Listar();
            bindingNavigator1.BindingSource = src;
            Clases.Reglas.alternarColor(dgvLista);
        }
        
               

        #region ----- Botones -----

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            SubFamilia frm = new SubFamilia();
            frm.tipo = 1;
            frm.idFamilia = idFamilia;
            frm.idUsuario = idUsuario;
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
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdSubFamilia"].Value);
            
            SubFamilia frm = new SubFamilia();
            frm.intIdSubFamilia = idSeleccion;
            frm.idFamilia = idFamilia;
            frm.idUsuario = idUsuario;
            frm.tipo = 2;
            frm.ShowDialog();
            Listar();
        }

        private void tsVer_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Ver.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idSeleccion;
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdSubFamilia"].Value);
            SubFamilia frm = new SubFamilia();
            frm.intIdSubFamilia = idSeleccion;
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
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdSubFamilia"].Value);

            NGSubFamilia obj = new NGSubFamilia(Configuracion.Sistema.CadenaConexion);

            string message = "Estas Seguro de Eliminar este SubFamilia?";
            string caption = "Corfirmar Borrado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // MOSTRAR EL MENSAJE DE CONFIRMACION.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                obj.EliminarSubFamilia(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Empresa Eliminada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Listar();
            }

            
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.nombre_maestro = "SUBFAMILIA"; //VALOR PARA SUB FAMILIA
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
            frmRpt.nombreRpt = "SUBFAMILIA";
            frmRpt.Show();
        }

        
        private void tsExportar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = tbl;
            DataTable data = (DataTable)(dgvLista.DataSource);
            Clases.Reglas.ExportaExcel(data, "LISTA DE SUB FAMILIAS REGISTRADOS");
            dgvLista.DataSource = src;
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ----- Funciones o Metodos -----

        public void Listar()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGSubFamilia obj = new NGSubFamilia(Configuracion.Sistema.CadenaConexion);
            tbl = obj.SubFamilia(ref blnTodoOK);

            
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
            src.Position = src.Find("intIdSubFamilia", ss);
            
        }

        
        #endregion

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {
            int intIdFamilia = idFamilia;

            if (intIdFamilia > 0)
            {
                src.Filter = "intIdFamilia = '" + intIdFamilia + "'";
            }
            //if (intIdFamilia <= 0)
            //{
            //    src.Filter = "strNoFamilia LIKE '%" + txtFamilia.Text.Trim() + "%'";
            //}
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFamilia.Clear();
            idFamilia = 0;
            src.Filter = "";
            //filtrar();
            
        }

        private void txtFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "FAMILIA";
                frm.tipoTabla = "GENERAL";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idFamilia = frm.idEncontrado;
                    txtFamilia.Text = frm.nombreEncontrado;
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtFamilia.Clear();
                idFamilia = 0;
            }
        }
        
        
    }
}
