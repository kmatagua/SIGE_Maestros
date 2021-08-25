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
    public partial class TipoDocEmpresa : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_TipoDoc = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public TipoDocEmpresa()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("default");

            tabla_TipoDoc.Columns.Add("id_TipoDoc");
            tabla_TipoDoc.Columns.Add("nombre_TipoDoc");          
        }


        private void TipoDocEmpresa_Load(object sender, EventArgs e)
        {
            ListarTipoDoc();
            lblEmpresa.Text = nombreEmpresa;
            txtIdEmp.Text = Convert.ToString(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaTipoDoc);
            Clases.Reglas.alternarColor(dgvListaTipoDocAcc);
            ListarTipoDocAcc();
        }
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarTipoDoc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGTipoDoc obj = new NGTipoDoc(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.TipoDoc(ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_TipoDoc.NewRow();
                //asignas el dato a cada columna de la row
                row["id_TipoDoc"] = row1[0].ToString();
                row["nombre_TipoDoc"] = row1[2].ToString();
                tabla_TipoDoc.Rows.Add(row);
            }
            dgvListaTipoDoc.DataSource = tabla_TipoDoc;
        }

        public void ListarTipoDocAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            if (txtIdEmp.Text.Trim() != string.Empty)
            {
                NGTipoDoc obj = new NGTipoDoc(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.TipoDocAcceso(Convert.ToInt32(txtIdEmp.Text), ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaTipoDocAcc.DataSource = tabla;
            }
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdTipoDoc = Convert.ToInt32(dgvListaTipoDoc.CurrentRow.Cells["id_TipoDoc"].Value);
            string strNoTipoDoc = dgvListaTipoDoc.CurrentRow.Cells["nombre_TipoDoc"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdTipoDoc == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("El Tipo de Documento " + strNoTipoDoc + " ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdTipoDoc, strNoTipoDoc });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaTipoDocAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaTipoDocAcc.Rows.Count > 0)
            {
                int index = dgvListaTipoDocAcc.CurrentRow.Index;
                dgvListaTipoDocAcc.Rows.RemoveAt(index);
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

                    objNgEmp.InsertarTipoDocEmpresa(idEmpresa, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("TipoDoces agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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
