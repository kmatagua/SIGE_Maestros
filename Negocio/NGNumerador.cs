using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGNumerador
    {
        private string _strConString = string.Empty;

        public NGNumerador(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Numerador(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaNumerador(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable NumeradorOrdenes(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaNumeradorOrdenes(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable NumeradorRequerimiento(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaNumeradorRequerimiento(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable NumeradorAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaNumeradorAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable NumeradorAccesoUsuSeriesOrdenes(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaNumeradorAccSeriesOrdenes(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable NumAccesoUsuAprReq(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaNumAccesoUsuAprReq(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable ComboNumerador(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaComboNumerador(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable NumeradorAcceso(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaEmpAcc(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarNumerador(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarNumerador(int intIdNum, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);

            tbl = obj.BuscarNumerador(intIdNum, ref blnTodoOK);

            return tbl;
        }

        public void InsertarNumerador(ENNumerador objEnEmp, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarNumerador(objEnEmp, ref mensaje, ref blnTodoOK);

        }

        public void InsertarUniNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarUniNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void InsertarFamiliaNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarFamiliaNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void InsertarMarcaNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarMarcaNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void InsertarOpeLogNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarOpeLogNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void InsertarUniNegNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarUniNegNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void InsertarTipoDocNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarTipoDocNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void InsertarEmpleadoNumerador(int idNumerador, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.InsertarEmpleadoNumerador(idNumerador, tabla, ref blnTodoOK);

        }

        public void EditarNumerador(ENNumerador objEN, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.EditarNumerador(objEN, ref mensaje, ref blnTodoOK);

        }

        public void EliminarNumerador(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            obj.EliminarNumerador(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }

        public DataTable NumeradorActiva(int idUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            
            tbl = obj.NumeradorActiva(idUsu, ref blnTodoOK);

            return tbl;
        }

        public DataTable ComboNumerador(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DANumerador obj = new Datos.DANumerador(_strConString);
            tbl = obj.ComboNumerador(ref blnTodoOK);
            return tbl;
        }
    }
}
