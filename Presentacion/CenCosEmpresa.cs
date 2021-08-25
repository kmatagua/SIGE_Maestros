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
    public partial class CenCosEmpresa : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_CenCos = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public CenCosEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idCenCos");
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idCenCos"];
            tabla.PrimaryKey = colPk1;

            tabla_CenCos.Columns.Add("id_CenCos");
            tabla_CenCos.Columns.Add("nombre_CenCos");          
        }
        
        private void CenCosEmpresa_Load(object sender, EventArgs e)
        {
            ListarCenCos();
            lblEmpresa.Text = nombreEmpresa;
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaCenCos);
            Clases.Reglas.alternarColor(dgvListaCenCosAcc);
            ListarCenCosAcc();
        }
               
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarCenCos()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            try
            {
                NGCentroCosto obj = new NGCentroCosto(Configuracion.Sistema.CadenaConexion);
                tblEmp = obj.CenCosTodo(ref blnTodoOK);
                foreach (DataRow row1 in tblEmp.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla_CenCos.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id_CenCos"] = row1["intIdCenCos"].ToString();
                    row["nombre_CenCos"] = row1["strNoCenCos"].ToString();
                    tabla_CenCos.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dgvListaCenCos.DataSource = tabla_CenCos;
        }

        public void ListarCenCosAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();

            NGCentroCosto obj = new NGCentroCosto(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.CenCosEmp(idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdCenCosEmp"].ToString();
                    row["nombre"] = row1["strNoCenCos"].ToString();
                    row["idCenCos"] = row1["intIdCenCos"].ToString();

                    tabla.Rows.Add(row);
                }

                dgvListaCenCosAcc.DataSource = tabla;
            
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdCenCos= Convert.ToInt32(dgvListaCenCos.CurrentRow.Cells["id_CenCos"].Value);
            string strNoCenCos = dgvListaCenCos.CurrentRow.Cells["nombre_CenCos"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdCenCos == Convert.ToInt32(row2[2].ToString()))
                {
                    MessageBox.Show("El centro de costo ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoCenCos, intIdCenCos });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaCenCosAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            //if (dgvListaUniNegAcc.Rows.Count > 0)
            //{
            //    int index = dgvListaUniNegAcc.CurrentRow.Index;
            //    dgvListaUniNegAcc.Rows.RemoveAt(index);
            //}
            if (dgvListaCenCosAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaCenCosAcc.CurrentRow.Cells["id"].Value);

                NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Centro de Costo?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarCenCos(idSeleccion, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Centro de Costo Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarCenCosAcc();
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

                    objNgEmp.InsertarCenCosEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Centro de Costo agregados con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarCenCosAcc();
                    //this.Close();

                }
                ListarCenCosAcc();
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
                foreach (DataGridViewRow row in dgvListaCenCos.Rows)
                {
                    int intIdCenCos = Convert.ToInt32(row.Cells["id_CenCos"].Value);
                    string strNoCenCos = row.Cells["nombre_CenCos"].Value.ToString();
                    tabla.Rows.Add(new object[] { 0, strNoCenCos, intIdCenCos });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaCenCos.Rows)
                {
                    int intIdCenCos = Convert.ToInt32(row.Cells["id_CenCos"].Value);
                    string strNoCenCos = row.Cells["nombre_CenCos"].Value.ToString();

                    string ss = row.Cells["id_CenCos"].Value.ToString();
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { 0, strNoCenCos, intIdCenCos });
                    }

                }
            }

            dgvListaCenCosAcc.DataSource = tabla;
        }

    }
}
