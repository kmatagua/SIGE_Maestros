using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGCuentaProveedor
    {
        private string _strConString = string.Empty;

        public NGCuentaProveedor(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable CuentaProveedor(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            tbl = obj.ListaCuentaProveedor(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable ComboCuentaProveedor(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            tbl = obj.ListaComboCuentaProveedor(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable CuentaProveedorAcceso(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            tbl = obj.ListaEmpAcc(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarCuentaProveedor(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarCuentaProveedor(int intIdCuenta, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);

            tbl = obj.BuscarCuentaProveedor(intIdCuenta, ref blnTodoOK);

            return tbl;
        }

        public void InsertarCuentaProveedor(ENCuentaProveedor objEnEmp, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarCuentaProveedor(objEnEmp, ref mensaje, ref blnTodoOK);

        }

        public void InsertarUniCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarUniCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void InsertarFamiliaCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarFamiliaCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void InsertarMarcaCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarMarcaCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void InsertarOpeLogCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarOpeLogCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void InsertarUniNegCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarUniNegCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void InsertarTipoDocCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarTipoDocCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void InsertarEmpleadoCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.InsertarEmpleadoCuentaProveedor(idCuentaProveedor, tabla, ref blnTodoOK);

        }

        public void EditarCuentaProveedor(ENCuentaProveedor objEN, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.EditarCuentaProveedor(objEN, ref mensaje, ref blnTodoOK);

        }

        public void EliminarCuentaProveedor(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            obj.EliminarCuentaProveedor(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }

        public DataTable CuentaProveedorActiva(int idUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            
            tbl = obj.CuentaProveedorActiva(idUsu, ref blnTodoOK);

            return tbl;
        }

        public DataTable ComboCuentaProveedor(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACuentaProveedor obj = new Datos.DACuentaProveedor(_strConString);
            tbl = obj.ComboCuentaProveedor(ref blnTodoOK);
            return tbl;
        }
    }
}
