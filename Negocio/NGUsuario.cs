using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;
using Datos;

namespace Negocio
{
    public class NGUsuario
    {
        private string _strConString = string.Empty;

        public NGUsuario(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public void Usuario_V01(ENUsuario objENUsu, ref int p_intIdUsu, ref string p_strMensaje, ref bool pBlnTodoOk)
        {
            DAUsuario objDatos = new DAUsuario(_strConString);
            try
            {
                objDatos.Usuario_V01(objENUsu, ref p_intIdUsu, ref p_strMensaje, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                Configuracion.Libreria.Error_Grabar(ex);
            }
        }

        public DataTable Usuario(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            tbl = obj.ListaUsuario(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable ComboUsuario(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            tbl = obj.ComboUsuario(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarUsuario(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarUsuario(int intIdUsu, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);

            tbl = obj.BuscarUsuario(intIdUsu, ref blnTodoOK);

            return tbl;
        }

        public void InsertarUsuario(ENUsuario objEnUsu, DataTable tabla, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarUsuario(objEnUsu, tabla, ref mensaje,ref blnTodoOK);

        }

        public void EditarUsuario(ENUsuario objEnUsu,DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.EditarUsuario(objEnUsu, tabla, ref blnTodoOK);

        }

        public void EditarContrasena(ENUsuario objEnUsu, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.EditarContrasena(objEnUsu, ref blnTodoOK);

        }

        public void EliminarUsuario(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.EliminarUsuario(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable GridUsu(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            tbl = obj.ListaGridUsu(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UsuAccesoAlm(int idAlmacen, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            tbl = obj.ListaUsuAccAlm(idAlmacen, ref blnTodoOK);
            return tbl;
        }

        public void InsertarMenuUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarMenuUsuario(idUsuario, tabla, idEmpresa, ref blnTodoOK);

        }

        public void InsertarOpeLogUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarOpeLogUsuario(idUsuario, tabla, idEmpresa, ref blnTodoOK);

        }

        public void InsertarUniNegUsuario(int idUsuario, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarUniNegUsuario(idUsuario, tabla, ref blnTodoOK);

        }

        public void InsertarAlmacenUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarAlmacenUsuario(idUsuario, tabla, idEmpresa, ref blnTodoOK);

        }

        public void InsertarNumeradorUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarNumeradorUsuario(idUsuario, tabla, idEmpresa, ref blnTodoOK);

        }

        public void InsertarNumeradorUsuarioOrdenes(int idUsuario, DataTable tabla, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarNumeradorUsuarioOrdenes(idUsuario, tabla, idEmpresa, ref blnTodoOK);

        }

        public void BorrarUniNeg(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarUniNeg(idSeleccion, ref blnTodoOK);

        }

        public void BorrarNumerador(int idSeleccion, int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarNumerador(idSeleccion, idUsuario, idEmpresa, ref blnTodoOK);

        }

        public void BorrarNumeradorOrdenes(int idSeleccion, int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarNumeradorOrdenes(idSeleccion, idUsuario, idEmpresa, ref blnTodoOK);

        }

        public void InsertarAreaUsuario(int idUsuario, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarAreaUsuario(idUsuario, tabla, ref blnTodoOK);

        }

        public void BorrarArea(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarArea(idSeleccion, ref blnTodoOK);

        }

        public void InsertarUniGesUsuario(int idUsuario, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarUniGesUsuario(idUsuario, tabla, ref blnTodoOK);

        }

        public void InsertarMotivoUsuario(int idUsuario, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarMotivoUsuario(idUsuario, tabla, ref blnTodoOK);

        }

        public void BorrarMotivo(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarMotivo(idSeleccion, ref blnTodoOK);

        }

        public void BorrarCenCos(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarCenCos(idSeleccion, ref blnTodoOK);

        }

        public void InsertarCenCosUsuario(int idUsuario, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.InsertarCenCosUsuario(idUsuario, tabla, ref blnTodoOK);

        }

        public void BorrarUniGes(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAUsuario obj = new Datos.DAUsuario(_strConString);
            obj.BorrarUniGes(idSeleccion, ref blnTodoOK);

        }
    }
}
