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
    public partial class UsuarioCanal : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Canal = new DataTable();

        DataTable tblCanal = new DataTable();
        DataTable tblUsuario = new DataTable();
        BindingSource src = new BindingSource();

        public UsuarioCanal()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idCanalDist");

            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idCanalDist"];
            tabla.PrimaryKey = colPk1;

            tabla_Canal.Columns.Add("id_CanalDist");
            tabla_Canal.Columns.Add("nombre_CanalDist");          
        }

        private void UsuarioCanal_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarCanalDist(idEmpresa);
            
            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }
  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarCanalDist(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGCanalDist obj = new NGCanalDist(Configuracion.Sistema.CadenaConexion);
            tblCanal = obj.GridCanalDist(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblCanal.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Canal.NewRow();
                //asignas el dato a cada columna de la row
                row["id_CanalDist"] = row1[0].ToString();
                row["nombre_CanalDist"] = row1[1].ToString();
                tabla_Canal.Rows.Add(row);
            }
            dgvListaCanalDist.DataSource = tabla_Canal;
        }

        public void ListarCanalDistAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblCanalDistAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGCanalDist obj = new NGCanalDist(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblCanalDistAcc = obj.CanalDistAccesoUsu(idUsuario, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblCanalDistAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuCanal"].ToString();
                    row["nombre"] = row1["strNoCanalDist"].ToString();
                    row["idCanalDist"] = row1["intIdCanalDist"].ToString();
                    tabla.Rows.Add(row);
                }

                dgvListaCanalDistAcc.DataSource = tabla;
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
            int intIdCanalDist = Convert.ToInt32(dgvListaCanalDist.CurrentRow.Cells["id_CanalDist"].Value);
            string strNoCanalDist = dgvListaCanalDist.CurrentRow.Cells["nombre_CanalDist"].Value.ToString();
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdCanalDist == Convert.ToInt32(row2["idCanalDist"].ToString()))
                {
                    MessageBox.Show("El Canal Distributivo ya fue Asignado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoCanalDist, intIdCanalDist });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaCanalDistAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaCanalDistAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaCanalDistAcc.CurrentRow.Cells["id"].Value);

                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Canal Distributivo?";
                string caption = "Confirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarCanalDist(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Canal Distributivo Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarCanalDistAcc();
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
                    objNgAlm.InsertarCanalDistUsuario(idUsuario, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Canal Distributivo agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ListarCanalDistAcc();
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
                foreach (DataGridViewRow row in dgvListaCanalDist.Rows)
                {
                    int intIdCanalDist = Convert.ToInt32(row.Cells["id_CanalDist"].Value);
                    string strNoCanalDist = row.Cells["nombre_CanalDist"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoCanalDist, intIdCanalDist });
                }
                return;
            }

            else{
                foreach (DataGridViewRow row in dgvListaCanalDist.Rows)
                {
                    int intIdCanalDist = Convert.ToInt32(row.Cells["id_CanalDist"].Value);
                    string strNoCanalDist = row.Cells["nombre_CanalDist"].Value.ToString();
                   
                    string ss = row.Cells["id_CanalDist"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);
                    
                    if (foundRow1 != null)
                    {
                       
                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoCanalDist, intIdCanalDist }); 
                    }

                }
            }
            
            dgvListaCanalDistAcc.DataSource = tabla;
        }

    }
}
