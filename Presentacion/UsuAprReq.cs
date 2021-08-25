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
    public partial class UsuAprReq : Form
    {
        public int idEmpresa;
        public int idUsuario;
        public string nombreEmpresa;
        public int tipo;

        DataTable tabla = new DataTable();
        DataTable tblUsuario = new DataTable();
        DataTable tblNumApr = new DataTable();
        DataTable tabla_Numerador = new DataTable();
        DataTable tbl = new DataTable();

        BindingSource src = new BindingSource();
        BindingSource src2 = new BindingSource();

        public UsuAprReq()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("idNumerador");
            tabla.Columns.Add("serie");
            tabla.Columns.Add("numero");
            tabla.Columns.Add("observacion");
            tabla.Columns.Add("operacion");
            tabla.Columns.Add("intNumeroApr");
            tabla.Columns.Add("intTipoReq");
            //DataColumn[] colPk1 = new DataColumn[1];
            //colPk1[0] = tabla.Columns["id"];
            //tabla.PrimaryKey = colPk1;

            tabla_Numerador.Columns.Add("id_Numerador");
            tabla_Numerador.Columns.Add("serie_Numerador");
            tabla_Numerador.Columns.Add("numero_Numerador");
            tabla_Numerador.Columns.Add("observacion_Numerador");
            tabla_Numerador.Columns.Add("almacen_Numerador");
            tabla_Numerador.Columns.Add("operacion_Numerador");
        }

        private void UsuAprReq_Load(object sender, EventArgs e)
        {
            cbxUsuario.SelectedIndexChanged -= cbxUsuario_SelectedIndexChanged;

            ListarNumeradorRequerimiento(idEmpresa);
            lblEmpresa.Text = nombreEmpresa;
            ListarComboUsuario(idEmpresa);
            ListarComboNumApr(idEmpresa);
            ListarComboTipoReq(idEmpresa);

            cbxUsuario.SelectedIndexChanged += cbxUsuario_SelectedIndexChanged;
            
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
                //tblNumeradorAcc = obj.NumeradorAccesoUsu(idUsuario, idEmpresa, ref blnTodoOK);
                tblNumeradorAcc = obj.NumAccesoUsuAprReq(idUsuario, idEmpresa, ref blnTodoOK);
                foreach (DataRow row1 in tblNumeradorAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1["intIdUsuAprReq"].ToString();
                    row["idNumerador"] = row1["intIdNum"].ToString();
                    row["serie"] = row1["strSerie"].ToString();
                    row["numero"] = row1["strNumero"].ToString();
                    row["observacion"] = row1["strObservacion"].ToString();
                    row["operacion"] = row1["strCoSubTipoOpe"].ToString();
                    row["intNumeroApr"] = row1["intNumeroApr"].ToString();
                    row["intTipoReq"] = row1["intIdSubTipoOpe"].ToString();
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

        public void ListarComboNumApr(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            tblNumApr = obj.ComboNumeroApr(idEmpresa, ref blnTodoOK);

            cbxNumeroApr.DataSource = tblNumApr;
            cbxNumeroApr.DisplayMember = "strDescripcion";
            cbxNumeroApr.ValueMember = "intNumero";
            //src.DataSource = tblUsuario;
            //dgvLista.DataSource = src;


        }

        public void ListarComboTipoReq(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            tblNumApr = obj.ComboTipoReq(idEmpresa, ref blnTodoOK);

            cbxTipoReq.DataSource = tblNumApr;
            cbxTipoReq.DisplayMember = "strCoSubTipoOpe";
            cbxTipoReq.ValueMember = "intIdSubTipoOpe";
            //src.DataSource = tblUsuario;
            //dgvLista.DataSource = src;
            //intIdSubTipoOpe, strCoSubTipoOpe

        }

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
            txtIdAlm.Text = valor.ToString();
            tabla.Clear();
            ListarNumeradorAcc();
        }

        public void ListarNumeradorRequerimiento(int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGNumerador obj = new NGNumerador(Configuracion.Sistema.CadenaConexion);
            tbl = obj.NumeradorRequerimiento(idEmpresa, ref blnTodoOK);
            foreach (DataRow row1 in tbl.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Numerador.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Numerador"] = row1["intIdNum"].ToString();
                row["serie_Numerador"] = row1["strSerie"].ToString();
                row["numero_Numerador"] = row1["strNumero"].ToString();
                row["observacion_Numerador"] = row1["strObservacion"].ToString();
                row["almacen_Numerador"] = row1["strNoAlm"].ToString();
                row["operacion_Numerador"] = row1["strNoOperacion"].ToString();

                tabla_Numerador.Rows.Add(row);
            }
            src.DataSource = tabla_Numerador;
            dgvListaNumerador.DataSource = src;
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdNumerador = Convert.ToInt32(dgvListaNumerador.CurrentRow.Cells["id_Numerador"].Value);
            string strSerieNumerador = dgvListaNumerador.CurrentRow.Cells["serie_Numerador"].Value.ToString();
            string strNroNumerador = dgvListaNumerador.CurrentRow.Cells["numero_Numerador"].Value.ToString();
            string strObservacionNumerador = dgvListaNumerador.CurrentRow.Cells["observacion_Numerador"].Value.ToString();
            string strAlmacenNumerador = dgvListaNumerador.CurrentRow.Cells["almacen_Numerador"].Value.ToString();
            string strNoOperacionNumerador = cbxTipoReq.Text;
            int intNumApr = Convert.ToInt32(cbxNumeroApr.SelectedValue);
            int intTipoReq = Convert.ToInt32(cbxTipoReq.SelectedValue);

            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdNumerador == Convert.ToInt32(row2[1].ToString()) && intNumApr == Convert.ToInt32(row2["intNumeroApr"].ToString()) && intTipoReq == Convert.ToInt32(row2["intTipoReq"].ToString()))
                {
                    MessageBox.Show("El numerador ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador, strNoOperacionNumerador, intNumApr, intTipoReq });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaNumeradorAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            if (dgvListaNumeradorAcc.Rows.Count > 0)
            {
                //string message = "Estas Seguro de Eliminar este Numerador?";
                //string caption = "Corfirmar Borrado";
                //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                //DialogResult result;

                //// MOSTRAR EL MENSAJE DE CONFIRMACION.

                //result = MessageBox.Show(message, caption, buttons);

                //if (result == System.Windows.Forms.DialogResult.Yes)
                //{

                int index = dgvListaNumeradorAcc.CurrentRow.Index;
                dgvListaNumeradorAcc.Rows.RemoveAt(index);
                
                //bool blnTodoOK = false;
                //int idSeleccion;
                //int idUsuario;
                //Clases.InicialCls.LeerXml();
                //idSeleccion = Convert.ToInt32(dgvListaNumeradorAcc.CurrentRow.Cells["id"].Value);
                //idUsuario = Convert.ToInt32(cbxUsuario.SelectedValue);
                //NGUsuario obj = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                //string message = "Estas Seguro de Eliminar este Numerador?";
                //string caption = "Corfirmar Borrado";
                //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                //DialogResult result;

                //// MOSTRAR EL MENSAJE DE CONFIRMACION.

                //result = MessageBox.Show(message, caption, buttons);

                //if (result == System.Windows.Forms.DialogResult.Yes)
                //{

                //    //obj.BorrarNumerador(idSeleccion, idUsuario, idEmpresa, ref blnTodoOK);

                //    if (blnTodoOK)
                //    {
                //        MessageBox.Show("Numerador Eliminado con Éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    tabla.Clear();
                //    ListarNumeradorAcc();
                //}
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("No ha seleccionado un Usuario al cual asignarle permisos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

                    NGComun objNgAlm = new NGComun(Configuracion.Sistema.CadenaConexion);
                    int idUsuario = (cbxUsuario.SelectedValue is DBNull) ? 0 : Convert.ToInt32(cbxUsuario.SelectedValue.ToString());
                    //objNgAlm.InsertarNumeradorUsuario(idUsuario, tabla, idEmpresa, ref blnTodoOK);
                    objNgAlm.InsertarNumeroAprobacion(idUsuario, tabla, idEmpresa, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Numerador agregado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cbxUsuario.SelectedValue = 0;
                    //this.Close();

                }
                tabla.Clear();
                ListarNumeradorAcc();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
