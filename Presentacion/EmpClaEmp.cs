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
    public partial class EmpClaEmp : Form
    {
        //public int idEmpresa;
        //public string nombreEmpresa;
        public int idUsuario;
        public int idEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tabla_Empleado = new DataTable();

        DataTable tbl = new DataTable();
        BindingSource src = new BindingSource();

        public EmpClaEmp()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");

            tabla_Empleado.Columns.Add("id_Emp");
            tabla_Empleado.Columns.Add("nombre_Emp");          
        }

        private void EmpClaEmp_Load(object sender, EventArgs e)
        {
            cbxClasif.SelectedIndexChanged -= cbxClasif_SelectedIndexChanged;


            //lblEmpresa.Text = nombreEmpresa;
            ListarComboClaEmp();
            ListarEmpleado();
            Clases.Reglas.alternarColor(dgvListaEmpleado);
            Clases.Reglas.alternarColor(dgvListaEmpleadoAcc);
            //txtIdAlm.Text = Convert.ToString(idEmpresa);



            cbxClasif.SelectedIndexChanged += cbxClasif_SelectedIndexChanged;
        }
               
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarEmpleado()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGEmpleado obj = new NGEmpleado(Configuracion.Sistema.CadenaConexion);
            tbl = obj.GridEmpleado(ref blnTodoOK);
            foreach (DataRow row1 in tbl.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Empleado.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Emp"] = row1[0].ToString();
                row["nombre_Emp"] = row1[1].ToString();
                tabla_Empleado.Rows.Add(row);
            }
            dgvListaEmpleado.DataSource = tabla_Empleado;
        }

        public void ListarEmpleadoAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpleadoAcc = new DataTable();
           
                NGEmpleado obj = new NGEmpleado(Configuracion.Sistema.CadenaConexion);
                int idClaEmp = (cbxClasif.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxClasif.SelectedValue.ToString());
                tblEmpleadoAcc = obj.EmpleadoAccesoClaEmp(idClaEmp, ref blnTodoOK);

                foreach (DataRow row1 in tblEmpleadoAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    
                    tabla.Rows.Add(row);
                }

                dgvListaEmpleadoAcc.DataSource = tabla;
           
        }

        public void ListarComboClaEmp()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGClaEmp obj = new NGClaEmp(Configuracion.Sistema.CadenaConexion);
            tbl = obj.ComboClaEmp(ref blnTodoOK);

            cbxClasif.DataSource = tbl;
            cbxClasif.DisplayMember = "strNoClaEmp";
            cbxClasif.ValueMember = "intIdClaEmp";
            //src.DataSource = tblAlmacen;
            //dgvLista.DataSource = src;


        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdEmp = Convert.ToInt32(dgvListaEmpleado.CurrentRow.Cells["id_Emp"].Value);
            string strNoEmp = dgvListaEmpleado.CurrentRow.Cells["nombre_Emp"].Value.ToString();
            if (Convert.ToInt32(cbxClasif.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Clasificación de Empleado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdEmp == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("El Empleado ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdEmp, strNoEmp });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaEmpleadoAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaEmpleadoAcc.Rows.Count > 0)
            {
                int index = dgvListaEmpleadoAcc.CurrentRow.Index;
                dgvListaEmpleadoAcc.Rows.RemoveAt(index);
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

                    NGClaEmp objNgEmp = new NGClaEmp(Configuracion.Sistema.CadenaConexion);
                    int idClaEmp = (cbxClasif.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxClasif.SelectedValue.ToString());
                    objNgEmp.InsertarEmpleadoClaEmp(idClaEmp, tabla, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Empleados agregados con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cbxAlmacen.SelectedValue = 0;
                    //this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void cbxClasif_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxClasif.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxClasif.SelectedValue.ToString());
            txtIdEmp.Text = valor.ToString();
            tabla.Clear();
            ListarEmpleadoAcc();
        }

        


    }
}
