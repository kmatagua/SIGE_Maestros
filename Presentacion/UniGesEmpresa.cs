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
    public partial class UniGesEmpresa : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_UniGes = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public UniGesEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idUniGes");

            tabla_UniGes.Columns.Add("id_UniGes");
            tabla_UniGes.Columns.Add("nombre_UniGes");          
        }

        private void UniGesEmpresa_Load(object sender, EventArgs e)
        {
            ListarUniGes();
            lblEmpresa.Text = nombreEmpresa;
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaUniGes);
            Clases.Reglas.alternarColor(dgvListaUniGesAcc);
            ListarUniGesAcc();
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
            tblEmp = obj.UndGestionTodo(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
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
            DataTable tblEmpAcc = new DataTable();

            NGUndGestion obj = new NGUndGestion(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.UndGestionEmp(idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUniGesEmp"].ToString();
                    row["nombre"] = row1["strNoUndGestion"].ToString();
                    row["idUniGes"] = row1["intIdUndGestion"].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaUniGesAcc.DataSource = tabla;
            
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdUniGes = Convert.ToInt32(dgvListaUniGes.CurrentRow.Cells["id_UniGes"].Value);
            string strNoUniGes = dgvListaUniGes.CurrentRow.Cells["nombre_UniGes"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdUniGes == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Unidad de Gestión ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoUniGes, intIdUniGes });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaUniGesAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            //if (dgvListaUniNegAcc.Rows.Count > 0)
            //{
            //    int index = dgvListaUniNegAcc.CurrentRow.Index;
            //    dgvListaUniNegAcc.Rows.RemoveAt(index);
            //}
            if (dgvListaUniGesAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaUniGesAcc.CurrentRow.Cells["id"].Value);

                NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar esta Unidad de Gestión?";
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
                        MessageBox.Show("Unidad de Gestion Eliminada con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    objNgEmp.InsertarUniGesEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Unidad de Gestión agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarUniGesAcc();
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPasaTodo_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            //{
            //    MessageBox.Show("Seleccione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

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

            else
            {
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
