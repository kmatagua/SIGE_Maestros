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
    public class DACliente
    {
        private string _pStrConString = string.Empty;

        public DACliente(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaCliente(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTE_Q01", cn);
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

        public DataTable ListaClienteAprobar(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTEAPROBAR_Q01", cn);
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

        public DataTable ListaClienteTodo(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_Cliente_Q05", cn);
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

        public DataTable ListaClienteAcc(int intIdEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_Cliente_EMP_Q01", cn);
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

        public DataTable ListaSubClienteAcc(int idCliente, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_Cliente_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCliente", idCliente);
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
                SqlDataAdapter da = new SqlDataAdapter("SP_Cliente_Q03", cn);
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

        public DataTable BuscarCliente(int intIdCliente, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTE_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCliente", intIdCliente);
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

        public void InsertarCliente(ENCliente obj, List<ENDireccionCliente> lista, int idEmpresa, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTE_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoCliente", obj.strCoCliente);
                da.SelectCommand.Parameters.AddWithValue("@strNoCliente", obj.strNoCliente);
                da.SelectCommand.Parameters.AddWithValue("@strRazSoc", obj.strRazSoc);
                da.SelectCommand.Parameters.AddWithValue("@strApePat", obj.strApePat);
                da.SelectCommand.Parameters.AddWithValue("@strApeMat", obj.strApeMat);
                da.SelectCommand.Parameters.AddWithValue("@strNom1", obj.strNom1);
                da.SelectCommand.Parameters.AddWithValue("@strNom2", obj.strNom2);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoPer", obj.intIdTipoPer);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoDocPer", obj.intIdTipoDocPer);
                da.SelectCommand.Parameters.AddWithValue("@strRuc", obj.strRuc);
                da.SelectCommand.Parameters.AddWithValue("@strDni", obj.strDni);
                //da.SelectCommand.Parameters.AddWithValue("@strDireccion", obj.strDireccion);
                da.SelectCommand.Parameters.AddWithValue("@strContacto", obj.strContacto);
                da.SelectCommand.Parameters.AddWithValue("@strMail", obj.strMail);
                da.SelectCommand.Parameters.AddWithValue("@strTlfFijo", obj.strTlfFijo);
                da.SelectCommand.Parameters.AddWithValue("@strTlfMovil", obj.strTlfMovil);
                da.SelectCommand.Parameters.AddWithValue("@dttFeReg", obj.dttFeReg);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoCliente", obj.intIdTipoCliente);
                da.SelectCommand.Parameters.AddWithValue("@intIdGiroCliente", obj.intIdGiroCliente);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoListaPrecio", obj.intIdTipoListaPrecio);

                da.SelectCommand.Parameters.AddWithValue("@intIdCaliCliente", obj.intIdCaliCliente);
                da.SelectCommand.Parameters.AddWithValue("@intIdEstadoAprobacion", obj.intIdEstadoAprobacion);
                da.SelectCommand.Parameters.AddWithValue("@intIdArea", obj.intIdArea);
                da.SelectCommand.Parameters.AddWithValue("@strZona", obj.strZona);
                da.SelectCommand.Parameters.AddWithValue("@strRuta", obj.strRuta);
                da.SelectCommand.Parameters.AddWithValue("@strInterrelacion", obj.strInterrelacion);

                da.SelectCommand.Parameters.AddWithValue("@decLimCre", obj.decLimCre);
                da.SelectCommand.Parameters.AddWithValue("@intIdFormaPago", obj.intIdFormaPago);
                da.SelectCommand.Parameters.AddWithValue("@intTransportista", obj.intTransportista);

                da.SelectCommand.Parameters.AddWithValue("@intEstado", obj.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", obj.intIdUsuCr);


                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.SelectCommand.Parameters.Add("@intIdCliente", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();

                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                if (mensaje != string.Empty)
                { cn.Close(); return; }
                int p_intIdCliente = Convert.ToInt32(da.SelectCommand.Parameters["@intIdCliente"].Value);



                mensaje = string.Empty;
                foreach (ENDireccionCliente item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DIRECCION_CLIENTE_I01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdCliente", p_intIdCliente);
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

        public void EditarCliente(ENCliente obj, List<ENDireccionCliente> lista, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                Edit_Elim_Cliente(obj.intIdCliente, obj.intIdUsuMf, ref pBlnTodoOk);
                if (!pBlnTodoOk)
                    return;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTE_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCliente", obj.intIdCliente);
                da.SelectCommand.Parameters.AddWithValue("@strCoCliente", obj.strCoCliente);
                da.SelectCommand.Parameters.AddWithValue("@strNoCliente", obj.strNoCliente);
                da.SelectCommand.Parameters.AddWithValue("@strRazSoc", obj.strRazSoc);
                da.SelectCommand.Parameters.AddWithValue("@strApePat", obj.strApePat);
                da.SelectCommand.Parameters.AddWithValue("@strApeMat", obj.strApeMat);
                da.SelectCommand.Parameters.AddWithValue("@strNom1", obj.strNom1);
                da.SelectCommand.Parameters.AddWithValue("@strNom2", obj.strNom2);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoPer", obj.intIdTipoPer);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoDocPer", obj.intIdTipoDocPer);
                da.SelectCommand.Parameters.AddWithValue("@strRuc", obj.strRuc);
                da.SelectCommand.Parameters.AddWithValue("@strDni", obj.strDni);
                //da.SelectCommand.Parameters.AddWithValue("@strDireccion", obj.strDireccion);
                da.SelectCommand.Parameters.AddWithValue("@strContacto", obj.strContacto);
                da.SelectCommand.Parameters.AddWithValue("@strMail", obj.strMail);
                da.SelectCommand.Parameters.AddWithValue("@strTlfFijo", obj.strTlfFijo);
                da.SelectCommand.Parameters.AddWithValue("@strTlfMovil", obj.strTlfMovil);
                da.SelectCommand.Parameters.AddWithValue("@dttFeReg", obj.dttFeReg);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoCliente", obj.intIdTipoCliente);
                da.SelectCommand.Parameters.AddWithValue("@intIdGiroCliente", obj.intIdGiroCliente);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoListaPrecio", obj.intIdTipoListaPrecio);

                da.SelectCommand.Parameters.AddWithValue("@intIdCaliCliente", obj.intIdCaliCliente);
                da.SelectCommand.Parameters.AddWithValue("@intIdEstadoAprobacion", obj.intIdEstadoAprobacion);
                da.SelectCommand.Parameters.AddWithValue("@intIdArea", obj.intIdArea);
                da.SelectCommand.Parameters.AddWithValue("@strZona", obj.strZona);
                da.SelectCommand.Parameters.AddWithValue("@strRuta", obj.strRuta);
                da.SelectCommand.Parameters.AddWithValue("@strInterrelacion", obj.strInterrelacion);

                da.SelectCommand.Parameters.AddWithValue("@decLimCre", obj.decLimCre);
                da.SelectCommand.Parameters.AddWithValue("@intIdFormaPago", obj.intIdFormaPago);
                da.SelectCommand.Parameters.AddWithValue("@intTransportista", obj.intTransportista);

                da.SelectCommand.Parameters.AddWithValue("@intEstado", obj.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", obj.intIdUsuMf);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                if (mensaje != string.Empty)
                { cn.Close(); return; }
                int p_intIdCliente = Convert.ToInt32(da.SelectCommand.Parameters["@intIdCliente"].Value);



                mensaje = string.Empty;
                foreach (ENDireccionCliente item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DIRECCION_CLIENTE_U01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdDireccionCliente", item.intIdDireccionCliente);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdCliente", p_intIdCliente);
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

        public void Edit_Elim_Cliente(int intIdCliente, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DIRECCION_CLIENTE_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCliente", intIdCliente);
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

        public void EliminarCliente(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTE_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCliente", idSeleccion);
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

        public DataTable ListarDireccion(int idCliente, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            pBlnTodoOk = false;
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DIRECCION_CLIENTE_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCliente", idCliente);
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
