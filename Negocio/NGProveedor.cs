using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGProveedor
    {
        private string _strConString = string.Empty;

        public NGProveedor(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Proveedor(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAProveedor obj = new Datos.DAProveedor(_strConString);
            tbl = obj.ListaProveedor(ref blnTodoOK);
            return tbl;
        }

        public void InsertarProveedor(ENProveedor objEn, List<Entidad.ENDireccionProveedor> lista, int idProveedor, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAProveedor obj = new Datos.DAProveedor(_strConString);
            obj.InsertarProveedor(objEn, lista, idProveedor, ref mensaje, ref blnTodoOK);

        }

        public DataTable BuscarProveedor(int intIdProv, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAProveedor obj = new Datos.DAProveedor(_strConString);

            tbl = obj.BuscarProveedor(intIdProv, ref blnTodoOK);

            return tbl;
        }

        public void EditarProveedor(ENProveedor objEnEmp, List<Entidad.ENDireccionProveedor> lista, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAProveedor obj = new Datos.DAProveedor(_strConString);
            obj.EditarProveedor(objEnEmp, lista, ref mensaje, ref blnTodoOK);

        }

        public DataTable ListarDireccionProveedor(int idProveedor, ref bool pBlnTodoOk)
        {
            Datos.DAProveedor objDatos = new Datos.DAProveedor(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.ListarDireccionProveedor(idProveedor, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }
    }
}
