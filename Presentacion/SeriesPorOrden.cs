using Negocio;
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
    public partial class SeriesPorOrden : Form
    {
        public int idUsuario, idEmpresa, tipo, intIdSeriesPorOrden, idEmpresaBuscada, idSede, idSubTipoOpe;

        private void SeriesPorOrden_Load(object sender, EventArgs e)
        {
            ListarComboNumerador(idEmpresa);
            ListarComboUndProduccion(idEmpresa);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        public SeriesPorOrden()
        {
            InitializeComponent();
        }

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "EMPRESA";
                //frm.tipoTabla = "GENERAL";
                //frm.intId = intIdEmp;
                frm.intIdUsu = idUsuario;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idEmpresaBuscada = frm.idEncontrado;
                    txtEmpresa.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    txtSede.Focus();
                    ListarComboNumerador(idEmpresaBuscada);
                }
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idEmpresaBuscada = 0;
                txtEmpresa.Text = " ";
                //idAlmacen = 0;
                //txtAlmacen.Text = " ";
                //idTipoDoc = 0;
                //txtTipoDoc.Text = " ";
                txtEmpresa.Focus();
                ListarComboNumerador(idEmpresaBuscada);
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtSede_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SEDE_ALM_USU2";
                frm.tipoTabla = "GENERAL";
                frm.idEmpresa = idEmpresaBuscada;
                frm.intIdUsu = idUsuario;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSede = frm.idEncontrado;
                    txtSede.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    ListarComboNumerador(idEmpresaBuscada);
                    txtSubTipoOpe.Focus();
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idSede = 0;
                txtSede.Text = " ";
                //txtAlmacen.Focus();
                ListarComboNumerador(idEmpresaBuscada);
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        private void txtSubTipoOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Enter)
            {
                Busqueda frm = new Busqueda();
                frm.nombre_maestro = "SUBTIPOOPE";
                //frm.tipoTabla = "GENERAL";
                frm.intId = idEmpresaBuscada;
                //frm.intIdUsu = intIdUsu;
                frm.intId = 5;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idSubTipoOpe = frm.idEncontrado;
                    txtSubTipoOpe.Text = frm.nombreEncontrado;
                    //txtAlmacen.Text = frm.nombreEncontrado;
                    //txtSerie.Focus();
                    ListarComboNumerador(idEmpresa);
                }

                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                idSubTipoOpe = 0;
                txtSubTipoOpe.Text = " ";
                //txtSerie.Focus();
                ListarComboNumerador(idEmpresa);
                e.SuppressKeyPress = true; // impide que se pase la pulsación de la tecla Enter al evento KeyPress
            }
        }

        public void ListarComboNumerador(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Listar_Combo2("NUMERADOR",idSubTipoOpe,idEmpresaBuscada, idUsuario, 0, idSede, ref blnTodoOK);

            cbxNumerador.DataSource = tbl;
            cbxNumerador.DisplayMember = "strNumerador";
            cbxNumerador.ValueMember = "intIdNum";

        }

        public void ListarComboUndProduccion(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Listar_Combo2("UND_PRODUCCION", 0, idEmpresaBuscada, 0, 0, 0, ref blnTodoOK);

            cbxUndProduccion.DataSource = tbl;
            cbxUndProduccion.DisplayMember = "strNoUndProduccion";
            cbxUndProduccion.ValueMember = "intIdUndProduccion";

        }
    }
}
