using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class Placa : Form
    {
        public int intIdPlaca;
        public int idUsuario;
        public int tipo;
        public int idEmpresa;
        public string nombreEmpresa;

        public int intIdTipoTransp;

        public Placa()
        {
            InitializeComponent();
        }

        private void Placa_Load(object sender, EventArgs e)
        {
            lblEmpresa.Text = nombreEmpresa;
            ListarComboTipoTransp();
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGPlaca objNg = new NGPlaca(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarPlaca(intIdPlaca, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdPlaca"].ToString();
                txtPlaca.Text = tbl.Rows[0]["strNoPlaca"].ToString();
                txtDescripcion.Text = tbl.Rows[0]["strDescripcion"].ToString();
                cbxTipoTransp.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTipoTransp"]);
                cbxTransInter.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTransInter"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtPlaca.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGPlaca objNg = new NGPlaca(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarPlaca(intIdPlaca, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdPlaca"].ToString();
                txtPlaca.Text = tbl.Rows[0]["strNoPlaca"].ToString();
                txtDescripcion.Text = tbl.Rows[0]["strDescripcion"].ToString();
                cbxTipoTransp.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTipoTransp"]);
                cbxTransInter.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdTransInter"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                cbxTipoTransp.Enabled = false;
                cbxTransInter.Enabled = false;
                btnGuardar.Enabled = false;
                txtPlaca.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                chkEstado.Enabled = false;


            }
        }
        
                      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdPlaca == 0)
            { //NUEVO
                if (txtPlaca.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Placa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtPlaca.Focus(); return; }
                if (txtDescripcion.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese una Descripción.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtPlaca.Focus(); return; }
               
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


        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENPlaca obj = new ENPlaca();
                obj.strNoPlaca = txtPlaca.Text.Trim();
                obj.strDescripcion = txtDescripcion.Text.Trim();
                obj.intIdUsuCr = idUsuario;
                obj.intIdTransInter = Convert.ToInt32(cbxTransInter.SelectedValue);
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGPlaca objNg = new Negocio.NGPlaca(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarPlaca(obj, ref mensaje, ref blnTodoOK);

                
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
                    MessageBox.Show("Placa guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENPlaca obj = new ENPlaca();
            obj.intIdPlaca = intIdPlaca;
            obj.strNoPlaca = txtPlaca.Text.Trim();
            obj.strDescripcion = txtDescripcion.Text.Trim();
            obj.intIdUsuMf = idUsuario;
            obj.intIdTransInter = Convert.ToInt32(cbxTransInter.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);

            Negocio.NGPlaca objNg = new Negocio.NGPlaca(Configuracion.Sistema.CadenaConexion);

            objNg.EditarPlaca(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Placa Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        public void ListarComboTipoTransp()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGTipoTransporte obj = new NGTipoTransporte(Configuracion.Sistema.CadenaConexion);
            tbl = obj.TipoTransp(ref blnTodoOK);

            cbxTipoTransp.DisplayMember = "strNoTipoTransp";
            cbxTipoTransp.ValueMember = "intIdTipoTransp";
            cbxTipoTransp.DataSource = tbl;
        }

        public void ListarComboTranspInter()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGTranspInter obj = new NGTranspInter(Configuracion.Sistema.CadenaConexion);
            tbl = obj.TranspInter(intIdTipoTransp, ref blnTodoOK);

            cbxTransInter.DisplayMember = "strNoTransInter";
            cbxTransInter.ValueMember = "intIdTransInter";
            cbxTransInter.DataSource = tbl;
        }

        private void cbxTipoTransp_SelectedIndexChanged(object sender, EventArgs e)
        {
            intIdTipoTransp = Convert.ToInt32(cbxTipoTransp.SelectedValue);
            ListarComboTranspInter();
        }
        

        
    }
}
