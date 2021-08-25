using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;
using Configuracion;

namespace Datos
{
    public class DAArticulo
    {
        private string _pStrConString = string.Empty;

        public DAArticulo(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaArticulo(int idEmpresa, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_Q01", cn);
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

        public DataTable ListaFiltrar(string filtro, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_Q03", cn);
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

        public DataTable BuscarArticulo(int intIdArt, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArt", intIdArt);
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

        public void InsertarArticulo(ENArticulo objEnArt, List<ENDetKit> lista, int idEmpresa, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoArt", objEnArt.strCoArt);
                da.SelectCommand.Parameters.AddWithValue("@strNoArt", objEnArt.strNoArt);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnArt.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intFav", objEnArt.intFav);
                da.SelectCommand.Parameters.AddWithValue("@intKit", objEnArt.intKit);
                da.SelectCommand.Parameters.AddWithValue("@intReceta", objEnArt.intReceta);
                da.SelectCommand.Parameters.AddWithValue("@intComposicion", objEnArt.intComposicion);
                da.SelectCommand.Parameters.AddWithValue("@intIdSubFamilia", objEnArt.intIdSubFamilia);
                da.SelectCommand.Parameters.AddWithValue("@intIdUni", objEnArt.intIdUni);
                da.SelectCommand.Parameters.AddWithValue("@intIdUniComp", objEnArt.intIdUniComp);
                da.SelectCommand.Parameters.AddWithValue("@intIdClaArt", objEnArt.intIdClaArt);
                da.SelectCommand.Parameters.AddWithValue("@strCodAlt", objEnArt.strCodAlt);
                da.SelectCommand.Parameters.AddWithValue("@strTag", objEnArt.strTag);
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnArt.intIdUsuCr);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.Add("@intIdArt", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                int p_intIdArt = Convert.ToInt32(da.SelectCommand.Parameters["@intIdArt"].Value);

                if (mensaje != string.Empty)
                { cn.Close(); return; }

                mensaje = string.Empty;
                foreach (ENDetKit item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DETARTICULO_KIT_I01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdKit", p_intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdArt", item.intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@decCant", item.decCant);
                    dad.SelectCommand.Parameters.AddWithValue("@decPonderado", item.decPonderado);
                    dad.SelectCommand.Parameters.AddWithValue("@decPU", item.decPU);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", item.intIdUsuCr);
                    dad.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    dad.SelectCommand.ExecuteNonQuery();

                    if (dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() != string.Empty)
                    {
                        mensaje += "IdArtículo: " + item.intIdArt + "\n" + "Mensaje: " + dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() + "\n\n";
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

        public void InsertarArticuloReceta(ENArticulo objEnArt, List<ENDetReceta> lista, int idEmpresa, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoArt", objEnArt.strCoArt);
                da.SelectCommand.Parameters.AddWithValue("@strNoArt", objEnArt.strNoArt);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnArt.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intFav", objEnArt.intFav);
                da.SelectCommand.Parameters.AddWithValue("@intKit", objEnArt.intKit);
                da.SelectCommand.Parameters.AddWithValue("@intReceta", objEnArt.intReceta);
                da.SelectCommand.Parameters.AddWithValue("@intComposicion", objEnArt.intComposicion);
                da.SelectCommand.Parameters.AddWithValue("@intIdSubFamilia", objEnArt.intIdSubFamilia);
                da.SelectCommand.Parameters.AddWithValue("@intIdUni", objEnArt.intIdUni);
                da.SelectCommand.Parameters.AddWithValue("@intIdUniComp", objEnArt.intIdUniComp);
                da.SelectCommand.Parameters.AddWithValue("@intIdClaArt", objEnArt.intIdClaArt);
                da.SelectCommand.Parameters.AddWithValue("@strCodAlt", objEnArt.strCodAlt);
                da.SelectCommand.Parameters.AddWithValue("@strTag", objEnArt.strTag);
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnArt.intIdUsuCr);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.Add("@intIdArt", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                int p_intIdArt = Convert.ToInt32(da.SelectCommand.Parameters["@intIdArt"].Value);

                if (mensaje != string.Empty)
                { cn.Close(); return; }

                mensaje = string.Empty;
                foreach (ENDetReceta item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DETARTICULO_RECETA_I01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdReceta", p_intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdArt", item.intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@decCant", item.decCant);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", item.intIdUsuCr);
                    dad.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    dad.SelectCommand.ExecuteNonQuery();

                    if (dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() != string.Empty)
                    {
                        mensaje += "IdArtículo: " + item.intIdArt + "\n" + "Mensaje: " + dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() + "\n\n";
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

        public void EditarArticulo(ENArticulo objEnArt, List<ENDetKit> lista, int idEmpresa, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                Edit_Elim_ArtKit(objEnArt.intIdArt, objEnArt.intIdUsuMf, ref pBlnTodoOk);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArt", objEnArt.intIdArt);
                da.SelectCommand.Parameters.AddWithValue("@strCoArt", objEnArt.strCoArt);
                da.SelectCommand.Parameters.AddWithValue("@strNoArt", objEnArt.strNoArt);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnArt.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intFav", objEnArt.intFav);
                da.SelectCommand.Parameters.AddWithValue("@intKit", objEnArt.intKit);
                da.SelectCommand.Parameters.AddWithValue("@intReceta", objEnArt.intReceta);
                da.SelectCommand.Parameters.AddWithValue("@intComposicion", objEnArt.intComposicion);
                da.SelectCommand.Parameters.AddWithValue("@intIdSubFamilia", objEnArt.intIdSubFamilia);
                da.SelectCommand.Parameters.AddWithValue("@intIdUni", objEnArt.intIdUni);
                da.SelectCommand.Parameters.AddWithValue("@intIdUniComp", objEnArt.intIdUniComp);
                da.SelectCommand.Parameters.AddWithValue("@intIdClaArt", objEnArt.intIdClaArt);
                da.SelectCommand.Parameters.AddWithValue("@strCodAlt", objEnArt.strCodAlt);
                da.SelectCommand.Parameters.AddWithValue("@strTag", objEnArt.strTag);
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnArt.intIdUsuMf);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();

                if (mensaje != string.Empty)
                { cn.Close(); return; }

                mensaje = string.Empty;
                foreach (ENDetKit item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DETARTICULO_RECETA_U01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdArtReceta", item.intIdArtKit);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdReceta", objEnArt.intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdArt", item.intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@decCant", item.decCant);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", item.intIdUsuMf);
                    dad.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    dad.SelectCommand.ExecuteNonQuery();
                    if (dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() != string.Empty)
                    {
                        mensaje += "IdArtículo: " + item.intIdArt + "\n" + "Mensaje: " + dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() + "\n\n";
                    }
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

        public void EditarArticuloReceta(ENArticulo objEnArt, List<ENDetReceta> lista, int idEmpresa, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                Edit_Elim_ArtReceta(objEnArt.intIdArt, objEnArt.intIdUsuMf, ref pBlnTodoOk);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArt", objEnArt.intIdArt);
                da.SelectCommand.Parameters.AddWithValue("@strCoArt", objEnArt.strCoArt);
                da.SelectCommand.Parameters.AddWithValue("@strNoArt", objEnArt.strNoArt);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnArt.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intFav", objEnArt.intFav);
                da.SelectCommand.Parameters.AddWithValue("@intKit", objEnArt.intKit);
                da.SelectCommand.Parameters.AddWithValue("@intReceta", objEnArt.intReceta);
                da.SelectCommand.Parameters.AddWithValue("@intComposicion", objEnArt.intComposicion);
                da.SelectCommand.Parameters.AddWithValue("@intIdSubFamilia", objEnArt.intIdSubFamilia);
                da.SelectCommand.Parameters.AddWithValue("@intIdUni", objEnArt.intIdUni);
                da.SelectCommand.Parameters.AddWithValue("@intIdUniComp", objEnArt.intIdUniComp);
                da.SelectCommand.Parameters.AddWithValue("@intIdClaArt", objEnArt.intIdClaArt);
                da.SelectCommand.Parameters.AddWithValue("@strCodAlt", objEnArt.strCodAlt);
                da.SelectCommand.Parameters.AddWithValue("@strTag", objEnArt.strTag);
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnArt.intIdUsuMf);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();

                if (mensaje != string.Empty)
                { cn.Close(); return; }

                mensaje = string.Empty;
                foreach (ENDetReceta item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DETARTICULO_RECETA_U01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdArtReceta", item.intIdArtReceta);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdReceta", objEnArt.intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdArt", item.intIdArt);
                    dad.SelectCommand.Parameters.AddWithValue("@decCant", item.decCant);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", item.intIdUsuMf);
                    dad.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    dad.SelectCommand.ExecuteNonQuery();
                    if (dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() != string.Empty)
                    {
                        mensaje += "IdArtículo: " + item.intIdArt + "\n" + "Mensaje: " + dad.SelectCommand.Parameters["@strMensaje"].Value.ToString() + "\n\n";
                    }
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

        public void Edit_Elim_ArtKit(int intIdArt, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DETARTKIT_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArt", intIdArt);
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

        public void Edit_Elim_ArtReceta(int intIdArt, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DETARTRECETA_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArt", intIdArt);
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

        public void EliminarArticulo(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ARTICULO_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArt", idSeleccion);
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

        public DataTable ListaGridArt(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_ALM_EMP_Q01", cn);
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

        public DataTable ListaArtAccAlm(int idAlmacen, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_ALM_Q01", cn);
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

        public DataTable ListaArtAccMaq(int idMaquina, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_MAQ_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdMaq", idMaquina);
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

        public DataTable ListarDetKit(int intIdArticulo, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            pBlnTodoOk = false;
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DETARTKIT_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArticulo", intIdArticulo);
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

        public DataTable ListarDetReceta(int intIdArticulo, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            pBlnTodoOk = false;
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DETARTRECETA_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArticulo", intIdArticulo);
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

        public DataTable ListaArtAccEmp(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_EMP_Q01", cn);
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

        public DataTable ListaGridArtTodos(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_EMP_TODOS_Q01", cn);
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
    }
}
