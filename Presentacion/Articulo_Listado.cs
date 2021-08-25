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
    public partial class Articulo_Listado : Form
    {
        
        public int idSeleccion;
        public int idUsuario;
        public int idEmpresa;

        public int idFamilia;
        public int idSubFamilia;

        System.Data.DataTable tbl = new System.Data.DataTable();
        BindingSource src = new BindingSource();

        public Articulo_Listado()
        {
            InitializeComponent();
        }

        private void Articulo_Listado_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            Clases.InicialCls.LeerXml();
            Listar();
            bindingNavigator1.BindingSource = src;
            Clases.Reglas.alternarColor(dgvLista);
            
        }
        
        private void tsNuevo_Click(object sender, EventArgs e)
        {
               
            Articulo frm = new Articulo();
            frm.tipo = 1;
            frm.idSubFamilia = idSubFamilia;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = idEmpresa;
            frm.ShowDialog();
            Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Editar.", this.Text ,MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; 
            }
            
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdArt"].Value);
            
            Articulo frm = new Articulo();
            frm.intIdArticulo = idSeleccion;
            frm.idSubFamilia = idSubFamilia;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = idEmpresa;
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
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdArt"].Value);
            Articulo frm = new Articulo();
            frm.intIdArticulo = idSeleccion;
            frm.idEmpresa = idEmpresa;
            frm.idUsuario = idUsuario;
            frm.tipo = 3;
            frm.ShowDialog();
            Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Eliminar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool blnTodoOK = false;
            int idSeleccion;
            Clases.InicialCls.LeerXml();
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdArt"].Value);

            NGArticulo obj = new NGArticulo(Configuracion.Sistema.CadenaConexion);

            string message = "Estas Seguro de Eliminar este Articulo?";
            string caption = "Corfirmar Borrado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // MOSTRAR EL MENSAJE DE CONFIRMACION.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                obj.EliminarArticulo(idSeleccion, idUsuario, ref blnTodoOK);

                if (blnTodoOK)
                {
                    MessageBox.Show("Articulo Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Listar();
            }

            
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount <= 0)
            {
                MessageBox.Show("No hay registros para Buscar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Busqueda frm = new Busqueda();
            frm.nombre_maestro = "ARTICULO";
            frm.tipoTabla = "ARTICULO";
            frm.idEmpresa = idEmpresa;

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
            frmRpt.nombreRpt = "ARTICULO";
            frmRpt.idUsuario = idUsuario;
            frmRpt.idEmpresa = idEmpresa;
            frmRpt.idFamilia = idFamilia;
            frmRpt.Show();
        }
               
        private void tsExportar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = tbl;
            DataTable data = (DataTable)(dgvLista.DataSource);
            Clases.Reglas.ExportaExcel(data, "LISTA DE ARTICULOS REGISTRADOS");
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

            NGArticulo obj = new NGArticulo(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Articulo(idEmpresa, idUsuario, ref blnTodoOK);

            
            src.DataSource = tbl;
            //dgvLista.DataSource = tbl;

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
            src.Position = src.Find("intIdArt", ss);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {
            int intIdFamilia = idFamilia;
            int intIdSubFamilia = idSubFamilia;

            if (intIdFamilia > 0 && intIdSubFamilia > 0)
            {
                src.Filter = "intIdFamilia = '" + intIdFamilia + "' AND intIdSubFamilia = '" + intIdSubFamilia + "' AND " + "strNoArt LIKE '%" + txtBuscar.Text.Trim() + "%'";
            }
            if (intIdFamilia > 0 && intIdSubFamilia <= 0)
            {
                src.Filter = "intIdFamilia = '" + intIdFamilia + "' AND " + "strNoArt LIKE '%" + txtBuscar.Text.Trim() + "%'";
            }
            if (intIdFamilia <= 0 && intIdSubFamilia > 0)
            {
                src.Filter = "intIdSubFamilia = '" + intIdSubFamilia + "' AND " + "strNoArt LIKE '%" + txtBuscar.Text.Trim() + "%'";
            }
            if (intIdFamilia <= 0 && intIdSubFamilia <= 0)
            {
                src.Filter = "strNoArt LIKE '%" + txtBuscar.Text.Trim() + "%'";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFamilia.Clear();
            idFamilia = 0;
            txtSubFamilia.Clear();
            idSubFamilia = 0;
            txtBuscar.Clear();
            filtrar();
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
                    txtSubFamilia.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtFamilia.Clear();
                idFamilia = 0;
                txtSubFamilia.Clear();
                idSubFamilia = 0;
            }
        }

        private void txtSubFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SUBFAMILIA2";
                frm.tipoTabla = "GENERAL";
                frm.intId = idFamilia;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSubFamilia = frm.idEncontrado;
                    txtSubFamilia.Text = frm.nombreEncontrado;
                    //txtSubFamilia.Focus();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtSubFamilia.Clear();
                idSubFamilia = 0;
            }
        }
    }
}
