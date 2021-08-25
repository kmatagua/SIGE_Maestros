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
    public partial class MotivoEmpresa : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Motivo = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public MotivoEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("idMotivo");

            tabla_Motivo.Columns.Add("id_Motivo");
            tabla_Motivo.Columns.Add("nombre_Motivo");          
        }

        private void MotivoEmpresa_Load(object sender, EventArgs e)
        {
            ListarMotivos();
            lblEmpresa.Text = nombreEmpresa;
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaMotivos);
            Clases.Reglas.alternarColor(dgvListaMotivosAcc);
            ListarMotivosAcc();
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
            tblEmp = obj.Motivo(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
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
            DataTable tblEmpAcc = new DataTable();

            NGMotivo obj = new NGMotivo(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.MotivoEmp(idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdMotEmp"].ToString();
                    row["nombre"] = row1["strNoMot"].ToString();
                    row["idMotivo"] = row1["intIdMot"].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaMotivosAcc.DataSource = tabla;
            
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdMotivo = Convert.ToInt32(dgvListaMotivos.CurrentRow.Cells["id_Motivo"].Value);
            string strNoMotivo = dgvListaMotivos.CurrentRow.Cells["nombre_Motivo"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdMotivo == Convert.ToInt32(row2["idMotivo"].ToString()))
                {
                    MessageBox.Show("El Motivo ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, strNoMotivo, intIdMotivo });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaMotivosAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            //if (dgvListaUniNegAcc.Rows.Count > 0)
            //{
            //    int index = dgvListaUniNegAcc.CurrentRow.Index;
            //    dgvListaUniNegAcc.Rows.RemoveAt(index);
            //}
            if (dgvListaMotivosAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaMotivosAcc.CurrentRow.Cells["id"].Value);

                NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);

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

                    objNgEmp.InsertarMotivosEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Motivos agregados con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ListarMotivosAcc();
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        


    }
}
