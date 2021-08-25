using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidad;

namespace Presentacion
{
    public partial class CierreAlmacen : Form
    {
        public int tipo;
        public int idUsuario;
        public int idEmpresa;
        public int idCierreAlmacen;

        DataTable tblAlmacen = new DataTable();
        DataTable tblSede = new DataTable();

        public CierreAlmacen()
        {
            InitializeComponent();
        }


        private void CierreAlmacen_Load(object sender, EventArgs e)
        {
            ListarCombo();
            ListarComboPeriodo();
            ListarComboSede();
            ListarComboAlmacen();
            if (tipo == 1)
            { //NUEVO

                chkCierre.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGCierreAlmacen objNg = new NGCierreAlmacen(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarCierreAlmacen(idCierreAlmacen, ref blnTodoOK);

                cbxEmpresa.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdEmp"]);
                cbxSede.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdSede"]);
                cbxAlmacen.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdAlm"]);
                cbxPeriodo.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdPeriodo"]);
                
                chkCierre.Checked = Convert.ToBoolean(tbl.Rows[0]["intCierre"]);


                //txtCodigo.Enabled = false;
            }
            else if (tipo == 3) //VER
            {
                DataTable tbl = new DataTable();
                NGCierreAlmacen objNg = new NGCierreAlmacen(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;

                tbl = objNg.BuscarCierreAlmacen(idCierreAlmacen, ref blnTodoOK);

                cbxEmpresa.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdEmp"]);
                cbxSede.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdSede"]);
                cbxAlmacen.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdAlm"]);
                cbxPeriodo.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intIdPeriodo"]);

                chkCierre.Checked = Convert.ToBoolean(tbl.Rows[0]["intCierre"]);

                cbxEmpresa.Enabled = false;
                cbxSede.Enabled = false;
                cbxAlmacen.Enabled = false;
                cbxPeriodo.Enabled = false;
                chkCierre.Enabled = false;
                btnGuardar.Visible = false;


            }
        }


        public void ListarCombo()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Empresa(idUsuario, ref blnTodoOK);

            cbxEmpresa.DataSource = tbl;
            cbxEmpresa.DisplayMember = "nombre";
            cbxEmpresa.ValueMember = "id";
            
        }

        public void ListarComboSede()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo2("SEDE", 0, Convert.ToInt32(cbxEmpresa.SelectedValue), idUsuario, 0, 0, ref pBlnTodoOk);

            cbxSede.DisplayMember = "strNoSede";
            cbxSede.ValueMember = "intIdSede";
            cbxSede.DataSource = tbl;
        }

        public void ListarComboAlmacen()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGAlmacen obj = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
            tblAlmacen = obj.ComboAlmacen(idEmpresa, ref blnTodoOK);

            cbxAlmacen.DataSource = tblAlmacen;
            cbxAlmacen.DisplayMember = "strNoAlm";
            cbxAlmacen.ValueMember = "intIdAlm";
            //src.DataSource = tblAlmacen;
            //dgvLista.DataSource = src;


        }

        public void Listar_Almacen_Filtro()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo2("ALMACEN_SEDE", 0, 0, idUsuario, 0, Convert.ToInt32(cbxSede.SelectedValue), ref pBlnTodoOk);

            cbxAlmacen.DisplayMember = "strNoAlm";
            cbxAlmacen.ValueMember = "intIdAlm";
            cbxAlmacen.DataSource = tbl;

        }

        public void ListarComboPeriodo()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo("PERIODO", 0, ref pBlnTodoOk);

            cbxPeriodo.DisplayMember = "strCoPeriodo";
            cbxPeriodo.ValueMember = "intIdPeriodo";
            cbxPeriodo.DataSource = tbl;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxSede.SelectedValue) == 0)
            {
                ListarComboAlmacen();
                cbxAlmacen.SelectedValue = 0;
            }
            else
            {
                Listar_Almacen_Filtro();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (idCierreAlmacen == 0)
            { //NUEVO
                if (Convert.ToInt32(cbxEmpresa.SelectedValue) == 0)
                { MessageBox.Show("Seleccione Empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); cbxEmpresa.Focus(); return; }
                if (Convert.ToInt32(cbxSede.SelectedValue) == 0)
                { MessageBox.Show("Seleccione Sede", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); cbxSede.Focus(); return; }
                if (Convert.ToInt32(cbxAlmacen.SelectedValue) == 0)
                { MessageBox.Show("Seleccione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); cbxAlmacen.Focus(); return; }
                if (Convert.ToInt32(cbxPeriodo.SelectedValue) == 0)
                { MessageBox.Show("Seleccione Periodo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); cbxPeriodo.Focus(); return; }
                
                Insertar();
            }
            else //Editar
            {
                Editar();
            }
        }

        //private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    ListarComboSede(Convert.ToInt32(cbxEmpresa.SelectedValue));
        //    cbxSede.SelectedValue = 0;

        //}

        public void Insertar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENCierreAlmacen obj = new ENCierreAlmacen();
                obj.intIdEmp = Convert.ToInt32(cbxEmpresa.SelectedValue);
                obj.intIdAlm = Convert.ToInt32(cbxAlmacen.SelectedValue);
                obj.intIdPeriodo = Convert.ToInt32(cbxPeriodo.SelectedValue);
                obj.intIdUsuCr = idUsuario;
                //obj.intIdSede = Convert.ToInt32(cbxSede.SelectedValue);
                obj.intCierre = Convert.ToInt32(chkCierre.Checked);

                Negocio.NGCierreAlmacen objNg = new Negocio.NGCierreAlmacen(Configuracion.Sistema.CadenaConexion);

                objNg.InsertarCierreAlmacen(obj, ref mensaje, ref blnTodoOK);


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
                    MessageBox.Show("Cierre Almacen guardado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ENCierreAlmacen obj = new ENCierreAlmacen();
            obj.intIdCierreAlmacen = idCierreAlmacen;
            obj.intIdEmp = Convert.ToInt32(cbxEmpresa.SelectedValue);
            obj.intIdSede = Convert.ToInt32(cbxSede.SelectedValue);
            obj.intIdAlm = Convert.ToInt32(cbxAlmacen.SelectedValue);
            obj.intIdPeriodo = Convert.ToInt32(cbxPeriodo.SelectedValue);
            obj.intIdUsuCr = idUsuario;
            //obj.intIdSede = Convert.ToInt32(cbxSede.SelectedValue);
            obj.intCierre = Convert.ToInt32(chkCierre.Checked);

            Negocio.NGCierreAlmacen objNg = new Negocio.NGCierreAlmacen(Configuracion.Sistema.CadenaConexion);

            objNg.EditarCierreAlmacen(obj, ref mensaje, ref blnTodoOK);

            if (blnTodoOK)
            {
                MessageBox.Show("Cierre Almacen Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }


    }
}
