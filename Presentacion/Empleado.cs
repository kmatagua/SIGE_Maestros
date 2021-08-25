using System;
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
    public partial class Empleado : Form
    {
        public int intIdEmp;
        public int idUsuario;
        public int tipo;
        public int tipoEmpleado;

        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            if (tipoEmpleado == 2)
            {
                lblCanal.Visible = true;
                cbxCanal.Visible = true;
                this.Text = "Vendedores";
            }
            else
            {
                lblCanal.Visible = false;
                cbxCanal.Visible = false;
                this.Text = "Empleados";
            }
            Listar_Canal();
            if (tipo == 1)
            { //NUEVO
               
                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGEmpleado objNg = new Negocio.NGEmpleado(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarEmpleado(intIdEmp, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdEmp"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoEmp"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtDni.Text = tbl.Rows[0]["strDni"].ToString();
                if (tbl.Rows[0]["dttFecReg"] != DBNull.Value)
                {
                    dtpFechaReg.Value = Convert.ToDateTime(tbl.Rows[0]["dttFecReg"]);
                }
                txtTlf.Text = tbl.Rows[0]["strTlf"].ToString();
                txtTlfMovil.Text = tbl.Rows[0]["strTlfMovil"].ToString();
                txtCorreo.Text = tbl.Rows[0]["strCorreo"].ToString();
                txtDireccion.Text = tbl.Rows[0]["strDireccion"].ToString();
                cbxCanal.SelectedValue = tbl.Rows[0]["intIdCanalDist"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdCanalDist"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGEmpleado objNg = new Negocio.NGEmpleado(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarEmpleado(intIdEmp, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdEmp"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoEmp"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoEmp"].ToString();
                txtDni.Text = tbl.Rows[0]["strDni"].ToString();
                if (tbl.Rows[0]["dttFecReg"] != DBNull.Value)
                {
                    dtpFechaReg.Value = Convert.ToDateTime(tbl.Rows[0]["dttFecReg"]);
                }
                
                txtTlf.Text = tbl.Rows[0]["strTlf"].ToString();
                txtTlfMovil.Text = tbl.Rows[0]["strTlfMovil"].ToString();
                txtCorreo.Text = tbl.Rows[0]["strCorreo"].ToString();
                txtDireccion.Text = tbl.Rows[0]["strDireccion"].ToString();
                cbxCanal.SelectedValue = tbl.Rows[0]["intIdCanalDist"] is DBNull ? 0 : Convert.ToInt32(tbl.Rows[0]["intIdCanalDist"]);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                btnGuardar.Enabled = false;
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                dtpFechaReg.Enabled = false;
                txtDni.ReadOnly = true;
                txtDireccion.ReadOnly =true;
                txtTlf.ReadOnly = true;
                txtTlfMovil.ReadOnly = true;
                cbxCanal.Enabled = false;
                txtCorreo.ReadOnly = true;

                chkEstado.Enabled = false;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (intIdEmp == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Empleado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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
                ENEmpleado obj = new ENEmpleado();
                obj.strCoEmp = txtCodigo.Text.Trim();
                obj.strNoEmp = txtNombre.Text.Trim();
                obj.strTlf = txtTlf.Text.Trim();
                obj.strTlfMovil = txtTlfMovil.Text.Trim();
                obj.strCorreo = txtCorreo.Text.Trim();
                obj.strDni = txtDni.Text.Trim();
                obj.dttFecReg = dtpFechaReg.Value;
                obj.strDireccion = txtDireccion.Text.Trim();
                obj.intIdCanalDist = Convert.ToInt32(cbxCanal.SelectedValue);
                obj.intIdUsuCr = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);

                Negocio.NGEmpleado objNg = new Negocio.NGEmpleado(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarEmpleado(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Empleado guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENEmpleado obj = new ENEmpleado();
            obj.intIdEmp = intIdEmp;
            obj.strCoEmp = txtCodigo.Text.Trim();
            obj.strNoEmp = txtNombre.Text.Trim();
            obj.strTlf = txtTlf.Text.Trim();
            obj.strTlfMovil = txtTlfMovil.Text.Trim();
            obj.strCorreo = txtCorreo.Text.Trim();
            obj.strDni = txtDni.Text.Trim();
            obj.dttFecReg = dtpFechaReg.Value;
            obj.strDireccion = txtDireccion.Text.Trim();
            obj.intIdCanalDist = Convert.ToInt32(cbxCanal.SelectedValue);
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGEmpleado objNg = new Negocio.NGEmpleado(Configuracion.Sistema.CadenaConexion);

            objNg.EditarEmpleado(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Empleado Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        public void Listar_Canal()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo("CANAL", intIdEmp, ref pBlnTodoOk);

            cbxCanal.DisplayMember = "strNoCanalDist";
            cbxCanal.ValueMember = "intIdCanalDist";
            cbxCanal.DataSource = tbl;
        }
        
    }
}
