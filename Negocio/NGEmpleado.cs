using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGEmpleado
    {
        private string _strConString = string.Empty;

        public NGEmpleado(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Empleado (int idEmpresa,ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            tbl = obj.ListaEmpleado(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarEmpleado(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarEmpleado(int intIdEmpleado, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);

            tbl = obj.BuscarEmpleado(intIdEmpleado, ref blnTodoOK);

            return tbl;
        }

        public void InsertarEmpleado(ENEmpleado objEnEmpleado, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            obj.InsertarEmpleado(objEnEmpleado, ref mensaje, ref blnTodoOK);

        }

        public void EditarEmpleado(ENEmpleado objEnEmp, ref bool blnTodoOK)
        {
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            obj.EditarEmpleado(objEnEmp, ref blnTodoOK);

        }

        public void EliminarEmpleado(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            obj.EliminarEmpleado(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable GridEmpleado(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            tbl = obj.ListaGridEmpleado(ref blnTodoOK);
            return tbl;
        }

        public DataTable EmpleadoAccesoEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            tbl = obj.ListaEmpleadoAccEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable EmpleadoAccesoClaEmp(int idClaEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            tbl = obj.ListaEmpleadoAccClaEmp(idClaEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable ListarVendedor(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpleado obj = new Datos.DAEmpleado(_strConString);
            tbl = obj.ListarVendedor(idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
