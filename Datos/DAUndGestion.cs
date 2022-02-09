using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidad;

namespace Datos
{
    public class DAUndGestion
    {
        private string _pStrConString = string.Empty;

        public DAUndGestion(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaUndGestion(int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNDGESTION_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
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

        public DataTable ListaGridUniGes(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNIGES_EMP_Q01", cn);
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

        public DataTable ListaUniGesAccUsu(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNIGES_USU_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaUniGesAccUsuAprReq(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNIGES_USU_APR_REQ_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaUndGestionTodo(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNDGESTION_TODO_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        //public DataTable ListaUniNegAcc(int idEmpresa, ref bool pBlnTodoOk)
        //{
        //    SqlConnection cn = new SqlConnection(_pStrConString);
        //    pBlnTodoOk = false;
        //    DataTable tbl = new DataTable();
        //    try
        //    {
        //        cn.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("SP_UNINEG_EMP_Q02", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
        //        da.Fill(tbl);
        //        pBlnTodoOk = true;
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        pBlnTodoOk = false;
        //    }
        //    return tbl;
        //}

        //public DataTable ListaFiltrar(string filtro, ref bool pBlnTodoOk)
        //{
        //    SqlConnection cn = new SqlConnection(_pStrConString);
        //    pBlnTodoOk = false;
        //    DataTable tbl = new DataTable();
        //    try
        //    {
        //        cn.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("SP_UNDNEGOCIO_Q03", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
        //        da.Fill(tbl);
        //        pBlnTodoOk = true;
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        pBlnTodoOk = false;
        //    }
        //    return tbl;
        //}

        public DataTable BuscarUndGestion(int intIdUndGestion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNDGESTION_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUndGestion", intIdUndGestion);
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

        public void InsertarUndGestion(ENUndGestion obj, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNDGESTION_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoUndGestion", obj.strCoUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@strNoUndGestion", obj.strNoUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@strNivelUndGestion", obj.strNivelUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", obj.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", obj.intIdUsuCr);
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

        public void EditarUndGestion(ENUndGestion obj, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNDGESTION_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUndGestion", obj.intIdUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@strCoUndGestion", obj.strCoUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@strNoUndGestion", obj.strNoUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@strNivelUndGestion", obj.strNivelUndGestion);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", obj.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", obj.intIdUsuMf);

                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EliminarUndGestion(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNDGESTION_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUndGestion", idSeleccion);
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

        //public void InsertarMaqUniNeg(int idUniNeg, DataTable tabla, ref bool pBlnTodoOk)
        //{
        //    SqlConnection cn = new SqlConnection(_pStrConString);
        //    pBlnTodoOk = false;

        //    try
        //    {
        //        cn.Open();
        //        SqlDataAdapter daD = new SqlDataAdapter("SP_MAQ_UNINEG_D01", cn);
        //        daD.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        daD.SelectCommand.Parameters.AddWithValue("@intIdUniNeg", idUniNeg);
        //        daD.SelectCommand.ExecuteNonQuery();
        //        // ----  id
        //        SqlDataAdapter da1 = new SqlDataAdapter("SP_MAQ_UNINEG_I01", cn);
        //        da1.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        foreach (DataRow row in tabla.Rows)
        //        {
        //            da1.SelectCommand.Parameters.Clear();
        //            //    id
        //            da1.SelectCommand.Parameters.AddWithValue("@intIdUniNeg", idUniNeg);
        //            da1.SelectCommand.Parameters.AddWithValue("@intIdMaq", Convert.ToInt32(row[0].ToString()));

        //            da1.SelectCommand.ExecuteNonQuery();

        //        }

        //        pBlnTodoOk = true;
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        pBlnTodoOk = false;
        //    }
        //}

        public DataTable ListaUndGestionEmp(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNIGES_EMP_Q01", cn);
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
    }
}
