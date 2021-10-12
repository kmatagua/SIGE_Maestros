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
    public partial class UniGesUsuario : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_UniGes = new DataTable();

        DataTable tblUsuario = new DataTable();
        BindingSource src = new BindingSource();

        public UniGesUsuario()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idUniGes");

            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idUniGes"];
            tabla.PrimaryKey = colPk1;

            tabla_UniGes.Columns.Add("id_UniGes");
            tabla_UniGes.Columns.Add("nombre_UniGes");          
        }

        private void UniGesUsuario_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarUniGes();

            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }
  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarUniGes()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUndGestion obj = new NGUndGestion(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.GridUniGes(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblUsuario.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_UniGes.NewRow();
                //asignas el dato a cada columna de la row

                row["id_UniGes"] = row1["intIdUndGestion"].ToString();
                row["nombre_UniGes"] = row1["strNoUndGestion"].ToString();
                tabla_UniGes.Rows.Add(row);
            }
            dgvListaUniGes.DataSource = tabla_UniGes;
        }

        public void ListarUniGesAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblUniGesAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGUndGestion obj = new NGUndGestion(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblUniGesAcc = obj.UniGesAccesoUsu(idUsuario, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblUniGesAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuUniGes"].ToString();
                    row["nombre"] = row1["strNoUndGestion"].ToString();
                    row["idUniGes"] = row1["intIdUniGes"].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaUniGesAcc.DataSource = tabla;
            }
        }

        public void ListarComboUsuario(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.ComboUsuario(idEmpresa, ref blnTodoOK);

            cbxUsuario.DataSource = tblUsuario;
            cbxUsuario.DisplayMember = "nombre";
            cbxUsuario.ValueMember = "id";
            //src.DataSource = tblUsuario;
            //dgvLista.DataSource = src;

        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdUniGes = Convert.ToInt32(dgvListaUniGes.CurrentRow.Cells["id_UniGes"].Value);
            string strNoUniGes = dgvListaUniGes.CurrentRow.Cells["nombre_UniGes"].Value.ToString();
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdUniGes == Convert.ToInt32(row2["idUniGes"].ToString()))
                {
                    MessageBox.Show("La Unidad de Gestion ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            tabla.Rows.Add(new object[] { 0, strNoUniGes, intIdUniGes});

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaUniGesAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaUniGesAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaUniGesAcc.CurrentRow.Cells["id"].Value);

                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar esta Unidad de Negocio?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarUniGes(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Unidad de Gestión Eliminada con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarUniGesAcc();
                }
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

                    NGUsuario objNgAlm = new NGUsuario(Configuracion.Sistema.CadenaConexion);
                    int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                    objNgAlm.InsertarUniGesUsuario(idUsuario, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Unidad de Gestión agregada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cbxUsuario.SelectedValue = 0;
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
            txtIdAlm.Text = valor.ToString();
            tabla.Clear();
            ListarUniGesAcc();
        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tabla.Rows.Count < 1)
            {
                foreach (DataGridViewRow row in dgvListaUniGes.Rows)
                {
                    int intIdUniGes = Convert.ToInt32(row.Cells["id_UniGes"].Value);
                    string strNoUniGes = row.Cells["nombre_UniGes"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoUniGes, intIdUniGes });
                }
                return;
            }

            else{
                foreach (DataGridViewRow row in dgvListaUniGes.Rows)
                {
                    int intIdUniGes = Convert.ToInt32(row.Cells["id_UniGes"].Value);
                    string strNoUniGes = row.Cells["nombre_UniGes"].Value.ToString();
                   
                    string ss = row.Cells["id_UniGes"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);
                    
                    if (foundRow1 != null)
                    {
                       
                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoUniGes, intIdUniGes }); 
                    }

                }
            }
            
            dgvListaUniGesAcc.DataSource = tabla;
        }

    }
}
