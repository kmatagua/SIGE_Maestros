using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DATipoCambio
    {
        private string _pStrConString = string.Empty;

        public DATipoCambio(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaTipoCambio(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_TIPOCAMBIO_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.Fill(tbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        

        public DataTable ListaFiltrar(string filtro, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_TipoCambio_Q03", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.Fill(tbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        public DataTable BuscarTipoCambio(int intIdTipoCambio, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_TIPOCAMBIO_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoCambio", intIdTipoCambio);
                da.Fill(rowTbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return rowTbl;
        }

        public void InsertarTipoCambio(ENTipoCambio objEn, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_TIPOCAMBIO_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@decPrecioCompra", SqlDbType.Decimal).Value = objEn.decPrecioCompra;
                cmd.Parameters.Add("@decPrecioVenta", SqlDbType.Decimal).Value = objEn.decPrecioVenta;
                cmd.Parameters.Add("@dttFeTipoCambio", SqlDbType.DateTime).Value = objEn.dttFeTipoCambio;
                cmd.Parameters.Add("@intEstado", SqlDbType.Int).Value = objEn.intEstado;
                cmd.Parameters.Add("@intIdUsuCr", SqlDbType.Int).Value = objEn.intIdUsuCr;
                cmd.Parameters.Add("@intIdMoneda", SqlDbType.Int).Value = objEn.intIdMoneda;
                cmd.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                mensaje = cmd.Parameters["@strMensaje"].Value.ToString();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarTipoCambio(ENTipoCambio objEn, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_TIPOCAMBIO_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoCambio", objEn.intIdTipoCambio);
                da.SelectCommand.Parameters.AddWithValue("@decPrecioCompra", objEn.decPrecioCompra);
                da.SelectCommand.Parameters.AddWithValue("@decPrecioVenta", objEn.decPrecioVenta);
                da.SelectCommand.Parameters.AddWithValue("@dttFeTipoCambio", objEn.dttFeTipoCambio);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEn.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEn.intIdUsuMf);
                da.SelectCommand.Parameters.AddWithValue("@intIdMoneda", objEn.intIdMoneda);

                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EliminarTipoCambio(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_TIPOCAMBIO_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoCambio", idSeleccion);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        

        
    }
}
