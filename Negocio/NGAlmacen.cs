using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGAlmacen
    {
        private string _strConString = string.Empty;

        public NGAlmacen(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Almacen(int idEmpresa, int idUsuario, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            tbl = obj.ListaAlmacen(idEmpresa, idUsuario, ref blnTodoOK);
            return tbl;
        }

        public DataTable ComboAlmacen(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            tbl = obj.ListaComboAlmacen(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarAlmacen(string filtro, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            tbl = obj.ListaFiltrar(filtro, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public void InsertarOpeLogAlmacen(int idAlmacen, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.InsertarOpeLogAlmacen(idAlmacen, tabla, ref blnTodoOK);

        }

        public void InsertarUsuAlmacen(int idAlmacen, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.InsertarUsuAlmacen(idAlmacen, tabla, ref blnTodoOK);

        }

        public void InsertarMaqAlmacen(int idAlmacen, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.InsertarMaqAlmacen(idAlmacen, tabla, ref blnTodoOK);

        }

        public void InsertarArtAlmacen(int idAlmacen, int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.InsertarArtAlmacen(idAlmacen, idEmpresa, tabla, ref blnTodoOK);

        }

        public DataTable BuscarAlmacen(int intIdAlm, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);

            tbl = obj.BuscarAlmacen(intIdAlm, ref blnTodoOK);

            return tbl;
        }

        public DataTable BuscarConfigAlmacen(int intIdAlm, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);

            tbl = obj.BuscarConfigAlmacen(intIdAlm, ref blnTodoOK);

            return tbl;
        }

        public void InsertarAlmacen(ENAlmacen objEnAlm, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.InsertarAlmacen(objEnAlm, ref mensaje, ref blnTodoOK);

        }

        public void EditarAlmacen(ENAlmacen objEnAlm, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.EditarAlmacen(objEnAlm, ref blnTodoOK);

        }

        public void EliminarAlmacen(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
                obj.EliminarAlmacen(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable GridAlmacen(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            tbl = obj.ListaGridAlmacen(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable AlmacenAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            tbl = obj.ListaAlmacenAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public void Borrar(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.Borrar(idSeleccion, ref blnTodoOK);

        }

        //public void InsertarConfigAlmacen(ENConfig_Alm objEnAlm, ref bool blnTodoOK)
        //{
        //    Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
        //    obj.InsertarConfigAlmacen(objEnAlm, ref blnTodoOK);

        //}

        public void EditarConfigAlmacen(ENConfig_Alm objEnAlm, ref bool blnTodoOK)
        {
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            obj.EditarConfigAlmacen(objEnAlm, ref blnTodoOK);

        }

        public DataTable ConfigAlmacen(int idEmpresa, int idUsuario, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAAlmacen obj = new Datos.DAAlmacen(_strConString);
            tbl = obj.ListaConfigAlmacen(idEmpresa, idUsuario, ref blnTodoOK);
            return tbl;
        }
    }
}
