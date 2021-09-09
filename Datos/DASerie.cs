using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidad;

namespace Datos
{
    public class DASerie
    {
        private string _pStrConString = string.Empty;

        public DASerie(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaSeriePorOrden(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_SERIES_X_ORDEN_Q01", cn);
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

        public void EliminarSeriePorOrden(int idSeleccion, int idUsuario, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_SERIE_POR_ORDEN_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdSede", idSeleccion);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
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

    }
}
