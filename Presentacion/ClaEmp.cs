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
    public partial class ClaEmp : Form
    {
        public int intIdClaEmp;
        public int tipo;
        public int idUsuario;

        public ClaEmp()
        {
            InitializeComponent();
        }


        private void ClaEmp_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            { //NUEVO

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGClaEmp objNg = new Negocio.NGClaEmp(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarClaEmp(intIdClaEmp, ref blnTodoOK);
                txtIdEmp.Text = tbl.Rows[0]["intIdClaEmp"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoClaEmp"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoClaEmp"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);


                txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                Negocio.NGClaEmp objNg = new Negocio.NGClaEmp(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarClaEmp(intIdClaEmp, ref blnTodoOK);

                txtIdEmp.Text = tbl.Rows[0]["intIdClaEmp"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoClaEmp"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoClaEmp"].ToString();
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

            if (intIdClaEmp == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Clasificación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
               
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


        #region --- FUNCIONES --- 

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENClaEmp obj = new ENClaEmp();
                obj.strCoClaEmp = txtCodigo.Text.Trim();
                obj.strNoClaEmp = txtNombre.Text.Trim();
                obj.strDisplay = txtDisplay.Text.Trim();
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGClaEmp objNg = new Negocio.NGClaEmp(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarClaEmp(obj, ref mensaje, ref blnTodoOK);

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
                    MessageBox.Show("Clasificación guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENClaEmp obj = new ENClaEmp();
            obj.intIdClaEmp = intIdClaEmp;
            obj.strCoClaEmp = txtCodigo.Text.Trim();
            obj.strNoClaEmp = txtNombre.Text.Trim();
            obj.strDisplay = txtDisplay.Text.Trim();
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;
            
            Negocio.NGClaEmp objNg = new Negocio.NGClaEmp(Configuracion.Sistema.CadenaConexion);

            objNg.EditarClaEmp(obj, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("ClaEmp Editada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
