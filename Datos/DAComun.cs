using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Configuracion;
using Entidad;

namespace Datos
{
    public class DAComun
    {
         private string _pStrConString = string.Empty;

         public DAComun(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

         public DataTable Listar_Combo(string p_maestro, int p_id, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MAESTROS_COMBO_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@maestro", p_maestro);
                da.SelectCommand.Parameters.AddWithValue("@id", p_id);
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

         public DataTable Listar_Combo2(string p_maestro, int p_id, int p_intIdEmp, int p_intIdUsu, int p_intIdAlm, int intIdSede, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             SqlCommand cmd = new SqlCommand();
             DataTable tbl = new DataTable();
             try
             {
                 cn.Open();
                 SqlDataAdapter da = new SqlDataAdapter("SP_MAESTROS_COMBO_Q02", cn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@maestro", p_maestro);
                 da.SelectCommand.Parameters.AddWithValue("@id", p_id);
                 da.SelectCommand.Parameters.AddWithValue("@intIdEmp", p_intIdEmp);
                 da.SelectCommand.Parameters.AddWithValue("@intIdUsu", p_intIdUsu);
                 da.SelectCommand.Parameters.AddWithValue("@intIdAlm", p_intIdAlm);
                 da.SelectCommand.Parameters.AddWithValue("@intIdSede", intIdSede);
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

         public DataTable ListaFiltrar(string maestro, string filtro, int intId, int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             pBlnTodoOk = false;
             DataTable tbl = new DataTable();
             try
             {
                 cn.Open();
                 SqlDataAdapter da = new SqlDataAdapter("SP_MAESTROS_BUSQUEDA_Q01", cn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@maestro", maestro);
                 da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                 da.SelectCommand.Parameters.AddWithValue("@intId", intId);
                 da.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                 da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                 da.Fill(tbl);
                 pBlnTodoOk = true;
                 cn.Close();
             }
             catch (Exception ex)
             {
                 Libreria.Error_Grabar(ex);
                 pBlnTodoOk = false;
             }
             return tbl;
         }

         public void Usuario_validar(string p_strNoUsuar, string p_strPwUsuar, ref int p_intIdUsuar, ref string p_strMensaje, ref bool pBlnTodoOk)
         {
             pBlnTodoOk = false;
             SqlConnection cn = new SqlConnection(_pStrConString);
             try
             {
                 cn.Open();
                 SqlCommand cmd = new SqlCommand("SP_USUARIO_V01", cn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@strNoUsu", SqlDbType.NVarChar, 50).Value = p_strNoUsuar;
                 cmd.Parameters.Add("@strClave", SqlDbType.NVarChar, 50).Value = p_strPwUsuar;
                 cmd.Parameters.Add("@intIdUsu", SqlDbType.Int).Direction = ParameterDirection.Output;
                 cmd.Parameters.Add("@mensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                 cmd.ExecuteNonQuery();
                 p_strMensaje = cmd.Parameters["@mensaje"].Value.ToString();
                 p_intIdUsuar = (cmd.Parameters["@intIdUsu"].Value is DBNull) ? 0 : Convert.ToInt32(cmd.Parameters["@intIdUsu"].Value);
                 pBlnTodoOk = true;
             }
             catch (Exception ex)
             {
                 Libreria.Error_Grabar(ex);
             }
             cn.Close();
         }

         public DataTable Botones(int idUsuario, string tagMenu, int idEmpresa, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             pBlnTodoOk = false;
             DataTable tbl = new DataTable();
             try
             {
                 cn.Open();
                 SqlDataAdapter da = new SqlDataAdapter("SP_BOTONES_VALIDA_Q01", cn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                 da.SelectCommand.Parameters.AddWithValue("@tagMenu", tagMenu);
                 da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                 da.Fill(tbl);
                 pBlnTodoOk = true;
                 cn.Close();
             }
             catch (Exception ex)
             {
                 Libreria.Error_Grabar(ex);
                 pBlnTodoOk = false;
             }
             return tbl;
         }

         public void ListaUbigeo(int idUbigeo, ref string nombreDepartamento, ref string nombreProvincia, ref bool blnTodoOK)
         {
             blnTodoOK = false;
             SqlConnection cn = new SqlConnection(_pStrConString);
             try
             {
                 cn.Open();
                 SqlCommand cmd = new SqlCommand("SP_LISTA_UBIGEO_Q01", cn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 //cmd.Parameters.Add("@strCoDepartamento", SqlDbType.NVarChar, 50).Value = codigoDepartamento;
                 //cmd.Parameters.Add("@strCoProvincia", SqlDbType.NVarChar, 50).Value = codigoProvincia;
                 cmd.Parameters.Add("@intIdUbigeo", SqlDbType.Int).Value = idUbigeo;
                 cmd.Parameters.Add("@strNoDepartamento", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                 cmd.Parameters.Add("@strNoProvincia", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                 cmd.ExecuteNonQuery();
                 nombreDepartamento = cmd.Parameters["@strNoDepartamento"].Value.ToString();
                 nombreProvincia = cmd.Parameters["@strNoProvincia"].Value.ToString();
                 blnTodoOK = true;
             }
             catch (Exception ex)
             {
                 Libreria.Error_Grabar(ex);
             }
             cn.Close();
         }
         
        public DataTable ListarSerieDefault(int idTipoDoc, int idEmpresa, int idUsuario, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             SqlCommand cmd = new SqlCommand();
             DataTable tbl = new DataTable();
             pBlnTodoOk = false;
             try
             {
                 cn.Open();
                 //SqlDataAdapter da = new SqlDataAdapter("SP_CLIENTE_BUSCA_Q01", cn);
                 SqlDataAdapter da = new SqlDataAdapter("SP_SERIE_DEFAULT_Q01", cn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@idTipoDoc", idTipoDoc);
                 da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                 da.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
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

         public void EditarSerieDefault(List<ENSerieDefault> lista, ref string mensaje, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             pBlnTodoOk = false;

             try
             {
                 cn.Open();
                 mensaje = string.Empty;
                 foreach (ENSerieDefault item in lista)
                 {
                     SqlDataAdapter dad = new SqlDataAdapter("SP_SERIE_DEFAULT_U01", cn);
                     dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                     //dad.SelectCommand.Parameters.AddWithValue("@intIdDetCabGuia", item.intIdDetCom);
                     dad.SelectCommand.Parameters.AddWithValue("@intIdUsuNum", item.intIdUsuNum);
                     dad.SelectCommand.Parameters.AddWithValue("@intDefault", item.intDefault);
                     dad.SelectCommand.ExecuteNonQuery();

                 }

                 pBlnTodoOk = true;
                 cn.Close();
             }
             catch (Exception ex)
             {
                 Libreria.Error_Grabar(ex);
                 pBlnTodoOk = false;
             }
         }

         public DataTable comboNumeroApr(int p_id, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             SqlCommand cmd = new SqlCommand();
             DataTable tbl = new DataTable();
             try
             {
                 cn.Open();
                 SqlDataAdapter da = new SqlDataAdapter("SP_NUMEROAPR_COMBO_Q01", cn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@id", p_id);
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

         public DataTable comboTipoReq(int p_id, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             SqlCommand cmd = new SqlCommand();
             DataTable tbl = new DataTable();
             try
             {
                 cn.Open();
                 SqlDataAdapter da = new SqlDataAdapter("SP_TIPOREQ_COMBO_Q01", cn);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.AddWithValue("@id", p_id);
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

         public void InsertarNumeroAprobacion(int idUsuario, DataTable tabla, int idEmpresa, ref bool pBlnTodoOk)
         {
             SqlConnection cn = new SqlConnection(_pStrConString);
             pBlnTodoOk = false;

             try
             {
                 cn.Open();

                 SqlDataAdapter daD = new SqlDataAdapter("SP_NUMERO_APRREQ_USU_UD01", cn);
                 daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                 daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                 daD.SelectCommand.ExecuteNonQuery();

                 if (tabla.Rows.Count > 0)
                 {
                     SqlDataAdapter da1 = new SqlDataAdapter("SP_NUMERO_APRREQ_USU_I01", cn);
                     da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                     foreach (DataRow row in tabla.Rows)
                     {
                         da1.SelectCommand.Parameters.Clear();
                         //    id

                         da1.SelectCommand.Parameters.AddWithValue("@intIdNum", Convert.ToInt32(row["idNumerador"].ToString()));
                         da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                         da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                         da1.SelectCommand.Parameters.AddWithValue("@intNumApr", Convert.ToInt32(row["intNumeroApr"].ToString()));
                         da1.SelectCommand.Parameters.AddWithValue("@intIdUsuAprReq", Convert.ToInt32(row["id"].ToString()));
                         da1.SelectCommand.Parameters.AddWithValue("@intIdSubTipoOpe", Convert.ToInt32(row["intTipoReq"].ToString()));

                         da1.SelectCommand.ExecuteNonQuery();

                     }
                 }
                 pBlnTodoOk = true;
                 cn.Close();
             }
             catch (Exception ex)
             {
                 pBlnTodoOk = false;
             }
         }

        public DataTable ComboUnidadProduccion(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_COMBO_UNIDAD_PRODUCCION_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
