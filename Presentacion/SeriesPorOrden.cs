﻿using System;
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

        public string valor;
        public string index;
        public string valor2;
        public string index2;
        public string valor3;
        public string index3;

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
            tabla.Columns.Add("idNew");
            tabla.Columns.Add("id_numerador");
            tabla.Columns.Add("serie");
            tabla.Columns.Add("numero");
            tabla.Columns.Add("observacion");
            tabla.Columns.Add("intIdUndProduccion");
            tabla.Columns.Add("strNoUndProduccion");

            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tabla.Columns["idNew"];
            tabla.PrimaryKey = colPk1;

            tabla_Numerador.Columns.Add("id");
            tabla_Numerador.Columns.Add("id_Numerador");
            tabla_Numerador.Columns.Add("serie_Numerador");
            tabla_Numerador.Columns.Add("numero_Numerador");
            tabla_Numerador.Columns.Add("observacion_Numerador");
            tabla_Numerador.Columns.Add("almacen_Numerador");
            tabla_Numerador.Columns.Add("tipoOpe_Numerador");
            tabla_Numerador.Columns.Add("intIdOperacion");
            tabla_Numerador.Columns.Add("strNoOperacion");

            tabla_Numerador.Columns.Add("item");

            var Valores = new List<Valor>();
            Valores.Add(new Valor() { Index = "", Value = "-- SELECCIONE --" });
            Valores.Add(new Valor() { Index = "01", Value = "SANTA ANITA" });
            Valores.Add(new Valor() { Index = "02", Value = "CALLAO" });
            Valores.Add(new Valor() { Index = "03", Value = "PISCO 1" });
            Valores.Add(new Valor() { Index = "04", Value = "PISCO 2" });
            Valores.Add(new Valor() { Index = "05", Value = "PARACHIQUE" });
            Valores.Add(new Valor() { Index = "06", Value = "SULLANA" });
            Valores.Add(new Valor() { Index = "07", Value = "TERCEROS LIMA" });
            Valores.Add(new Valor() { Index = "08", Value = "TERCEROS PIURA" });
            Valores.Add(new Valor() { Index = "09", Value = "EXTERNOS" });
            Valores.Add(new Valor() { Index = "10", Value = "HUACHO" });
            Valores.Add(new Valor() { Index = "11", Value = "PUENTE PIEDRA" });
            Valores.Add(new Valor() { Index = "12", Value = "CHIMBOTE" });
            cbxSede.DataSource = Valores;

            var Valores2 = new List<Valor>();
            Valores2.Add(new Valor() { Index = "", Value = "-- SELECCIONE --" });
            Valores2.Add(new Valor() { Index = "00", Value = "ADMINISTRACION" });
            Valores2.Add(new Valor() { Index = "01", Value = "CENTRO DIST. Y VENTAS" });
            Valores2.Add(new Valor() { Index = "02", Value = "PLANTA HARINA" });
            Valores2.Add(new Valor() { Index = "03", Value = "PLANTA CONSERVAS" });
            Valores2.Add(new Valor() { Index = "04", Value = "PLANTA VELAS" });
            Valores2.Add(new Valor() { Index = "05", Value = "CENTRO DE CUSTODIO PT" });
            Valores2.Add(new Valor() { Index = "06", Value = "CENTRO DE CUSTODIO MIR" });
            Valores2.Add(new Valor() { Index = "07", Value = "FLOTA" });
            cbxCO.DataSource = Valores2;

            var Valores3 = new List<Valor>();
            Valores3.Add(new Valor() { Index = "", Value = "-- SELECCIONE --" });
            Valores3.Add(new Valor() { Index = "01", Value = "COMPRAS" });
            Valores3.Add(new Valor() { Index = "02", Value = "SERVICIOS" });
            Valores3.Add(new Valor() { Index = "03", Value = "MP COMPRAS" });
            Valores3.Add(new Valor() { Index = "04", Value = "MP SERVICIOS" });
            Valores3.Add(new Valor() { Index = "05", Value = "CAJAS" });
            Valores3.Add(new Valor() { Index = "06", Value = "RR HH" });
            Valores3.Add(new Valor() { Index = "07", Value = "COMERCIAL - C" });
            Valores3.Add(new Valor() { Index = "08", Value = "COMERCIAL - S" });
            Valores3.Add(new Valor() { Index = "09", Value = "ALMACEN(ROOLD) - C" });
            Valores3.Add(new Valor() { Index = "10", Value = "ALMACEN(ROOLD) - S" });
            Valores3.Add(new Valor() { Index = "11", Value = "DORIS - EMILIO - C" });
            Valores3.Add(new Valor() { Index = "12", Value = "DORIS - EMILIO - S" });
            Valores3.Add(new Valor() { Index = "13", Value = "LORENZO TRILLO -C" });
            Valores3.Add(new Valor() { Index = "14", Value = "LORENZO TRILLO -S" });
            Valores3.Add(new Valor() { Index = "15", Value = "NORMA - C" });
            Valores3.Add(new Valor() { Index = "16", Value = "NORMA - S" });
            cbxTA.DataSource = Valores3;
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
                row["almacen_Numerador"] = row1["strNoAlm"].ToString();
                row["tipoOpe_Numerador"] = row1["strNoTipoOpe"].ToString();
                row["intIdOperacion"] = row1["intIdOperacion"].ToString();
                row["strNoOperacion"] = row1["strNoOperacion"].ToString();
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
                    row["id"] = row1["intIdSeriesPorOrden"].ToString();
                    row["idNew"] = row1["intIdNum"].ToString() + "" + row1["intIdUndProduccion"].ToString();
                    row["id_numerador"] = row1["intIdNum"].ToString();
                    row["serie"] = row1["strSerie"].ToString();
                    row["numero"] = row1["strNumero"].ToString();
                    row["observacion"] = row1["strObservacion"].ToString();
                    row["intIdUndProduccion"] = row1["intIdUndProduccion"].ToString();
                    row["strNoUndProduccion"] = row1["strNoUndProduccion"].ToString();
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
            int intIdNumerador = Convert.ToInt32(dgvListaNumerador.CurrentRow.Cells["id_num"].Value);
            string strSerieNumerador = dgvListaNumerador.CurrentRow.Cells["serie_Numerador"].Value.ToString();
            string strNroNumerador = dgvListaNumerador.CurrentRow.Cells["numero_Numerador"].Value.ToString();
            string strObservacionNumerador = dgvListaNumerador.CurrentRow.Cells["observacion_Numerador"].Value.ToString();
            int idUndProduccion = Convert.ToInt32(cbxUP.SelectedValue);
            string strUnidadProduccion = cbxUP.Text;

            if (Convert.ToInt32(cbxUsuario.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(cbxUP.SelectedValue) <= 0)
            {
                MessageBox.Show("Selecione Unidad de Producción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdNumerador == Convert.ToInt32(row2["id_numerador"].ToString()) && idUndProduccion == Convert.ToInt32(row2["intIdUndProduccion"].ToString()))
                {
                    MessageBox.Show("El numerador ya fue Asignado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            tabla.Rows.Add(new object[] { 0, intIdNumerador+""+idUndProduccion,intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador, idUndProduccion, strUnidadProduccion });

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
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    int intIdNumerador = Convert.ToInt32(row.Cells["id_Numerador"].Value);
                    string strSerieNumerador = row.Cells["serie_Numerador"].Value.ToString();
                    string strNroNumerador = row.Cells["numero_Numerador"].Value.ToString();
                    string strObservacionNumerador = row.Cells["observacion_Numerador"].Value.ToString();
                  
                    tabla.Rows.Add(new object[] { id, intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador });
                }
                return;
            }

            else
            {
                foreach (DataGridViewRow row in dgvListaNumerador.Rows)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
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
                        tabla.Rows.Add(new object[] { id, intIdNumerador, strSerieNumerador, strNroNumerador, strObservacionNumerador });
                    }

                }
            }

            dgvListaNumeradorAcc.DataSource = tabla;
        }

        private void dgvListaNumeradorAcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void filtrar()
        {
            string operacion;
            string serie = index +""+ index2 +""+index3;
            if(cbxOperacion.SelectedValue is null) {
                operacion = "";
            } else
            {
                operacion = cbxOperacion.SelectedValue.ToString();
            }

            
            string filtro = " item = " + "'" + 1 + "'";

            if (operacion == "-1")
            {
                operacion = "";
            }

            if (operacion != "")
            {
                filtro = filtro + " and " + " intIdOperacion = " + "'" + operacion + "'";
            }

            if (serie != "")
            {
                filtro = filtro + " and " + " serie_Numerador like " + "'%" + serie + "%'";
            }

            src.Filter = filtro;
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

        public void ListarComboOperacion()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            NGOperacion obj = new NGOperacion(Configuracion.Sistema.CadenaConexion);
            tbl = obj.OperacionCombo(ref blnTodoOK);
            cbxOperacion.DisplayMember = "strNoOperacion";
            cbxOperacion.ValueMember = "intIdOperacion";
            cbxOperacion.DataSource = tbl;
            cbxOperacion.SelectedValue = 5;
        }

        public class Valor
        {
            public string Value { get; set; }
            public string Index { get; set; }
        }

        private void cbxSede_Format(object sender, ListControlConvertEventArgs e)
        {
            valor = ((Valor)e.ListItem).Value;
            index = ((Valor)e.ListItem).Index;
            e.Value = index + " - " + valor;
        }
        private void cbxCO_Format(object sender, ListControlConvertEventArgs e)
        {
            valor2 = ((Valor)e.ListItem).Value;
            index2 = ((Valor)e.ListItem).Index;
            e.Value = index2 + " - " + valor2;
        }
        private void cbxTA_Format(object sender, ListControlConvertEventArgs e)
        {
            valor3 = ((Valor)e.ListItem).Value;
            index3 = ((Valor)e.ListItem).Index;
            e.Value = index3 + " - " + valor3;
        }

        private void cbxSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void cbxCO_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void cbxTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
