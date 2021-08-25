using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    public class NGComun : IDisposable
    {
         private string _strConString = string.Empty;

        public NGComun(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Listar_Combo(string p_maestro, int p_id, ref bool pBlnTodoOk)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.Listar_Combo(p_maestro, p_id, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public DataTable Listar_Combo2(string p_maestro, int p_id, int p_intIdEmp, int p_intIdUsu, int p_intIdAlm, int intIdSede, ref bool pBlnTodoOk)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.Listar_Combo2(p_maestro, p_id, p_intIdEmp, p_intIdUsu, p_intIdAlm, intIdSede, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public DataTable ListaFiltrar(string maestro, string filtro, int intId, int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
         {
             DataTable tbl = new DataTable();
             Datos.DAComun obj = new Datos.DAComun(_strConString);
             tbl = obj.ListaFiltrar(maestro, filtro, intId, idUsuario, idEmpresa, ref pBlnTodoOk);
             return tbl;
         }

        public void Usuario_validar(string p_strNoUsuar, string p_strPwUsuar, ref int p_intIdUsuar, ref string p_strMensaje, ref bool pBlnTodoOk)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            try
            {
                objDatos.Usuario_validar(p_strNoUsuar, p_strPwUsuar, ref p_intIdUsuar, ref p_strMensaje, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                Configuracion.Libreria.Error_Grabar(ex);
            }
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) { }
            _disposed = true;
        }

        public DataTable Botones(int idUsuario, string tagMenu, int idEmpresa, ref bool pBlnTodoOk)
        {
            DataTable tbl = new DataTable();
            Datos.DAComun obj = new Datos.DAComun(_strConString);
            tbl = obj.Botones(idUsuario, tagMenu, idEmpresa, ref pBlnTodoOk);
            return tbl;
        }

        public void ListaUbigeo(int idUbigeo, ref string nombreDepartamento, ref string nombreProvincia, ref bool blnTodoOK)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            try
            {
                objDatos.ListaUbigeo(idUbigeo, ref nombreDepartamento, ref nombreProvincia, ref blnTodoOK);
            }
            catch (Exception ex)
            {
                Configuracion.Libreria.Error_Grabar(ex);
            }
        }

        public DataTable ListarSerieDefault(int idTipoDoc, int idEmpresa, int idUsuario, ref bool pBlnTodoOk)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.ListarSerieDefault(idTipoDoc, idEmpresa, idUsuario, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public void EditarSerieDefault(List<Entidad.ENSerieDefault> lista, ref string mensaje, ref bool pBlnTodoOk)
        {
            Datos.DAComun obj = new Datos.DAComun(_strConString);
            obj.EditarSerieDefault(lista, ref mensaje, ref pBlnTodoOk);
        }

        public DataTable ComboNumeroApr(int p_id, ref bool pBlnTodoOk)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.comboNumeroApr(p_id, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }
        
        public DataTable ComboTipoReq(int p_id, ref bool pBlnTodoOk)
        {
            Datos.DAComun objDatos = new Datos.DAComun(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.comboTipoReq(p_id, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public void InsertarNumeroAprobacion(int idUsuario, DataTable tabla, int idEmpresa, ref bool blnTodoOK)
        {
            Datos.DAComun obj = new Datos.DAComun(_strConString);
            obj.InsertarNumeroAprobacion(idUsuario, tabla, idEmpresa, ref blnTodoOK);

        }
    }
}
