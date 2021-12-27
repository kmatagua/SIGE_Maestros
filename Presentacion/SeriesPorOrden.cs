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
    public partial class SeriesPorOrden : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;
        public int intIdSeriesPorOrden;

        DataTable tabla = new DataTable();
        DataTable tabla_Numerador = new DataTable();

        DataTable tblUsuario = new DataTable();
        DataTable tbl = new DataTable();
        BindingSource src = new BindingSource();
        BindingSource src2 = new BindingSource();

        public SeriesPorOrden()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("serie");
            tabla.Columns.Add("numero");
            tabla.Columns.Add("observacion");
           
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["id"];
            tabla.PrimaryKey = colPk1;
  

            tabla_Numerador.Columns.Add("id_Numerador");
            tabla_Numerador.Columns.Add("serie_Numerador");
            tabla_Numerador.Columns.Add("numero_Numerador");
            tabla_Numerador.Columns.Add("observacion_Numerador");
            
            tabla_Numerador.Columns.Add("item");
        }

        private void SeriesPorOrden_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarComboOperacion();
            //ListarComboTipoOpe2();
            ListarComboUndProduccion();
            ListarNumerador(idEmpresa);
            Clases.Reglas.alternarColor(dgvListaNumerador);
            Clases.Reglas.alternarColor(dgvListaNumeradorAcc);
            txtIdAlm.Text = Convert.ToString(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarNumerador(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGNumerador obj = new NGNumerador(Configuracion.Sistema.CadenaConexion);
            tbl = obj.NumeradorOrdenes(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tbl.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Numerador.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Numerador"] = row1["intIdNum"].ToString();
                row["serie_Numerador"] = row1["strSerie"].ToString();
                row["numero_Numerador"] = row1["strNumero"].ToString();
                row["observacion_Numerador"] = row1["strObservacion"].ToString();
                
                row["item"] = 1;
                tabla_Numerador.Rows.Add(row);
            }
            src.DataSource = tabla_Numerador;
            dgvListaNumerador.DataSource = src;
        }

        public void ListarNumeradorAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblNumeradorAcc = new DataTable();
            if (txtIdAlm.Text.Trim() != string.Empty)
            {
                NGNumerador obj = new NGNumerador(Configuracion.Sistema.CadenaConexion);
                int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                tblNumeradorAcc = obj.NumeradorAccesoUsuSeriesOrdenes(idUsuario, idEmpresa, ref blnTodoOK);

                foreach (DataRow row1 in tblNumeradorAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdNum"].ToString();
                    row["serie"] = row1["strSerie"].ToString();
                    row["numero"] = row1["strNumero"].ToString();
                    row["observacion"] = row1["strObservacion"].ToString();
                    
                    tabla.Rows.Add(row);
                }
                src2.DataSource = tabla;
                dgvListaNumeradorAcc.DataSource = src2;
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
            int intIdNumerador = Convert.ToInt32(dgvListaNumerador.CurrentRow.Cells["id_Numerador"].Value);
            string strSerieNumerador = dgvListaNumerador.CurrentRow.Cells["serie_Numerador"].Value.ToString();
            string strNroNumerador = dgvListaNumerador.CurrentRow.Cells["numero_Numerador"].Value.ToString();
            string strObservacionNumerador = dgvListaNumerador.CurrentRow.Cells["observacion_Numerador"].Value.ToString();

            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdNumerador == Convert.ToInt32(row2[0].ToString()))
                {
                    MessageBox.Show("El numerador ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaNumeradorAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaNumeradorAcc.Rows.Count > 0)
            {

                bool blnTodoOK = false;
                int idSeleccion;
                int idUsuario;
                Clases.InicialCls.LeerXml();
                idSeleccion = Convert.ToInt32(dgvListaNumeradorAcc.CurrentRow.Cells["id"].Value);
                idUsuario = Convert.ToInt32(cbxUsuario.SelectedValue);
                NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                string message = "Estas Seguro de Eliminar este Numerador?";
                string caption = "Corfirmar Borrado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // MOSTRAR EL MENSAJE DE CONFIRMACION.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    obj.BorrarNumeradorOrdenes(idSeleccion, idUsuario, idEmpresa, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        MessageBox.Show("Numerador Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tabla.Clear();
                    ListarNumeradorAcc();
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
                    //int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                    objNgAlm.InsertarNumeradorUsuarioOrdenes(idUsuario, tabla, idEmpresa, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Numeradores agregadas con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ListarNumeradorAcc();
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
                foreach (DataGridViewRow row in dgvListaNumerador.Rows)
                {
                    int intIdNumerador = Convert.ToInt32(row.Cells["id_Numerador"].Value);
                    string strSerieNumerador = row.Cells["serie_Numerador"].Value.ToString();
                    string strNroNumerador = row.Cells["numero_Numerador"].Value.ToString();
                    string strObservacionNumerador = row.Cells["observacion_Numerador"].Value.ToString();
                  
                    tabla.Rows.Add(new object[] { intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaNumerador.Rows)
                {
                    int intIdNumerador = Convert.ToInt32(row.Cells["id_Numerador"].Value);
                    string strSerieNumerador = row.Cells["serie_Numerador"].Value.ToString();
                    string strNroNumerador = row.Cells["numero_Numerador"].Value.ToString();
                    string strObservacionNumerador = row.Cells["observacion_Numerador"].Value.ToString();
                    
                    string ss = row.Cells["id_Numerador"].Value.ToString();
                   
                    DataRow foundRow1 = tabla.Rows.Find(ss);

                    if (foundRow1 != null)
                    {

                    }
                    else
                    {
                        tabla.Rows.Add(new object[] { intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador });
                    }

                }
            }

            dgvListaNumeradorAcc.DataSource = tabla;
        }

        private void dgvListaNumeradorAcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ListarComboOperacion()
        {
            //bool blnTodoOK = false;
            //Clases.InicialCls.LeerXml();
            //DataTable tbl = new DataTable();
            //NGOperacion obj = new NGOperacion(Configuracion.Sistema.CadenaConexion);
            //tbl = obj.OperacionCombo(ref blnTodoOK);
            //cbxOperacion.DisplayMember = "strNoOperacion";
            //cbxOperacion.ValueMember = "intIdOperacion";
            //cbxOperacion.DataSource = tbl;
        }

        public void filtrar()
        {
            //string operacion = cbxOperacion.SelectedValue.ToString();
            //string filtro = " item = " + "'" + 1 + "'";

            //if (operacion == "-1")
            //{
            //    operacion = "";
            //}

            //if (operacion != "")
            //{
            //    filtro = filtro + " and " + " intIdOperacion = " + "'" + operacion + "'";
            //}


            //src.Filter = filtro;
        }

        private void cbxOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }


        //public void ListarComboTipoOpe2()
        //{
        //    bool blnTodoOK = false;
        //    Clases.InicialCls.LeerXml();
        //    DataTable tbl = new DataTable();
        //    NGTipoOpe obj = new NGTipoOpe(Configuracion.Sistema.CadenaConexion);
        //    tbl = obj.TipoOpeCombo(ref blnTodoOK);

        //    cbxFiltro2.DisplayMember = "strNoTipoOpe";
        //    cbxFiltro2.ValueMember = "intIdTipoOpe";
        //    cbxFiltro2.DataSource = tbl;

        //}

        //public void filtrarNumeradorAcc()
        //{
        //    if (Convert.ToInt32(cbxFiltro2.SelectedValue) == 0)
        //    {
        //        src2.Filter = "";
        //    }
        //    else
        //    {
        //        src2.Filter = "tipo = '" + cbxFiltro2.Text + "'";
        //    }
        //}

        //public void filtrarNumerador()
        //{
        //    if (Convert.ToInt32(cbxFiltro.SelectedValue) == 0)
        //    {
        //        src.Filter = "";
        //    }
        //    else
        //    {
        //        src.Filter = "numero_Numerador = '" + cbxFiltro.Text + "'";
        //    }
        //}

        //private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    filtrarNumerador();
        //}

        //private void cbxFiltro2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    filtrarNumeradorAcc();
        //}

        public void ListarComboUndProduccion()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            tblUsuario = obj.ComboUnidadProduccion(ref blnTodoOK);

            cbxUP.DataSource = tblUsuario;
            cbxUP.DisplayMember = "nombre";
            cbxUP.ValueMember = "id";
            //src.DataSource = tblUsuario;
            //dgvLista.DataSource = src;


        }


    }
}
