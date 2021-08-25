using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGOpeLog
    {
        private string _strConString = string.Empty;

        public NGOpeLog(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable OpeLog (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaOpeLog(ref blnTodoOK);
            return tbl;
        }

        public DataTable GridOpeLog(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaGridOpeLog(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable OpeLogAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaOpeLogAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable OpeLogAccesoAlm(int idAlmacen, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaOpeLogAccAlm(idAlmacen, ref blnTodoOK);
            return tbl;
        }

        public DataTable OpeLogAccesoUsu(int idUsuario, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaOpeLogAccUsu(idUsuario, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarOpeLog(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarOpeLog(int intIdOpeLog, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);

            tbl = obj.BuscarOpeLog(intIdOpeLog, ref blnTodoOK);

            return tbl;
        }

        public void InsertarOpeLog(ENOpeLog objEnUni, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            obj.InsertarOpeLog(objEnUni, ref mensaje, ref blnTodoOK);

        }

        public void InsertarOpeLog2(ENOpeLog objEnUni, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            obj.InsertarOpeLog2(objEnUni, ref mensaje, ref blnTodoOK);

        }

        public void EditarOpeLog(ENOpeLog objEnUni, ref bool blnTodoOK)
        {
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            obj.EditarOpeLog(objEnUni, ref blnTodoOK);

        }

        public void EditarOpeLog2(ENOpeLog objEnUni, ref bool blnTodoOK)
        {
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            obj.EditarOpeLog2(objEnUni, ref blnTodoOK);

        }

        public void EliminarOpeLog(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            obj.EliminarOpeLog(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable OpeLogCombo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOpeLog obj = new Datos.DAOpeLog(_strConString);
            tbl = obj.ListaOpeLog(ref blnTodoOK);
            return tbl;
        }
    }
}
