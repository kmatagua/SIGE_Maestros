using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class CambioEmpresa : Form
    {
        public int idEncontrado;
        public int tipoBusqueda;
        public string cambio;
        public int intIdUsu;

        public CambioEmpresa()
        {
            InitializeComponent();
        }

        private void CambioEmpresa_Load(object sender, EventArgs e)
        {
            if (cambio == "CambioEmpresa")
            {
                bool blnTodoOK = false;
                Clases.InicialCls.LeerXml();
                DataTable tbl = new DataTable();
                Negocio.NGEmpresa obj = new Negocio.NGEmpresa(Configuracion.Sistema.CadenaConexion);
                tbl = obj.Empresa(intIdUsu, ref blnTodoOK);
                dgvItems.DataSource = tbl;
                dgvItems.Focus();
            }
        }

        


        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnAceptar.PerformClick();

                //dgv_DetalleLote.Focus();

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            idEncontrado = Convert.ToInt32(dgvItems.CurrentRow.Cells["intIdEmp"].Value.ToString());
           
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        

        #region ----- FUNCIONES -----



        #endregion

        

       
    }
}
