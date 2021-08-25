using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGUndNegocio
    {
        private string _strConString = string.Empty;

        public NGUndNegocio(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable UndNegocio (int idUsuario,int idEmpresa,ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUndNegocio(idUsuario,idEmpresa,ref blnTodoOK);
            return tbl;
        }

        public DataTable UndNegocioEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUndNegocioEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UndNegocioTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUndNegocioTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable GridUniNeg(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaGridUniNeg(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UniNegAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUniNegAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UniNegAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUniNegAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarUndNegocio(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarUndNegocio(int intIdUndNegocio, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);

            tbl = obj.BuscarUndNegocio(intIdUndNegocio, ref blnTodoOK);

            return tbl;
        }

        public void InsertarUndNegocio(ENUndNegocio objEnUndNegocio, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            obj.InsertarUndNegocio(objEnUndNegocio, ref mensaje, ref blnTodoOK);

        }

        public void EditarUndNegocio(ENUndNegocio objEnUni, ref bool blnTodoOK)
        {
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            obj.EditarUndNegocio(objEnUni, ref blnTodoOK);

        }

        public void EliminarUndNegocio(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            obj.EliminarUndNegocio(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public void InsertarMaqUniNeg(int idUniNeg, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            obj.InsertarMaqUniNeg(idUniNeg, tabla, ref blnTodoOK);

        }

        public DataTable UndNegocioSede(int idSede, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUndNegocioSede(idSede, ref blnTodoOK);
            return tbl;
        }

        public void InsertarUniNegSede(int idSede, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            obj.InsertarUniNegSede(idSede, tabla, ref blnTodoOK);

        }

        public void BorrarUniNegSede(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            obj.BorrarUniNegSede(idSeleccion, ref blnTodoOK);

        }
    }
}
