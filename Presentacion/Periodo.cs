using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using System.Transactions;

namespace Presentacion
{
    public partial class Periodo : Form
    {
        public int intIdPeriodo;
        public int intIdEmp;
        public int tipo;
        public int idUsuario;
        public string strAccion;

        public Periodo()
        {
            InitializeComponent();
        }


        private void Periodo_Load(object sender, EventArgs e)
        {            
            if (tipo == 1)
            { //NUEVO
                //dtpAnho.Value = DateTime.Now;
                dtpMes.Value = DateTime.Now.AddDays(-2);

                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                Negocio.NGPeriodo objNg = new Negocio.NGPeriodo(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarPeriodo(intIdPeriodo, ref blnTodoOK);
                string fecha = 01 +"/"+ tbl.Rows[0]["mes"] +"/"+ tbl.Rows[0]["anho"];
                dtpAnho.Value = Convert.ToDateTime(fecha);
                dtpMes.Value = Convert.ToDateTime(fecha);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                //txtCodigo.Enabled = false;
            }
            else if (tipo == 3)
            {
                DataTable tbl = new DataTable();
                Negocio.NGPeriodo objNg = new Negocio.NGPeriodo(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarPeriodo(intIdPeriodo, ref blnTodoOK);

                string fecha = 01 + "/" + tbl.Rows[0]["mes"] + "/" + tbl.Rows[0]["anho"];
                dtpAnho.Value = Convert.ToDateTime(fecha);
                dtpMes.Value = Convert.ToDateTime(fecha);
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
               

                if (!blnTodoOK)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                dtpAnho.Enabled = false;
                dtpMes.Enabled = false;
                chkEstado.Enabled = false;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar el Periodo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Clases.InicialCls.LeerXml();

            if (intIdPeriodo == 0)
            { //NUEVO
               
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
                ENPeriodo obj = new ENPeriodo();

                string codigo = dtpAnho.Text + dtpMes.Text;
                obj.strCoPeriodo = codigo;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                obj.intIdUsuCr = idUsuario;

                Negocio.NGPeriodo objNg = new Negocio.NGPeriodo(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarPeriodo(obj, intIdEmp, ref mensaje, ref blnTodoOK);

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!blnTodoOK)
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Periodo guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string mensaje = string.Empty;
            bool blnTodoOK = false;
            ENPeriodo obj = new ENPeriodo();
            obj.intIdPeriodo = intIdPeriodo;
            string codigo = dtpAnho.Text + dtpMes.Text;
            obj.strCoPeriodo = codigo;
            obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            obj.intIdUsuMf = idUsuario;

            Negocio.NGPeriodo objNg = new Negocio.NGPeriodo(Configuracion.Sistema.CadenaConexion);

            objNg.EditarPeriodo(obj, ref mensaje, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Periodo Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }


    }
}
