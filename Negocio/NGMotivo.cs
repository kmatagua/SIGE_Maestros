using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGMotivo
    {
        private string _strConString = string.Empty;

        public NGMotivo(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Motivo (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            tbl = obj.ListaMotivo(ref blnTodoOK);
            return tbl;
        }

        //public DataTable MotivoAcceso(int intIdMotivo, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
        //    tbl = obj.ListaUniAcc(intIdMotivo, ref blnTodoOK);
        //    return tbl;
        //}

        public DataTable FiltrarMotivo(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarMotivo(int intIdMotivo, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);

            tbl = obj.BuscarMotivo(intIdMotivo, ref blnTodoOK);

            return tbl;
        }

        public void InsertarMotivo(ENMotivo objEnMotivo, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            obj.InsertarMotivo(objEnMotivo, ref mensaje, ref blnTodoOK);

        }

        public void EditarMotivo(ENMotivo objEnMotivo, ref bool blnTodoOK)
        {
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            obj.EditarMotivo(objEnMotivo, ref blnTodoOK);

        }

        public void EliminarMotivo(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            obj.EliminarMotivo(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable MotivoEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            tbl = obj.ListaMotivoEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable GridMotivo(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            tbl = obj.ListaGridMotivo(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable MotivoAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMotivo obj = new Datos.DAMotivo(_strConString);
            tbl = obj.ListaMotivoAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
