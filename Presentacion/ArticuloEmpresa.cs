﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using Negocio;
using System.Transactions;

namespace Presentacion
{
    public partial class ArticuloEmpresa : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        public int idFamilia;
        public int idSubFamilia;

        DataTable tabla = new DataTable();
        DataTable tabla_Art = new DataTable();

        DataTable tblEmpresa = new DataTable();
        BindingSource src = new BindingSource();
        BindingSource src2 = new BindingSource();

        public ArticuloEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("codigo");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("intIdArt");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["intIdArt"];
            tabla.PrimaryKey = colPk1;

            tabla_Art.Columns.Add("id_Art");
            tabla_Art.Columns.Add("codigo_Art");
            tabla_Art.Columns.Add("nombre_Art");
            tabla_Art.Columns.Add("idFamilia");
            tabla_Art.Columns.Add("idSubFamilia"); 
        }


        private void ArticuloEmpresa_Load(object sender, EventArgs e)
        {
            cbxEmpresa.SelectedIndexChanged -= cbxEmpresa_SelectedIndexChanged;

            ListarComboEmpresa();
            ListarArt();
            Clases.Reglas.alternarColor(dgvListaArt);
            Clases.Reglas.alternarColor(dgvListaArtAcc);
            //txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxEmpresa.SelectedIndexChanged += cbxEmpresa_SelectedIndexChanged;
        }

                  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarArt()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGArticulo obj = new NGArticulo(Configuracion.Sistema.CadenaConexion);
            tblEmpresa = obj.GridArtTodos(ref blnTodoOK);
            foreach (DataRow row1 in tblEmpresa.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Art.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Art"] = row1["intIdArt"].ToString();
                row["codigo_Art"] = row1["strCoArt"].ToString();
                row["nombre_Art"] = row1["strNoArt"].ToString();
                row["idFamilia"] = row1["intIdFamilia"].ToString();
                row["idSubFamilia"] = row1["intIdSubFamilia"].ToString();
                tabla_Art.Rows.Add(row);
            }
            src.DataSource = tabla_Art;
            dgvListaArt.DataSource = tabla_Art;
        }

        public void ListarArtAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblArtAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGArticulo obj = new NGArticulo(Configuracion.Sistema.CadenaConexion);
                int idEmpresa = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                tblArtAcc = obj.ArtAccesoEmp(idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblArtAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdArtEmp"].ToString();
                    row["codigo"] = row1["strCoArt"].ToString();
                    row["nombre"] = row1["strNoArt"].ToString();
                    row["intIdArt"] = row1["intIdArt"].ToString();
                    tabla.Rows.Add(row);
                }
                src2.DataSource = tabla;
                dgvListaArtAcc.DataSource = tabla;
            }
        }

        public void ListarComboEmpresa()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tblEmpresa = obj.ComboEmpresa(ref blnTodoOK);

            cbxEmpresa.DataSource = tblEmpresa;
            cbxEmpresa.DisplayMember = "strNoEmp";
            cbxEmpresa.ValueMember = "intIdEmp";
            //src.DataSource = tblEmpresa;
            //dgvLista.DataSource = src;


        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdArt = Convert.ToInt32(dgvListaArt.CurrentRow.Cells["id_Art"].Value);
            string strCoArt = dgvListaArt.CurrentRow.Cells["codigo_Art"].Value.ToString();
            string strNoArt = dgvListaArt.CurrentRow.Cells["nombre_Art"].Value.ToString();
            if (Convert.ToInt32(cbxEmpresa.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdArt == Convert.ToInt32(row2["intIdArt"].ToString()))
                {
                    MessageBox.Show("El Articulo ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strCoArt, strNoArt, intIdArt });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaArtAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {            
            if (dgvListaArtAcc.Rows.Count > 0)
            {
               
                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaArtAcc.CurrentRow.Cells["id"].Value);

                NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Articulo?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.Borrar(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Articulo Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarArtAcc();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxEmpresa.SelectedValue) == 0)
            { MessageBox.Show("Debe Elegir un Almacen.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Insertar();
            tabla.Clear();
            ListarArtAcc();
        }

        public void Insertar()
        {
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    bool blnTodoOK = false;
                    Clases.InicialCls.LeerXml();

                    NGEmpresa objNgEmp = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
                    int intIdEmpresa = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                    
                    objNgEmp.InsertarArtEmpresa(intIdEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Articulo Agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cbxAlmacen.SelectedValue = 0;
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
            txtIdEmp.Text = valor.ToString();
            tabla.Clear();
            ListarArtAcc();
        }

        public void Listar_Almacen_Filtro()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            //tbl = objNg.Listar_Combo2("ALMACEN_SEDE", 0, 0, idUsuario, 0, Convert.ToInt32(cbxSede.SelectedValue), ref pBlnTodoOk);

            cbxEmpresa.DisplayMember = "strNoAlm";
            cbxEmpresa.ValueMember = "intIdAlm";
            cbxEmpresa.DataSource = tbl;

        }

        private void txtFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "FAMILIA";
                frm.tipoTabla = "FAMILIA";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idFamilia = frm.idEncontrado;
                    txtFamilia.Text = frm.nombreEncontrado;
                    txtSubFamilia.Focus();
                    filtrar();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtFamilia.Clear();
                idFamilia = 0;
                txtSubFamilia.Clear();
                idSubFamilia = 0;
                filtrar();
            }
        }

        private void txtSubFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SUBFAMILIA2";
                frm.tipoTabla = "FAMILIA";
                frm.intId = idFamilia;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSubFamilia = frm.idEncontrado;
                    txtSubFamilia.Text = frm.nombreEncontrado;
                    filtrar();
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress                                
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtSubFamilia.Clear();
                idSubFamilia = 0;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
            lblfiltro.Text = txtBuscar.Text;
        }

        public void filtrar()
        {
            int intIdFamilia = idFamilia;
            int intIdSubFamilia = idSubFamilia;

            if (intIdFamilia > 0 && intIdSubFamilia > 0)
            {
                src.Filter = "idFamilia = '" + intIdFamilia + "' AND idSubFamilia = '" + intIdSubFamilia + "' AND (nombre_Art LIKE '%"+ txtBuscar.Text+"%' OR codigo_Art LIKE '%"+ txtBuscar.Text+"%')";
            }
            if (intIdFamilia > 0 && intIdSubFamilia <= 0)
            {
                src.Filter = "idFamilia = '" + intIdFamilia + "' AND (nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%')";
            }
            if (intIdFamilia <= 0 && intIdSubFamilia > 0)
            {
                src.Filter = "idSubFamilia = '" + intIdSubFamilia + "' AND (nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%')";
            }
            if (intIdFamilia <= 0 && intIdSubFamilia <= 0)
            {
                src.Filter = "nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%'";
            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            src.Filter = string.Format("nombre_Art LIKE '%" + txtBuscar.Text + "%' OR codigo_Art LIKE '%" + txtBuscar.Text + "%'");
            dgvListaArt.Refresh();
            lblfiltro.Text = txtBuscar.Text;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFiltrar.PerformClick();

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtFamilia.Clear();
            idFamilia = 0;
            txtSubFamilia.Clear();
            idSubFamilia = 0;
            filtrar();
        }

        private void txtBuscar2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar2.PerformClick();

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            src2.Filter = string.Format("nombre LIKE '%{0}%' or codigo LIKE '%{0}%'", txtBuscar2.Text);
            dgvListaArtAcc.Refresh();
            lblFiltro2.Text = txtBuscar2.Text;
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            txtBuscar2.Clear();
            btnBuscar2.PerformClick();
        }

    }
}
