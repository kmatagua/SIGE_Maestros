using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGUndGestion
    {
        private string _strConString = string.Empty;

        public NGUndGestion(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable UndGestion(int idUsuario, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            tbl = obj.ListaUndGestion(idUsuario,ref blnTodoOK);
            return tbl;
        }

        public DataTable GridUniGes(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            tbl = obj.ListaGridUniGes(idEmpresa, ref blnTodoOK);
            return tbl;
        }
        
        public DataTable UndGestionTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            tbl = obj.ListaUndGestionTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable UniGesAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            tbl = obj.ListaUniGesAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UniGesAccesoUsuAprReq(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            tbl = obj.ListaUniGesAccUsuAprReq(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        //public DataTable UniNegAcceso(int intIdEmp, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
        //    tbl = obj.ListaUniNegAcc(intIdEmp, ref blnTodoOK);
        //    return tbl;
        //}

        //public DataTable FiltrarUndNegocio(string filtro, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
        //    tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
        //    return tbl;
        //}

        public DataTable BuscarUndGestion(int intIdUndGestion, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);

            tbl = obj.BuscarUndGestion(intIdUndGestion, ref blnTodoOK);

            return tbl;
        }

        public void InsertarUndGestion(ENUndGestion objEnUnd, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            obj.InsertarUndGestion(objEnUnd, ref mensaje, ref blnTodoOK);

        }

        public void EditarUndGestion(ENUndGestion objEnUni, ref bool blnTodoOK)
        {
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            obj.EditarUndGestion(objEnUni, ref blnTodoOK);

        }

        public void EliminarUndGestion(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            obj.EliminarUndGestion(idSeleccion, idUsuario, ref blnTodoOK);

        }

        //public void InsertarMaqUniNeg(int idUniNeg, DataTable tabla, ref bool blnTodoOK)
        //{
        //    Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
        //    obj.InsertarMaqUniNeg(idUniNeg, tabla, ref blnTodoOK);

        //}

        public DataTable UndGestionEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndGestion obj = new Datos.DAUndGestion(_strConString);
            tbl = obj.ListaUndGestionEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
