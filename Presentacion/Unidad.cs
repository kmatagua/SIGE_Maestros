﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;

namespace Presentacion
{
    public partial class Unidad : Form
    {
        public int intIdUni;
        public int tipo;
        public int idUsuario;
        public int idEmpresa;

        public Unidad()
        {
            InitializeComponent();
        }

        private void Unidad_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGUnidad objNg = new Negocio.NGUnidad(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUnidad(intIdUni, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdUni"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUni"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUni"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGUnidad objNg = new Negocio.NGUnidad(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUnidad(intIdUni, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdUni"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUni"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUni"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdUni == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Unidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
                Insertar();
            }
            else //Editar
            {
                Editar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENUnidad obj = new ENUnidad();
                obj.strCoUni = txtCodigo.Text.Trim();
                obj.strNoUni = txtNombre.Text.Trim();
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGUnidad objNg = new Negocio.NGUnidad(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarUnidad(obj, idEmpresa, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Unidad guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Editar()
        {

            bool blnTodoOK = false;
            ENUnidad obj = new ENUnidad();
            obj.intIdUni = intIdUni;
            obj.strCoUni = txtCodigo.Text.Trim();
            obj.strNoUni = txtNombre.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGUnidad objNg = new Negocio.NGUnidad(Configuracion.Sistema.CadenaConexion);

            objNg.EditarUnidad(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Unidad Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        #endregion

        

        
    }
}
