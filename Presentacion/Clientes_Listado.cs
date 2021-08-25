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
    
    public partial class Clientes_Listado : Form
    {
        public int idSeleccion;
        public int idUsuario;
        public int idEmpresa;
        public bool intAprobarCliente;

        System.Data.DataTable tbl = new System.Data.DataTable();
        BindingSource src = new BindingSource();

        public Clientes_Listado()
        {
            InitializeComponent();
        }

        private void Clientes_Listado_Load(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
            Clases.InicialCls.LeerXml();
            Listar();
            bindingNavigator1.BindingSource = src;
            Clases.Reglas.alternarColor(dgvLista);
        }
       


        #region ----- Botones -----

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            Clientes frm = new Clientes();
            frm.tipo = 1;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = idEmpresa;
            frm.strAccion = "NUEVO";
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
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdCliente"].Value);

            Clientes frm = new Clientes();
            frm.intIdCliente = idSeleccion;
            frm.idUsuario = idUsuario;
            frm.chkAprobado.Visible = intAprobarCliente;
            frm.tipo = 2;
            frm.strAccion = "EDITAR";
            frm.ShowDialog();
            Listar();
        }

        private void tsVer_Click(object sender, EventArgs e)
        {
            int idSeleccion;
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdCliente"].Value);
            Clientes frm = new Clientes();
            frm.intIdCliente = idSeleccion;
            frm.chkAprobado.Visible = intAprobarCliente;
            frm.tipo = 3;
            frm.ShowDialog();
            Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            bool blnTodoOK = false;
            int idSeleccion;
            Clases.InicialCls.LeerXml();
            idSeleccion = Convert.ToInt32(dgvLista.CurrentRow.Cells["intIdCliente"].Value);

            NGCliente obj = new NGCliente(Configuracion.Sistema.CadenaConexion);

            string message = "Estas Seguro de Eliminar este Cliente?";
            string caption = "Corfirmar Borrado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // MOSTRAR EL MENSAJE DE CONFIRMACION.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                obj.EliminarCliente(idSeleccion, idUsuario, ref blnTodoOK);

                if (blnTodoOK)
                {
                    MessageBox.Show("Cliente Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            frm.nombre_maestro = "CLIENTE"; //VALOR PARA CLIENTE
            frm.tipoTabla = "CLIENTE";
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
            //Reportes.rptMantenimiento frmRpt = new Reportes.rptMantenimiento();
            //rmRpt.Show();
        }

        private void tsExportar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = tbl;
            DataTable data = (DataTable)(dgvLista.DataSource);
            Clases.Reglas.ExportaExcel(data, "LISTA DE MARCAS REGISTRADAS");
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

            NGCliente obj = new NGCliente(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Cliente(ref blnTodoOK);

            
            src.DataSource = tbl;
            dgvLista.DataSource = src;

            if (dgvLista.RowCount <= 0)
            {
                tsEditar.Enabled = false;
                tsVer.Enabled = false;
                tsEliminar.Enabled = false;
                tsBuscar.Enabled = false;
                //tsActualizar.Enabled = false;
                tsImprimir.Enabled = false;
                tsExportar.Enabled = false;
            }
            if (dgvLista.RowCount > 0)
            {
                tsEditar.Enabled = true;
                tsVer.Enabled = true;
                tsEliminar.Enabled = true;
                tsBuscar.Enabled = true;
                //tsActualizar.Enabled = true;
                tsImprimir.Enabled = true;
                tsExportar.Enabled = true;
            }
        }

        private void ubicarGrilla(int yy)
        {

            string ss = yy.ToString();
            src.Position = src.Find("intIdCliente", ss);

        }

       
        #endregion

        


       

        

        

        

       

        

        

        

        

       


       

        

        
    }
}
