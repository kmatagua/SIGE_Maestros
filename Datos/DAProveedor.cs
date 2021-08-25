using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidad;
using Configuracion;

namespace Datos
{
    public class DAProveedor
    {
        private string _pStrConString = string.Empty;

        public DAProveedor(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaProveedor(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_PROVEEDOR_Q01", cn);
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

        public void InsertarProveedor(ENProveedor objEnEmp, List<ENDireccionProveedor> lista, int idProveedor, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_PROVEEDOR_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strApePat", objEnEmp.strApePat);
                da.SelectCommand.Parameters.AddWithValue("@strApeMat", objEnEmp.strApeMat);
                da.SelectCommand.Parameters.AddWithValue("@strNomb", objEnEmp.strNomb);
                da.SelectCommand.Parameters.AddWithValue("@strNombProv", objEnEmp.strNombProv);

                da.SelectCommand.Parameters.AddWithValue("@dttFeIng", objEnEmp.dttFeIng);
                da.SelectCommand.Parameters.AddWithValue("@strDNI", objEnEmp.strDNI);
                da.SelectCommand.Parameters.AddWithValue("@strTel", objEnEmp.strTel);
                da.SelectCommand.Parameters.AddWithValue("@strContacto", objEnEmp.strContacto);

                da.SelectCommand.Parameters.AddWithValue("@strRazSoc", objEnEmp.strRazSoc);
                da.SelectCommand.Parameters.AddWithValue("@strRUC", objEnEmp.strRUC);
                da.SelectCommand.Parameters.AddWithValue("@strCorreo", objEnEmp.strCorreo);

                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnEmp.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnEmp.intIdUsuCr);

                da.SelectCommand.Parameters.Add("@idProveedor", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                if (mensaje != string.Empty)
                { cn.Close(); return; }
                int p_intIdProveedor = Convert.ToInt32(da.SelectCommand.Parameters["@idProveedor"].Value);



                mensaje = string.Empty;
                foreach (ENDireccionProveedor item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DIRECCION_PROVEEDOR_I01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdProveedor", p_intIdProveedor);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdCalle", item.intIdCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoCalle", item.strNoCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strNro", item.strNro);
                    dad.SelectCommand.Parameters.AddWithValue("@strPabellon", item.strPabellon);
                    dad.SelectCommand.Parameters.AddWithValue("@strMz", item.strMz);
                    dad.SelectCommand.Parameters.AddWithValue("@strLote", item.strLote);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdTipoDep", item.intIdTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoTipoDep", item.strNoTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUrbanismo", item.intIdUrbanismo);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoUrb", item.strNoUrb);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdSector", item.intIdSector);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoSector", item.strNoSector);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUbigeo", item.intIdUbigeo);
                    dad.SelectCommand.Parameters.AddWithValue("@strDireccion", item.strDireccion);
                    dad.SelectCommand.Parameters.AddWithValue("@intDefault", item.intDefault);

                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", item.intIdUsuCr);

                    dad.SelectCommand.ExecuteNonQuery();

                    mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();

                }
                pBlnTodoOk = true;
                cn.Close();

            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public DataTable BuscarProveedor(int intIdProv, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_PROVEEDOR_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdProv", intIdProv);
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

        public void EditarProveedor(ENProveedor objEnEmp, List<ENDireccionProveedor> lista, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                Edit_Elim_Proveedor(objEnEmp.intIdProv, objEnEmp.intIdUsuMf, ref pBlnTodoOk);
                if (!pBlnTodoOk)
                    return;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_PROVEEDOR_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdProv", objEnEmp.intIdProv);
                da.SelectCommand.Parameters.AddWithValue("@strApePat", objEnEmp.strApePat);
                da.SelectCommand.Parameters.AddWithValue("@strApeMat", objEnEmp.strApeMat);
                da.SelectCommand.Parameters.AddWithValue("@strNomb", objEnEmp.strNomb);
                da.SelectCommand.Parameters.AddWithValue("@strNombProv", objEnEmp.strNombProv);

                da.SelectCommand.Parameters.AddWithValue("@dttFeIng", objEnEmp.dttFeIng);
                da.SelectCommand.Parameters.AddWithValue("@strDNI", objEnEmp.strDNI);
                da.SelectCommand.Parameters.AddWithValue("@strTel", objEnEmp.strTel);
                da.SelectCommand.Parameters.AddWithValue("@strContacto", objEnEmp.strContacto);

                da.SelectCommand.Parameters.AddWithValue("@strRazSoc", objEnEmp.strRazSoc);
                da.SelectCommand.Parameters.AddWithValue("@strRUC", objEnEmp.strRUC);
                da.SelectCommand.Parameters.AddWithValue("@strCorreo", objEnEmp.strCorreo);

                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnEmp.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnEmp.intIdUsuMf);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();

                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                if (mensaje != string.Empty)
                { cn.Close(); return; }
                int p_intIdProveedor = Convert.ToInt32(da.SelectCommand.Parameters["@intIdProv"].Value);


                mensaje = string.Empty;
                foreach (ENDireccionProveedor item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DIRECCION_PROVEEDOR_U01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdDireccionProveedor", item.intIdDireccionProveedor);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdProveedor", p_intIdProveedor);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdCalle", item.intIdCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strDireccion", item.strDireccion);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoCalle", item.strNoCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strNro", item.strNro);
                    dad.SelectCommand.Parameters.AddWithValue("@strPabellon", item.strPabellon);
                    dad.SelectCommand.Parameters.AddWithValue("@strMz", item.strMz);
                    dad.SelectCommand.Parameters.AddWithValue("@strLote", item.strLote);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdTipoDep", item.intIdTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoTipoDep", item.strNoTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUrbanismo", item.intIdUrbanismo);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoUrb", item.strNoUrb);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdSector", item.intIdSector);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUbigeo", item.intIdUbigeo);
                    dad.SelectCommand.Parameters.AddWithValue("@intDefault", item.intDefault);

                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", item.intIdUsuMf);
                    dad.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    dad.SelectCommand.ExecuteNonQuery();

                    mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();

                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void Edit_Elim_Proveedor(int intIdProveedor, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DIRECCION_PROVEEDOR_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdProveedor", intIdProveedor);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                Libreria.Error_Grabar(ex);
                pBlnTodoOk = false;
            }
        }

        public DataTable ListarDireccionProveedor(int idProveedor, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            pBlnTodoOk = false;
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DIRECCION_PROVEEDOR_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdProv", idProveedor);
                da.Fill(tbl);
                pBlnTodoOk = true;
            }
            catch (Exception ex)
            {
                Libreria.Error_Grabar(ex);
                pBlnTodoOk = false;
            }
            cn.Close();
            return tbl;
        }
       
    }
}
