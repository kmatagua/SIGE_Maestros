using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGSede
    {
        private string _strConString = string.Empty;

        public NGSede(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Sede(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASede obj = new Datos.DASede(_strConString);
            tbl = obj.ListaSede(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarSede(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASede obj = new Datos.DASede(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarSede(int intIdSede, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DASede obj = new Datos.DASede(_strConString);

            tbl = obj.BuscarSede(intIdSede, ref blnTodoOK);

            return tbl;
        }

        public void InsertarSede(ENSede objEnSede, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DASede obj = new Datos.DASede(_strConString);
            obj.InsertarSede(objEnSede, ref mensaje, ref blnTodoOK);

        }

        public void EditarSede(ENSede objEnSede, ref bool blnTodoOK)
        {
            Datos.DASede obj = new Datos.DASede(_strConString);
            obj.EditarSede(objEnSede, ref blnTodoOK);

        }

        public void EliminarSede(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DASede obj = new Datos.DASede(_strConString);
            obj.EliminarSede(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }
    }
}
