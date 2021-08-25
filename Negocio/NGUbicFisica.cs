using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGUbicFisica
    {
        private string _strConString = string.Empty;

        public NGUbicFisica(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable UbicFisica (int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);
            tbl = obj.ListaUbicFisica(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        //public DataTable UbicFisicaAcceso(int intIdUbicFisica, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);
        //    tbl = obj.ListaUniAcc(intIdUbicFisica, ref blnTodoOK);
        //    return tbl;
        //}

        public DataTable FiltrarUbicFisica(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarUbicFisica(int intIdUbic, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);

            tbl = obj.BuscarUbicFisica(intIdUbic, ref blnTodoOK);

            return tbl;
        }

        public void InsertarUbicFisica(ENUbicFisica objEnUbic, int intIdEmp, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);
            obj.InsertarUbicFisica(objEnUbic, intIdEmp, ref mensaje, ref blnTodoOK);

        }

        public void EditarUbicFisica(ENUbicFisica objEnUbic, int intIdEmp, ref bool blnTodoOK)
        {
            Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);
            obj.EditarUbicFisica(objEnUbic, intIdEmp, ref blnTodoOK);

        }

        public void EliminarUbicFisica(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAUbicFisica obj = new Datos.DAUbicFisica(_strConString);
            obj.EliminarUbicFisica(idSeleccion, idUsuario, ref blnTodoOK);

        }
    }
}
