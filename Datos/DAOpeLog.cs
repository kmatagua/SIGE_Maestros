using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DAOpeLog
    {
        private string _pStrConString = string.Empty;

        public DAOpeLog(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaOpeLog(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_Q01", cn);
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

        public DataTable ListaGridOpeLog(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_EMP_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable ListaOpeLogAcc(int intIdEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_EMP_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", intIdEmp);
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

        public DataTable ListaOpeLogAccAlm(int idAlmacen, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_ALM_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
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

        public DataTable ListaOpeLogAccUsu(int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_USU_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaFiltrar(string filtro, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_Q03", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
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

        public DataTable BuscarOpeLog(int intIdOpeLog, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", intIdOpeLog);
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

        public void InsertarOpeLog(ENOpeLog objEnOpeLog, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OpeLog_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoOpeLog", objEnOpeLog.strCoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@strNoOpeLog", objEnOpeLog.strNoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnOpeLog.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intTransAut", objEnOpeLog.intTransAut);
                da.SelectCommand.Parameters.AddWithValue("@intTransformar", objEnOpeLog.intTransformar);
                da.SelectCommand.Parameters.AddWithValue("@intCompra", objEnOpeLog.intCompra);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipo", objEnOpeLog.intIdTipo);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnOpeLog.intIdUsuCr); 
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarOpeLog2(ENOpeLog objEnOpeLog, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OpeLog_I02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoOpeLog", objEnOpeLog.strCoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@strNoOpeLog", objEnOpeLog.strNoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnOpeLog.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intTransAut", objEnOpeLog.intTransAut);
                da.SelectCommand.Parameters.AddWithValue("@intIdTransOpe", objEnOpeLog.intIdTransOpe);
                da.SelectCommand.Parameters.AddWithValue("@intIdTransformar", objEnOpeLog.intTransformar);
                da.SelectCommand.Parameters.AddWithValue("@intCompra", objEnOpeLog.intCompra);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipo", objEnOpeLog.intIdTipo);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnOpeLog.intIdUsuCr);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarOpeLog(ENOpeLog objEnOpeLog, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", objEnOpeLog.intIdOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@strCoOpeLog", objEnOpeLog.strCoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@strNoOpeLog", objEnOpeLog.strNoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipo", objEnOpeLog.intIdTipo);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnOpeLog.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdTransOpe", objEnOpeLog.intIdTransOpe);
                da.SelectCommand.Parameters.AddWithValue("@intTransAut", objEnOpeLog.intTransAut);
                da.SelectCommand.Parameters.AddWithValue("@intTransformar", objEnOpeLog.intTransformar);
                da.SelectCommand.Parameters.AddWithValue("@intCompra", objEnOpeLog.intCompra);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnOpeLog.intIdUsuMf);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarOpeLog2(ENOpeLog objEnOpeLog, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OPELOG_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", objEnOpeLog.intIdOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@strCoOpeLog", objEnOpeLog.strCoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@strNoOpeLog", objEnOpeLog.strNoOpeLog);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipo", objEnOpeLog.intIdTipo);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnOpeLog.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intTransAut", objEnOpeLog.intTransAut);
                da.SelectCommand.Parameters.AddWithValue("@intTransformar", objEnOpeLog.intTransformar);
                da.SelectCommand.Parameters.AddWithValue("@intIdTransOpe", objEnOpeLog.intIdTransOpe);
                da.SelectCommand.Parameters.AddWithValue("@intCompra", objEnOpeLog.intCompra);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnOpeLog.intIdUsuMf);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EliminarOpeLog(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_OpeLog_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", idSeleccion);
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
