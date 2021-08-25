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
using System.Transactions;

namespace Presentacion
{
    public partial class OpeLogAlmacen : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_OpeLog = new DataTable();

        DataTable tblAlmacen = new DataTable();
        DataTable tblSede = new DataTable();
        BindingSource src = new BindingSource();
        BindingSource src2 = new BindingSource();

        public OpeLogAlmacen()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("tipo");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_OpeLog.Columns.Add("id_OpeLog");
            tabla_OpeLog.Columns.Add("nombre_OpeLog");
            tabla_OpeLog.Columns.Add("tipo_OpeLog");
        }

        private void OpeLogAlmacen_Load(object sender, EventArgs e)
        {
            cbxAlmacen.SelectedIndexChanged -= cbxAlmacen_SelectedIndexChanged;


            lblEmpresa.Text = nombreEmpresa;
            ListarComboTipoOpe();
            ListarComboTipoOpe2();
            ListarComboSede(idEmpresa);
            ListarComboAlmacen(idEmpresa);
            ListarOpeLog(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaOpeLog);
            Clases.Reglas.alternarColor(dgvListaOpeLogAcc);
            txtIdAlm.Text = Convert.ToString(idEmpresa);

            

            cbxAlmacen.SelectedIndexChanged += cbxAlmacen_SelectedIndexChanged;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarOpeLog(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
            tblAlmacen = obj.GridOpeLog(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblAlmacen.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_OpeLog.NewRow();
                //asignas el dato a cada columna de la row
                row["id_OpeLog"] = row1[0].ToString();
                row["nombre_OpeLog"] = row1[1].ToString();
                row["tipo_OpeLog"] = row1[2].ToString();
                tabla_OpeLog.Rows.Add(row);
            }
            src.DataSource = tabla_OpeLog;
            dgvListaOpeLog.DataSource = src;
            
        }

        public void ListarOpeLogAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblOpeLogAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
                int idAlmacen = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
                tblOpeLogAcc = obj.OpeLogAccesoAlm(idAlmacen, ref blnTodoOK);

                foreach (DataRow row1 in tblOpeLogAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    row["tipo"] = row1[2].ToString();
                    
                    tabla.Rows.Add(row);
                }

                src2.DataSource = tabla;
                dgvListaOpeLogAcc.DataSource = src2;

                
            }
        }

        public void ListarComboSede(int idEmpresa)
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo2("SEDE", 0, idEmpresa, idUsuario, 0, 0, ref pBlnTodoOk);

            cbxSede.DisplayMember = "strNoSede";
            cbxSede.ValueMember = "intIdSede";
            cbxSede.DataSource = tbl;
        }

        public void ListarComboTipoOpe()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGTipoOpe obj = new NGTipoOpe(Configuracion.Sistema.CadenaConexion);
            tbl = obj.TipoOpeCombo(ref blnTodoOK);
            cbxFiltro.DisplayMember = "strNoTipoOpe";
            cbxFiltro.ValueMember = "intIdTipoOpe";
            cbxFiltro.DataSource = tbl;
        }

        public void ListarComboTipoOpe2()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGTipoOpe obj = new NGTipoOpe(Configuracion.Sistema.CadenaConexion);
            tbl = obj.TipoOpeCombo(ref blnTodoOK);

            cbxFiltro2.DisplayMember = "strNoTipoOpe";
            cbxFiltro2.ValueMember = "intIdTipoOpe";
            cbxFiltro2.DataSource = tbl;

        }

        public void ListarComboAlmacen(int idEmpresa)
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

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdOpeLog = Convert.ToInt32(dgvListaOpeLog.CurrentRow.Cells["id_OpeLog"].Value);
            string strNoOpeLog = dgvListaOpeLog.CurrentRow.Cells["nombre_OpeLog"].Value.ToString();
            string strNoTipoOpe= dgvListaOpeLog.CurrentRow.Cells["tipo_OpeLog"].Value.ToString();

            if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdOpeLog == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Operación ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdOpeLog, strNoOpeLog, strNoTipoOpe });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaOpeLogAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaOpeLogAcc.Rows.Count > 0)
            {
                int index = dgvListaOpeLogAcc.CurrentRow.Index;
                dgvListaOpeLogAcc.Rows.RemoveAt(index);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if(tabla.Rows.Count == 0){

            //} 
            Insertar();
        }

        public void Insertar()
        {
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    bool blnTodoOK = false;
                    Clases.InicialCls.LeerXml();

                    NGAlmacen objNgAlm = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
                    int idAlmacen = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
                    objNgAlm.InsertarOpeLogAlmacen(idAlmacen, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("OpeLoges agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxAlmacen.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxAlmacen.SelectedValue.ToString());
            txtIdAlm.Text = valor.ToString();
            tabla.Clear();
            ListarOpeLogAcc();
        }

        private void lblEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tabla.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in dgvListaOpeLog.Rows)
                {
                    int intIdOpeLog = Convert.ToInt32(row.Cells["id_OpeLog"].Value);
                    string strNoOpeLog = row.Cells["nombre_OpeLog"].Value.ToString();
                    string strNoTipoOpe = row.Cells["tipo_OpeLog"].Value.ToString();
                    tabla.Rows.Add(new object[] { intIdOpeLog, strNoOpeLog, strNoTipoOpe });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaOpeLog.Rows)
                {
                    int intIdOpeLog = Convert.ToInt32(row.Cells["id_OpeLog"].Value);
                    string strNoOpeLog = row.Cells["nombre_OpeLog"].Value.ToString();
                    string strNoTipoOpe = row.Cells["tipo_OpeLog"].Value.ToString();
                    string ss = row.Cells["id_OpeLog"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdOpeLog, strNoOpeLog, strNoTipoOpe });
                    }

                }
            }

            dgvListaOpeLogAcc.DataSource = tabla;
        }

        private void cbxSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxSede.SelectedValue) == 0)
            {
                ListarComboAlmacen(idEmpresa);
                cbxAlmacen.SelectedValue = 0;
            }
            else
            {
                Listar_Almacen_Filtro();
            }
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

        private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarOpeLog();
        }

        private void cbxFiltro2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarOpeLogAcc();
        }

        public void filtrarOpeLogAcc()
        {
            if (Convert.ToInt32(cbxFiltro2.SelectedValue) == 0)
            {
                src2.Filter = "";
            }
            else
            {
                src2.Filter = "tipo = '" + cbxFiltro2.Text + "'";
            }
        }

        public void filtrarOpeLog()
        {
            if (Convert.ToInt32(cbxFiltro.SelectedValue) == 0)
            {
                src.Filter = "";
            }
            else
            {
                src.Filter = "tipo_OpeLog = '" + cbxFiltro.Text + "'";
            }
        }
    }
}
