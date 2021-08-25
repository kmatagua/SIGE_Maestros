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
    public partial class OpeLogEmpresa : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_OpeLog = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();
        BindingSource src2 = new BindingSource();

        public OpeLogEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("tipo");
            tabla.Columns.Add("default");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;

            tabla_OpeLog.Columns.Add("id_OpeLog");
            tabla_OpeLog.Columns.Add("nombre_OpeLog");
            tabla_OpeLog.Columns.Add("tipo_OpeLog");   
        }

        private void OpeLogEmpresa_Load(object sender, EventArgs e)
        {
            ListarOpeLog();
            lblEmpresa.Text = nombreEmpresa;
            ListarComboTipoOpe();
            ListarComboTipoOpe2();
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaOpeLog);
            Clases.Reglas.alternarColor(dgvListaOpeLogAcc);
            ListarOpeLogAcc();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarOpeLog()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.OpeLog(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_OpeLog.NewRow();
                //asignas el dato a cada columna de la row
                row["id_OpeLog"] = row1[0].ToString();
                row["nombre_OpeLog"] = row1[2].ToString();
                row["tipo_OpeLog"] = row1["strNoTipoOpe"].ToString();
                tabla_OpeLog.Rows.Add(row);
            }
            src.DataSource = tabla_OpeLog;
            dgvListaOpeLog.DataSource = src;
        }

        public void ListarOpeLogAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGOpeLog obj = new NGOpeLog(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.OpeLogAcceso(Convert.ToInt32(txtIdEmp.Text), ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    row["tipo"] = row1["strNoTipoOpe"].ToString();
                    
                    tabla.Rows.Add(row);
                }
                src2.DataSource = tabla;
                dgvListaOpeLogAcc.DataSource = src2;
            }
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdOpeLog = Convert.ToInt32(dgvListaOpeLog.CurrentRow.Cells["id_OpeLog"].Value);
            string strNoOpeLog = dgvListaOpeLog.CurrentRow.Cells["nombre_OpeLog"].Value.ToString();
            string strNoTipoOpe = dgvListaOpeLog.CurrentRow.Cells["tipo_OpeLog"].Value.ToString();

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

                    NGEmpresa objNgEmp = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

                    objNgEmp.InsertarOpeLogEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("OpeLoges agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
            //{
            //    MessageBox.Show("Seleccione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

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

        private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarOpeLog();
        }

        private void cbxFiltro2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarOpeLogAcc();
        }
    }
}
