using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configuracion
{
    public class Libreria
    {
        public static string ObtenerRutaApp()
        {
            string strPath;
            strPath = Application.StartupPath;
            if ((!strPath.EndsWith(@"\"))) strPath += @"\";
            return strPath;
        }

        public static void Error_Grabar(Exception pexpError)
        {
            try
            {
                string strDirectorio; string strNombreArchivo;
                strDirectorio = System.IO.Directory.GetCurrentDirectory();
                if (strDirectorio.EndsWith("\\") == false)
                {
                    strDirectorio = (strDirectorio + "\\");
                }
                strNombreArchivo = (ObtenerRutaApp() + "Error\\" + DateTime.Today.ToString("Error Ex dd-MM-yyyy") + ".txt");
                string str = string.Empty;
                System.IO.StreamWriter objWriter; System.IO.FileStream objFile; System.IO.DirectoryInfo objDirectorio;
                //
                objDirectorio = new System.IO.DirectoryInfo(ObtenerRutaApp() + "Error\\");

                if (objDirectorio.Exists == false)
                {
                    objDirectorio.Create();
                }
                objFile = new System.IO.FileStream(strNombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                objWriter = new System.IO.StreamWriter(objFile);
                objWriter.BaseStream.Seek(0, System.IO.SeekOrigin.End);
                objWriter.WriteLine("[________________________________________________________________________]");
                objWriter.WriteLine("[Fecha         ][" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]");
                objWriter.WriteLine("[Source        ][" + pexpError.Source + "]");
                objWriter.WriteLine("[Mensaje       ][" + pexpError.Message + "]");
                objWriter.WriteLine("[StackTrace    ][" + pexpError.StackTrace + "]");
                objWriter.WriteLine("[InnerException][" + Convert.ToString(pexpError.InnerException) + "]");
                objWriter.WriteLine("");
                objWriter.WriteLine("");
                objWriter.WriteLine();
                objWriter.Flush();
                objWriter.Close();
                objFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Probar_Conexion(string pServidor, string pBaseDatos, string pUsuario, string pContraseña, string pTituloMensaje, Int32 pFocus, bool pAutenticacion, ref Int32 pDevFocus)
        {
            bool bConectado = false;
            try
            {
                if (pServidor.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese el nombre del Servidor Sql Server", pTituloMensaje);
                    pDevFocus = 1; return bConectado;
                }
                if (pBaseDatos.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese el nombre de la Base de Datos", pTituloMensaje);
                    pDevFocus = 2; return bConectado;
                }

                if (pAutenticacion)
                {
                    if (pUsuario.Trim() == string.Empty)
                    {
                        MessageBox.Show("Ingrese el nombre del Usuario de Inicio de sesión", pTituloMensaje);
                        pDevFocus = 3; return bConectado;
                    }
                    if (pContraseña.Trim() == string.Empty)
                    {
                        MessageBox.Show("Ingrese la Contraseña de Inicio de sesión", pTituloMensaje);
                        pDevFocus = 4; return bConectado;
                    }
                }

                bool blnTodoOk = false; string strError = null;
                bConectado = Configuracion.Libreria.BaseDato_ConexionCorrecta(pServidor, pBaseDatos, pAutenticacion, pUsuario, pContraseña, ref blnTodoOk, ref strError);
                if (blnTodoOk == false)
                {
                    if (pFocus == 1)
                    {
                        MessageBox.Show("No se pudo conectar a la Base de Datos. " + strError, pTituloMensaje);
                        //MessageBox.Show("No se pudo conectar a la Base de Datos." + ControlChars.CrLf + strError, pTituloMensaje);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Configuracion.Libreria.Error_Grabar(ex);
                MessageBox.Show("Ocurrio un error al conectarse a la Base de Datos", pTituloMensaje);
            }
            return bConectado;
        }

        public static string RetornarCadenaConexion(string pServidor, string pBaseDatos, string pUsuario, string pClave)
        {
            string strCnn = string.Empty;
            strCnn = "Data Source=" + pServidor.Trim() + "; Initial Catalog=" + pBaseDatos.Trim() + "; User ID=" + pUsuario.Trim() + "; Password=" + pClave.Trim() + ";";
            return strCnn;
        }

        public static bool BaseDato_ConexionCorrecta(string pStrServidor, string pStrBaseDatos, bool pBlnSeguridaStandar, string pStrUsuario, string pStrClave, ref bool pBlnTodoOk, ref string pStrError)
        {
            pBlnTodoOk = false; pStrError = null;
            bool bDev = false; string strConnectionString = string.Empty; StringBuilder sbl;
            SqlServer lObjDataBase = new SqlServer();
            //
            try
            {
                sbl = new StringBuilder();
                if (pBlnSeguridaStandar == true)
                {
                    sbl.Append("Data Source = " + pStrServidor.Trim() + "; ");
                    sbl.Append("Initial Catalog = " + pStrBaseDatos.Trim() + "; ");
                    sbl.Append("User ID = " + pStrUsuario.Trim() + "; ");
                    sbl.Append("Password = " + pStrClave.Trim() + ";");
                }
                else
                {
                    sbl.Append("Data Source = " + pStrServidor.Trim() + "; ");
                    sbl.Append("Initial Catalog = " + pStrBaseDatos.Trim() + "; ");
                    sbl.Append("Integrated Security = SSPI");
                }
                strConnectionString = sbl.ToString();
                sbl = null;
                bDev = lObjDataBase.ConexionCorrecta(strConnectionString);
                pBlnTodoOk = true;
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                Error_Grabar(Ex);
            }
            catch (Exception ex)
            {
                Error_Grabar(ex);
            }
            return bDev;
        }

    }
}
