using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGCentroCosto
    {
        private string _strConString = string.Empty;

        public NGCentroCosto(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable CentroCosto (int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            tbl = obj.ListaCentroCosto(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable CenCosEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            tbl = obj.ListaCenCosEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }
        
        public DataTable CenCosTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            //tbl = obj.ListaUndNegocioTodo(ref blnTodoOK);
            tbl = obj.CenCosTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarCentroCosto(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarCentroCosto(int intIdCentroCosto, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);

            tbl = obj.BuscarCentroCosto(intIdCentroCosto, ref blnTodoOK);

            return tbl;
        }

        public void InsertarCentroCosto(ENCentroCosto objEnCentroCosto, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            obj.InsertarCentroCosto(objEnCentroCosto, ref mensaje, ref blnTodoOK);

        }

        public void EditarCentroCosto(ENCentroCosto objEnUni, ref bool blnTodoOK)
        {
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            obj.EditarCentroCosto(objEnUni, ref blnTodoOK);

        }

        public void EliminarCentroCosto(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            obj.EliminarCentroCosto(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable GridCenCos(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            tbl = obj.ListaGridCenCos(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable CenCosAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACentroCosto obj = new Datos.DACentroCosto(_strConString);
            tbl = obj.ListaCenCosAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
