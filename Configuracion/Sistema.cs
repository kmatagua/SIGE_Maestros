using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion
{
    public class Sistema
    {
        #region Constantes

        public const string ProviderName = "System.Data.SqlClient";
        public const string ArchivoCfgXml = "Configura.xml";
        public const string ArchivoDeContacto = "Drive.xml";
        public const string VersionApp = "V11102016.0900";

        #endregion

        private static string _Impresora;
        private static string _SistOperativoPDA;
        private static string _RutaFormatos;
        private static string _CadenaConexion;
        private static string _ServidorSQL;
        private static string _BaseDatosSQL;
        private static string _UsuarioSQL;
        private static string _PasswordSQL;
        private static string _TipoDeConexion;
        private static string _intIdActivo;
        private static string _GrillaColor;

        public static string Impresora
        {
            get { return _Impresora; }
            set { _Impresora = value; }
        }

        public static string SistOperativoPDA
        {
            get { return _SistOperativoPDA; }
            set { _SistOperativoPDA = value; }
        }

        public static string RutaFormatos
        {
            get { return _RutaFormatos; }
            set { _RutaFormatos = value; }
        }

        public static string CadenaConexion
        {
            get { return _CadenaConexion; }
            set { _CadenaConexion = value; }
        }

        public static string ServidorSQL
        {
            get { return _ServidorSQL; }
            set { _ServidorSQL = value; }
        }

        public static string BaseDatosSQL
        {
            get { return _BaseDatosSQL; }
            set { _BaseDatosSQL = value; }
        }

        public static string UsuarioSQL
        {
            get { return _UsuarioSQL; }
            set { _UsuarioSQL = value; }
        }

        public static string PasswordSQL
        {
            get { return _PasswordSQL; }
            set { _PasswordSQL = value; }
        }

        public static string TipoDeConexion
        {
            get { return _TipoDeConexion; }
            set { _TipoDeConexion = value; }
        }

        public static string intIdActivo
        {
            get { return _intIdActivo; }
            set { _intIdActivo = value; }
        }

        public static string GrillaColor
        {
            get { return _GrillaColor; }
            set { _GrillaColor = value; }
        }
    }
}
