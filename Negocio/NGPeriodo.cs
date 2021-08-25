using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGPeriodo
    {
        private string _strConString = string.Empty;

        public NGPeriodo(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Periodo(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAPeriodo obj = new Datos.DAPeriodo(_strConString);
            tbl = obj.ListaPeriodo(ref blnTodoOK);
            return tbl;
        }

        public void InsertarPeriodo(ENPeriodo objEn, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAPeriodo obj = new Datos.DAPeriodo(_strConString);
            obj.InsertarPeriodo(objEn, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarPeriodo(ENPeriodo objEn, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAPeriodo obj = new Datos.DAPeriodo(_strConString);
            obj.EditarPeriodo(objEn, ref mensaje, ref blnTodoOK);

        }

        public void EliminarPeriodo(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAPeriodo obj = new Datos.DAPeriodo(_strConString);
            obj.EliminarPeriodo(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }

        public DataTable BuscarPeriodo(int intIdPeriodo, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAPeriodo obj = new Datos.DAPeriodo(_strConString);

            tbl = obj.BuscarPeriodo(intIdPeriodo, ref blnTodoOK);

            return tbl;
        }


    }
}
