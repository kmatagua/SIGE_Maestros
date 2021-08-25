using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGCliente
    {
        private string _strConString = string.Empty;

        public NGCliente(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Cliente (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            tbl = obj.ListaCliente(ref blnTodoOK);
            return tbl;
        }

        public DataTable ClienteAprobar(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            tbl = obj.ListaClienteAprobar(ref blnTodoOK);
            return tbl;
        }

        public DataTable ClienteTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            tbl = obj.ListaClienteTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable ClienteAcceso(int intIdCliente, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            tbl = obj.ListaClienteAcc(intIdCliente, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarCliente(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarCliente(int intIdCliente, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DACliente obj = new Datos.DACliente(_strConString);

            tbl = obj.BuscarCliente(intIdCliente, ref blnTodoOK);

            return tbl;
        }

        public void InsertarCliente(ENCliente objEnCliente, List<Entidad.ENDireccionCliente> lista, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            obj.InsertarCliente(objEnCliente, lista, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarCliente(ENCliente objEnCliente, List<Entidad.ENDireccionCliente> lista, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            obj.EditarCliente(objEnCliente, lista, ref mensaje, ref blnTodoOK);

        }

        public void EliminarCliente(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DACliente obj = new Datos.DACliente(_strConString);
            obj.EliminarCliente(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable ListarDireccion(int idCliente, ref bool pBlnTodoOk)
        {
            Datos.DACliente objDatos = new Datos.DACliente(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.ListarDireccion(idCliente, ref pBlnTodoOk);
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
