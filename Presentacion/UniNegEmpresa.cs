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
    public partial class UniNegEmpresa : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_UniNeg = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public UniNegEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idUniNeg");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idUniNeg"];
            tabla.PrimaryKey = colPk1;

            tabla_UniNeg.Columns.Add("id_UniNeg");
            tabla_UniNeg.Columns.Add("nombre_UniNeg");          
        }

        private void UniNegEmpresa_Load(object sender, EventArgs e)
        {
            ListarUniNeg();
            lblEmpresa.Text = nombreEmpresa;
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaUniNeg);
            Clases.Reglas.alternarColor(dgvListaUniNegAcc);
            ListarUniNegAcc();
        }

       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarUniNeg()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGUndNegocio obj = new NGUndNegocio(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.UndNegocioTodo(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_UniNeg.NewRow();
                //asignas el dato a cada columna de la row
                row["id_UniNeg"] = row1["intIdUndNeg"].ToString();
                row["nombre_UniNeg"] = row1["strNoUndNeg"].ToString();
                tabla_UniNeg.Rows.Add(row);
            }
            dgvListaUniNeg.DataSource = tabla_UniNeg;
        }

        public void ListarUniNegAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            
                NGUndNegocio obj = new NGUndNegocio(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.UndNegocioEmp(idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUndNeg"].ToString();
                    row["nombre"] = row1["strNoUndNeg"].ToString();
                    row["idUniNeg"] = row1["intIdUndNeg"].ToString();

                    tabla.Rows.Add(row);
                }

                dgvListaUniNegAcc.DataSource = tabla;
            
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdUniNeg = Convert.ToInt32(dgvListaUniNeg.CurrentRow.Cells["id_UniNeg"].Value);
            string strNoUniNeg = dgvListaUniNeg.CurrentRow.Cells["nombre_UniNeg"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdUniNeg == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("La Operación ya fue Asignada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoUniNeg, intIdUniNeg });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaUniNegAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            //if (dgvListaUniNegAcc.Rows.Count > 0)
            //{
            //    int index = dgvListaUniNegAcc.CurrentRow.Index;
            //    dgvListaUniNegAcc.Rows.RemoveAt(index);
            //}
            if (dgvListaUniNegAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaUniNegAcc.CurrentRow.Cells["id"].Value);

                NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar esta Unidad de Negocio?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarUniNeg(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Unidad de Negocio Eliminada con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarUniNegAcc();
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

                    objNgEmp.InsertarUniNegEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Unidad de Negocio agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarUniNegAcc();
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
                foreach (DataGridViewRow row in dgvListaUniNeg.Rows)
                {
                    int intIdUniNeg = Convert.ToInt32(row.Cells["id_UniNeg"].Value);
                    string strNoUniNeg = row.Cells["nombre_UniNeg"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoUniNeg, intIdUniNeg });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaUniNeg.Rows)
                {
                    int intIdUniNeg = Convert.ToInt32(row.Cells["id_UniNeg"].Value);
                    string strNoUniNeg = row.Cells["nombre_UniNeg"].Value.ToString();

                    string ss = row.Cells["id_UniNeg"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoUniNeg, intIdUniNeg });
                    }

                }
            }

            dgvListaUniNegAcc.DataSource = tabla;
        }

    }
}
