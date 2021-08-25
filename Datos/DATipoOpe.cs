using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DATipoOpe
    {
        private string _pStrConString = string.Empty;

        public DATipoOpe(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

      
        public DataTable ListaTipoOpe(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_TIPOOPE_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
               // da.SelectCommand.Parameters.AddWithValue("@intIdUsu", intIdUsu);
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
    }
}
