using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidad;

namespace Datos
{
    public class DAEmpleado
    {
        private string _pStrConString = string.Empty;

        public DAEmpleado(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaEmpleado(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPLEADO_Q01", cn);
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

        //public DataTable ListaSubEmpleadoAcc(int idEmp, ref bool pBlnTodoOk)
        //{
        //    SqlConnection cn = new SqlConnection(_pStrConString);
        //    pBlnTodoOk = false;
        //    DataTable tbl = new DataTable();
        //    try
        //    {
        //        cn.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("SP_EMPLEADO_Q02", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmp);
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

        public DataTable ListaFiltrar(string filtro, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPLEADO_Q03", cn);
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

        public DataTable BuscarEmpleado(int intIdEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPLEADO_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", intIdEmp);
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

        public void InsertarEmpleado(ENEmpleado obj, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPLEADO_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoEmp", obj.strCoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strNoEmp", obj.strNoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strDni", obj.strDni);
                da.SelectCommand.Parameters.AddWithValue("@strTlf", obj.strTlf);
                da.SelectCommand.Parameters.AddWithValue("@strTlfMovil", obj.strTlfMovil);
                da.SelectCommand.Parameters.AddWithValue("@strCorreo", obj.strCorreo);
                da.SelectCommand.Parameters.AddWithValue("@strDireccion", obj.strDireccion);
                da.SelectCommand.Parameters.AddWithValue("@dttFecReg", obj.dttFecReg);
                da.SelectCommand.Parameters.AddWithValue("@intIdCanalDist", obj.intIdCanalDist);

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

        public void EditarEmpleado(ENEmpleado obj, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPLEADO_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", obj.intIdEmp);
                da.SelectCommand.Parameters.AddWithValue("@strCoEmp", obj.strCoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strNoEmp", obj.strNoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strDni", obj.strDni);
                da.SelectCommand.Parameters.AddWithValue("@strTlf", obj.strTlf);
                da.SelectCommand.Parameters.AddWithValue("@strTlfMovil", obj.strTlfMovil);
                da.SelectCommand.Parameters.AddWithValue("@strCorreo", obj.strCorreo);
                da.SelectCommand.Parameters.AddWithValue("@strDireccion", obj.strDireccion);
                da.SelectCommand.Parameters.AddWithValue("@dttFecReg", obj.dttFecReg);
                da.SelectCommand.Parameters.AddWithValue("@intIdCanalDist", obj.intIdCanalDist);

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

        public void EliminarEmpleado(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_Empleado_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idSeleccion);
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

        public DataTable ListaGridEmpleado(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMP_EMP_Q02", cn);
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

        public DataTable ListaEmpleadoAccEmp(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMP_EMP_Q01", cn);
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

        public DataTable ListaEmpleadoAccClaEmp(int idClaEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMP_CLAEMP_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdClaEmp", idClaEmp);
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

        public DataTable ListarVendedor(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_VENDEDOR_Q02", cn);
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
