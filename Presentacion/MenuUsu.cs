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
    public partial class MenuUsu : Form
    {
        public int idEmpresa;
        public string nombreEmpresa;
        public int tipo;

        int idSelectCombo;

        BindingSource src = new BindingSource();

        DataTable p_tbl = new DataTable();

        DataTable tabla = new DataTable();
        DataTable tabla_Menu = new DataTable();
        DataTable tabla_Btn = new DataTable();

        DataTable tblUsuario = new DataTable();


        public MenuUsu()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("codigo");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idUsuario");
            tabla.Columns.Add("intIdMenu");

            tabla_Menu.Columns.Add("id_Menu");
            tabla_Menu.Columns.Add("nombre_Menu");
            tabla_Menu.Columns.Add("codigo_Menu");

            
        }

        private void MenuUsu_Load(object sender, EventArgs e)
        {            
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;
            //idSelectCombo = 0;
            //lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario();
            //ListarCombo();
            ListarMenu();
            Clases.Reglas.alternarColor(dgvListaMenu);
            Clases.Reglas.alternarColor(dgvListaMenuAcc);
            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarMenu()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblMenu = new DataTable();

            NGMenu obj = new NGMenu(Configuracion.Sistema.CadenaConexion);
            tblMenu = obj.GridMenu(ref blnTodoOK);
            foreach (DataRow row1 in tblMenu.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Menu.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Menu"] = row1["intIdMenu"].ToString();
                row["nombre_Menu"] = row1["strNoMenu"].ToString();
                row["codigo_Menu"] = row1["strCoMenu"].ToString();
                tabla_Menu.Rows.Add(row);
            }
            dgvListaMenu.DataSource = tabla_Menu;
        }

        public void ListarMenuAcc(int id_empresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblMenuAcc = new DataTable();
            //if (txtIdUsu.Text.Trim() != string.Empty)
            //{
                NGMenu obj = new NGMenu(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                //int idEmpresa = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                tblMenuAcc = obj.MenuAccesoUsu(idUsuario, id_empresa, ref p_tbl, ref blnTodoOK);

                foreach (DataRow row1 in tblMenuAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuMenu"].ToString();
                    row["codigo"] = row1["strCoMenu"].ToString();
                    row["nombre"] = row1["strNoMenu"].ToString();
                    row["idUsuario"] = idUsuario;
                    row["intIdMenu"] = row1["intIdMenu"].ToString();

                    tabla.Rows.Add(row);
                }                
            //}
                LLenar();
        }

        public void ListarComboUsuario()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.ComboUsuario(idEmpresa, ref blnTodoOK);

            cbxUsuario.DataSource = tblUsuario;
            cbxUsuario.DisplayMember = "nombre";
            cbxUsuario.ValueMember = "id";
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdMenu = Convert.ToInt32(dgvListaMenu.CurrentRow.Cells["id_Menu"].Value);
            string strNoMenu = dgvListaMenu.CurrentRow.Cells["nombre_Menu"].Value.ToString();
            string strCoMenu = dgvListaMenu.CurrentRow.Cells["codigo_Menu"].Value.ToString();
            int idUsuario = (cbxUsuario.SelectedValue is DBNull)? 0 : Convert.ToInt32(cbxUsuario.SelectedValue);

            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {   MessageBox.Show("Selecione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return;  }
            
            foreach (DataRow row2 in tabla.Rows)
            {
                if ((Convert.ToInt32(row2["intIdMenu"].ToString()) == intIdMenu) && (Convert.ToInt32(row2["idUsuario"].ToString()) == idUsuario)) 
                {   MessageBox.Show("El Menu ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return;    }
            }

            tabla.Rows.Add(new object[] {  0, strCoMenu ,strNoMenu, idUsuario, intIdMenu});

            LLenar();
        }

        //private void btnPasaTodo_Click(object sender, EventArgs e)
        //{
        //    if (Convert.ToInt32(cbxAlmacen.SelectedValue) <= 0)
        //    {
        //        MessageBox.Show("Seleccione Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (tabla.Rows.Count < 1)
        //    {
        //        foreach (DataGridViewRow row in dgvListaOpeLog.Rows)
        //        {
        //            int intIdOpeLog = Convert.ToInt32(row.Cells["id_OpeLog"].Value);
        //            string strNoOpeLog = row.Cells["nombre_OpeLog"].Value.ToString();
        //            string strNoTipoOpe = row.Cells["tipo_OpeLog"].Value.ToString();
        //            tabla.Rows.Add(new object[] { intIdOpeLog, strNoOpeLog, strNoTipoOpe });
        //        }
        //        return;
        //    }

        //    else
        //    {
        //        foreach (DataGridViewRow row in dgvListaOpeLog.Rows)
        //        {
        //            int intIdOpeLog = Convert.ToInt32(row.Cells["id_OpeLog"].Value);
        //            string strNoOpeLog = row.Cells["nombre_OpeLog"].Value.ToString();
        //            string strNoTipoOpe = row.Cells["tipo_OpeLog"].Value.ToString();
        //            string ss = row.Cells["id_OpeLog"].Value.ToString();
        //            DataRow foundRow1 = tabla.Rows.Find(ss);

        //            if (foundRow1 != null)
        //            {

        //            }
        //            else
        //            {
        //                tabla.Rows.Add(new object[] { intIdOpeLog, strNoOpeLog, strNoTipoOpe });
        //            }

        //        }
        //    }

        //    dgvListaOpeLogAcc.DataSource = tabla;
        //}

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaMenuAcc.Rows.Count > 0)
            {
                //    int index = dgvListaMenuAcc.CurrentRow.Index;
                //    dgvListaMenuAcc.Rows.RemoveAt(index);
                //}
                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaMenuAcc.CurrentRow.Cells["id"].Value);

                NGMenu obj = new NGMenu(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Menu?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.Borrar(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Menu Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    int id_empresa = Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                    ListarMenuAcc(id_empresa);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((cbxEmpresa.SelectedValue == null) == true)
            { MessageBox.Show("Debe Elegir un Usuario.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Convert.ToInt32(cbxEmpresa.SelectedValue) == 0)
            { MessageBox.Show("Debe Elegir una Empresa.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Insertar();
            tabla.Clear();
            int id_empresa = Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
            ListarMenuAcc(id_empresa);
        }

        public void Insertar()
        {
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    bool blnTodoOK = false;
                    Clases.InicialCls.LeerXml();
                    int idEmp = (cbxEmpresa.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                    int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                    NGUsuario objNgUsu = new NGUsuario(Configuracion.Sistema.CadenaConexion);
                    
                    objNgUsu.InsertarMenuUsuario(idUsuario, tabla, idEmp, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Menu agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable FiltrarDataTable(DataTable _dt, string _filter)
        {
            try
            {
                DataTable table = new DataTable();
                DataRow[] foundRows;
                foundRows = _dt.Select(_filter);
                //table = _dt;
                table.Clear();
                if (foundRows.Length > 0) table = foundRows.CopyToDataTable();
                //else
                //{
                //    table.Columns.Add("id");
                //    table.Columns.Add("nombre");
                //    table.Columns.Add("idUsuario");
                //}
                return table;
            }
            catch (Exception ex) { throw (ex); }
        }

        public void LLenar()
        {
            dgvListaMenuAcc.DataSource = tabla;
            
        }

        private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEmpresa.SelectedValue.ToString() != null)
            {
                tabla.Clear();
                int id_empresa = Convert.ToInt32(cbxEmpresa.SelectedValue.ToString());
                ListarMenuAcc(id_empresa);
            }
        }

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxUsuario.SelectedValue.ToString() != null){
                tabla.Clear();
                int id_usuario = Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                cbxEmpresa.SelectedIndexChanged -= cbxEmpresa_SelectedIndexChanged;
                ListarCombo(id_usuario);
                cbxEmpresa.SelectedIndexChanged += cbxEmpresa_SelectedIndexChanged;
            }
        }

        private void dgvListaMenuAcc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ListarBtn();
        }

        private void btnBotones_Click(object sender, EventArgs e)
        {
            if (dgvListaMenuAcc.RowCount <= 0)
            {
                MessageBox.Show("No hay Menu para Asignar botones.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(dgvListaMenuAcc.CurrentRow.Cells["id"].Value) == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea Guardar Los Menu?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    btnGuardar.PerformClick();
                    tabla.Clear();
                    //ListarMenuAcc();
                    LLenar();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else 
            {
                BtnMenu frm = new BtnMenu();
                //frm.MdiParent = this;
                frm.nombreUsuario = cbxUsuario.Text;
                frm.nombreMenu = dgvListaMenuAcc.CurrentRow.Cells["nombre"].Value.ToString();
                frm.idUsuBtn = Convert.ToInt32(dgvListaMenuAcc.CurrentRow.Cells["id"].Value);
                frm.Show();
            
            }
            
        }

        //private void dgvListaBtn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int IdValor = (dgvListaBtn.CurrentRow.Index + 1);
        //    if (Convert.ToBoolean(dgvListaBtn.Rows[dgvListaBtn.CurrentRow.Index].Cells[0].Value) == true)
        //    {
        //        DataRow[] rows = p_tbl.Select("intIdUsuMenu=" + dgvListaMenuAcc.CurrentRow.Cells["id"].Value.ToString() + " and id=" + IdValor);
        //        if (rows.Length > 0)
        //        {
        //            foreach (DataRow row1 in rows)
        //            {
        //                row1["valor"] = 1;
        //                p_tbl.AcceptChanges();
        //                row1.SetModified();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //p_tbl                
        //        DataRow[] rows = p_tbl.Select("intIdUsuMenu=" + dgvListaMenuAcc.CurrentRow.Cells["id"].Value.ToString() + " and id=" + IdValor);
        //        if (rows.Length > 0)
        //        {
        //            foreach (DataRow row1 in rows)
        //            {
        //                row1["valor"] = 1;
        //                p_tbl.AcceptChanges();
        //                row1.SetModified();
        //            }
        //        }
        //    }
        //}

        public void ListarCombo(int id_usuario)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ComboEmpresa(id_usuario, ref blnTodoOK);

            cbxEmpresa.DataSource = tbl;
            cbxEmpresa.DisplayMember = "strNoEmp";
            cbxEmpresa.ValueMember = "intIdEmp";

        }

        

    }
}
