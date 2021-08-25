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
    public partial class UniNegSede : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public int idSede;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_UniNeg = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public UniNegSede()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idUniNeg");

            tabla_UniNeg.Columns.Add("id_UniNeg");
            tabla_UniNeg.Columns.Add("nombre_UniNeg");          
        }


        private void UniNegSede_Load(object sender, EventArgs e)
        {
            ListarUniNeg();
            lblEmpresa.Text = nombreEmpresa;
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            ListarComboSede(idEmpresa);
            //Clases.Reglas.alternarColor(dgvListaUniNeg);
            //Clases.Reglas.alternarColor(dgvListaUniNegAcc);
            //ListarUniNegAcc();
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

        public void ListarUniNegAcc(int idSede)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            
                NGUndNegocio obj = new NGUndNegocio(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.UndNegocioSede(idSede, ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUndNegSede"].ToString();
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
                if (intIdUniNeg == Convert.ToInt32(row2[2].ToString()))
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

                NGUndNegocio obj = new NGUndNegocio(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar esta Unidad de Negocio?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarUniNegSede(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Unidad de Negocio Eliminada con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarUniNegAcc(Convert.ToInt32(cbxSede.SelectedValue));
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

                    NGUndNegocio objNgEmp = new NGUndNegocio(Configuracion.Sistema.CadenaConexion);

                    objNgEmp.InsertarUniNegSede(Convert.ToInt32(cbxSede.SelectedValue), tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Unidad de Negocio agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarUniNegAcc(Convert.ToInt32(cbxSede.SelectedValue));
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ListarComboSede(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGSede obj = new NGSede(Configuracion.Sistema.CadenaConexion);
            tbl = obj.Sede(idEmpresa, ref blnTodoOK);

            
            cbxSede.DisplayMember = "strNoSede";
            cbxSede.ValueMember = "intIdSede";
            cbxSede.DataSource = tbl;

        }

        private void cbxSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            idSede = Convert.ToInt32(cbxSede.SelectedValue);
            tabla.Clear();
            ListarUniNegAcc(idSede);
        }


    }
}
