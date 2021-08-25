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
    public partial class AreaUsuario : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Area = new DataTable();

        DataTable tblUsuario = new DataTable();
        BindingSource src = new BindingSource();

        public AreaUsuario()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idArea");

            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idArea"];
            tabla.PrimaryKey = colPk1;

            tabla_Area.Columns.Add("id_Area");
            tabla_Area.Columns.Add("nombre_Area");          
        }

        private void AreaUsuario_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarArea(idEmpresa);

            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }
    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarArea(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGArea obj = new NGArea(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.GridArea(ref blnTodoOK);
            foreach (DataRow row1 in tblUsuario.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Area.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Area"] = row1[0].ToString();
                row["nombre_Area"] = row1[1].ToString();
                tabla_Area.Rows.Add(row);
            }
            dgvListaArea.DataSource = tabla_Area;
        }

        public void ListarAreaAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblAreaAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGArea obj = new NGArea(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblAreaAcc = obj.AreaAccesoUsu(idUsuario, ref blnTodoOK);

                foreach (DataRow row1 in tblAreaAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuArea"].ToString();
                    row["nombre"] = row1["strNoArea"].ToString();
                    row["idArea"] = row1["intIdArea"].ToString();
                    
                    tabla.Rows.Add(row);
                }



                dgvListaAreaAcc.DataSource = tabla;
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
            int intIdArea = Convert.ToInt32(dgvListaArea.CurrentRow.Cells["id_Area"].Value);
            string strNoArea = dgvListaArea.CurrentRow.Cells["nombre_Area"].Value.ToString();
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdArea == Convert.ToInt32(row2["idArea"].ToString()))
                {
                    MessageBox.Show("El Area ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoArea, intIdArea});

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaAreaAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaAreaAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaAreaAcc.CurrentRow.Cells["id"].Value);

                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar esta Area?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarArea(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Area Eliminada con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarAreaAcc();
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
                    objNgAlm.InsertarAreaUsuario(idUsuario, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Area agregada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ListarAreaAcc();
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
                foreach (DataGridViewRow row in dgvListaArea.Rows)
                {
                    int intIdArea = Convert.ToInt32(row.Cells["id_Area"].Value);
                    string strNoArea = row.Cells["nombre_Area"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoArea, intIdArea });
                }
                return;
            }

            else{
                foreach (DataGridViewRow row in dgvListaArea.Rows)
                {
                    int intIdArea = Convert.ToInt32(row.Cells["id_Area"].Value);
                    string strNoArea = row.Cells["nombre_Area"].Value.ToString();
                   
                    string ss = row.Cells["id_Area"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);
                    
                    if (foundRow1 != null)
                    {
                       
                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoArea, intIdArea }); 
                    }

                }
            }
            
            dgvListaAreaAcc.DataSource = tabla;
        }

        
    }
}
