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
    public partial class MotivoUsuario : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Motivo = new DataTable();

        DataTable tblUsuario = new DataTable();
        BindingSource src = new BindingSource();

        public MotivoUsuario()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idMotivo");

            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idMotivo"];
            tabla.PrimaryKey = colPk1;

            tabla_Motivo.Columns.Add("id_Motivo");
            tabla_Motivo.Columns.Add("nombre_Motivo");          
        }

        private void MotivoUsuario_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarMotivos();

            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }

  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarMotivos()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGMotivo obj = new NGMotivo(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.GridMotivo(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tblUsuario.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Motivo.NewRow();
                //asignas el dato a cada columna de la row

                row["id_Motivo"] = row1["intIdMot"].ToString();
                row["nombre_Motivo"] = row1["strNoMot"].ToString();
                tabla_Motivo.Rows.Add(row);
            }
            dgvListaMotivos.DataSource = tabla_Motivo;
        }

        public void ListarMotivosAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblMotivoAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGMotivo obj = new NGMotivo(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblMotivoAcc = obj.MotivoAccesoUsu(idUsuario, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblMotivoAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuMot"].ToString();
                    row["nombre"] = row1["strNoMot"].ToString();
                    row["idMotivo"] = row1["intIdMot"].ToString();
                    
                    tabla.Rows.Add(row);
                }



                dgvListaMotivosAcc.DataSource = tabla;
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
            int intIdMotivo = Convert.ToInt32(dgvListaMotivos.CurrentRow.Cells["id_Motivo"].Value);
            string strNoMotivo = dgvListaMotivos.CurrentRow.Cells["nombre_Motivo"].Value.ToString();
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdMotivo == Convert.ToInt32(row2["idMotivo"].ToString()))
                {
                    MessageBox.Show("El Motivo ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoMotivo, intIdMotivo});

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaMotivosAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaMotivosAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaMotivosAcc.CurrentRow.Cells["id"].Value);

                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Motivo?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarMotivo(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Motivo Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarMotivosAcc();
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
                    objNgAlm.InsertarMotivoUsuario(idUsuario, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Motivo agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ListarMotivosAcc();
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
                foreach (DataGridViewRow row in dgvListaMotivos.Rows)
                {
                    int intIdMotivo = Convert.ToInt32(row.Cells["id_Motivo"].Value);
                    string strNoMotivo = row.Cells["nombre_Motivo"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoMotivo, intIdMotivo });
                }
                return;
            }

            else{
                foreach (DataGridViewRow row in dgvListaMotivos.Rows)
                {
                    int intIdMotivo = Convert.ToInt32(row.Cells["id_Motivo"].Value);
                    string strNoMotivo = row.Cells["nombre_Motivo"].Value.ToString();
                   
                    string ss = row.Cells["id_Motivo"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);
                    
                    if (foundRow1 != null)
                    {
                       
                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoMotivo, intIdMotivo }); 
                    }

                }
            }
            
            dgvListaMotivosAcc.DataSource = tabla;
        }

        
    }
}
