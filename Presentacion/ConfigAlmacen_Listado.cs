﻿using System;
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
    
    public partial class ConfigAlmacen_Listado : Form
    {
        public int idSeleccion;
        public int idUsuario;
        public int idEmpresa;
        public string nombreEmpresa;
        
        System.Data.DataTable tbl = new System.Data.DataTable();
        BindingSource src = new BindingSource();

        public ConfigAlmacen_Listado()
        {
            InitializeComponent();
        }

        private void ConfigAlmacen_Listado_Load(object sender, EventArgs e)
        {                                              
            //this.WindowState = FormWindowState.Maximized;
            Clases.InicialCls.LeerXml();

            Listar();
            bn1.BindingSource = src;
            Clases.Reglas.alternarColor(dgvLista);
        }

               

        #region ----- Botones -----

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            Config_Almacen frm = new Config_Almacen();
            frm.tipo = 1;
            frm.idEmpresa = idEmpresa;
            frm.nombreEmpresa = nombreEmpresa;
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
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdAlm"].Value);
            
            Config_Almacen frm = new Config_Almacen();
            frm.intIdAlm = idSeleccion;
            frm.idEmpresa = idEmpresa;
            frm.nombreEmpresa = nombreEmpresa;
            frm.tipo = 2;
            frm.idUsuario = idUsuario;
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
            
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdAlm"].Value);
            Config_Almacen frm = new Config_Almacen();
            frm.intIdAlm = idSeleccion;
            frm.idEmpresa = idEmpresa;
            frm.nombreEmpresa = nombreEmpresa;
            frm.tipo = 3;
            frm.idUsuario = idUsuario;
            frm.ShowDialog();
            Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            bool blnTodoOK = false;
            int idSeleccion;
            Clases.InicialCls.LeerXml();
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intId"].Value);

            NGAlmacen obj = new NGAlmacen(Configuracion.Sistema.CadenaConexion);

            string message = "Estas Seguro de Eliminar este Almacen?";
            string caption = "Corfirmar Borrado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // MOSTRAR EL MENSAJE DE CONFIRMACION.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                obj.EliminarAlmacen(idSeleccion, idUsuario, ref blnTodoOK);

                if (blnTodoOK)
                {
                    MessageBox.Show("Configuracion de Almacen Eliminada con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Busqueda frm = new Busqueda();
            frm.nombre_maestro = "ALMACEN"; 
            frm.intId = idEmpresa;
            frm.intIdUsu = idUsuario;

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
            frmRpt.nombreRpt = "ALMACEN";
            frmRpt.idEmpresa = idEmpresa;
            frmRpt.Show();
        }

        private void tsExportar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = tbl;
            DataTable data = (DataTable)(dgvLista.DataSource);
            Clases.Reglas.ExportaExcel(data, "LISTA DE ALMACENES REGISTRADOS");
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

            NGAlmacen obj = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ConfigAlmacen(idEmpresa, idUsuario, ref blnTodoOK);

            
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
            src.Position = src.Find("intId", ss);
            
        }

        #endregion

        

    }
}
