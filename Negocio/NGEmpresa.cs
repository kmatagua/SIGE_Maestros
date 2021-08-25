using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGEmpresa
    {
        private string _strConString = string.Empty;

        public NGEmpresa(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Empresa(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            tbl = obj.ListaEmpresa(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable ComboEmpresa(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            tbl = obj.ListaComboEmpresa(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable EmpresaAcceso(int intIdUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            tbl = obj.ListaEmpAcc(intIdUsu, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarEmpresa(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarEmpresa(int intIdEmpr, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);

            tbl = obj.BuscarEmpresa(intIdEmpr, ref blnTodoOK);

            return tbl;
        }

        public void InsertarEmpresa(ENEmpresa objEnEmp, List<Entidad.ENDireccionEmpresa> lista, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarEmpresa(objEnEmp, lista, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void InsertarUniEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarUniEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarFamiliaEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarFamiliaEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarMarcaEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarMarcaEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarOpeLogEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarOpeLogEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarUniNegEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarUniNegEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarTipoDocEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarTipoDocEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarEmpleadoEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarEmpleadoEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarClienteEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarClienteEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void EditarEmpresa(ENEmpresa objEnEmp, List<Entidad.ENDireccionEmpresa> lista, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.EditarEmpresa(objEnEmp, lista, ref mensaje, ref blnTodoOK);

        }

        public void EliminarEmpresa(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.EliminarEmpresa(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }

        public DataTable EmpresaActiva(int idUsu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            
            tbl = obj.EmpresaActiva(idUsu, ref blnTodoOK);

            return tbl;
        }

        public DataTable ComboEmpresa(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            tbl = obj.ComboEmpresa(ref blnTodoOK);
            return tbl;
        }

        public DataTable ListarDireccion(int idEmpresa, ref bool pBlnTodoOk)
        {
            Datos.DAEmpresa objDatos = new Datos.DAEmpresa(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.ListarDireccion(idEmpresa, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public void InsertarArtEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarArtEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void Borrar(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.Borrar(idSeleccion, ref blnTodoOK);

        }

        public void BorrarUniNeg(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.BorrarUniNeg(idSeleccion, ref blnTodoOK);

        }

        public void BorrarUniGes(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.BorrarUniGes(idSeleccion, ref blnTodoOK);

        }

        public void InsertarUniGesEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarUniGesEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void InsertarMotivosEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarMotivosEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void BorrarMotivo(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.BorrarMotivo(idSeleccion, ref blnTodoOK);

        }

        public void InsertarCenCosEmpresa(int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarCenCosEmpresa(idEmpresa, tabla, ref blnTodoOK);

        }

        public void BorrarCenCos(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.BorrarCenCos(idSeleccion, ref blnTodoOK);

        }
    }
}
