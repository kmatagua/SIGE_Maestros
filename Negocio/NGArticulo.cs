using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGArticulo
    {
        private string _strConString = string.Empty;

        public NGArticulo(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Articulo(int idEmpresa, int idUsuario, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaArticulo(idEmpresa, idUsuario, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarArticulo(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarArticulo(int intIdArticulo, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);

            tbl = obj.BuscarArticulo(intIdArticulo, ref blnTodoOK);

            return tbl;
        }

        public void InsertarArticuloFamilia(int idFamilia, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarUniEmpresa(idFamilia, tabla, ref blnTodoOK);

        }

        //public DataTable ArticuloAcceso(int idFamilia, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
        //    tbl = obj.ListaArticuloAcc(idFamilia, ref blnTodoOK);
        //    return tbl;
        //}

        public void InsertarArticulo(ENArticulo objEnArticulo, List<Entidad.ENDetKit> lista, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            obj.InsertarArticulo(objEnArticulo, lista, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void InsertarArticuloReceta(ENArticulo objEnArticulo, List<Entidad.ENDetReceta> lista, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            obj.InsertarArticuloReceta(objEnArticulo, lista, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarArticulo(ENArticulo objEnArticulo, List<Entidad.ENDetKit> lista, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            obj.EditarArticulo(objEnArticulo, lista, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarArticuloReceta(ENArticulo objEnArticulo, List<Entidad.ENDetReceta> lista, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            obj.EditarArticuloReceta(objEnArticulo, lista, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EliminarArticulo(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            obj.EliminarArticulo(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable GridArt(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaGridArt(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable ArtAccesoAlm(int idAlmacen, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaArtAccAlm(idAlmacen, ref blnTodoOK);
            return tbl;
        }

        public DataTable ArtAccesoMaq(int idMaquina, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaArtAccMaq(idMaquina, ref blnTodoOK);
            return tbl;
        }

        public DataTable ListarDetKit(int intIdArticulo, ref bool pBlnTodoOk)
        {
            Datos.DAArticulo objDatos = new Datos.DAArticulo(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.ListarDetKit(intIdArticulo, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public DataTable ListarDetReceta(int intIdArticulo, ref bool pBlnTodoOk)
        {
            Datos.DAArticulo objDatos = new Datos.DAArticulo(_strConString);
            System.Data.DataTable objRetVal = new System.Data.DataTable();
            pBlnTodoOk = false;
            try
            {
                objRetVal = objDatos.ListarDetReceta(intIdArticulo, ref pBlnTodoOk);
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
                Configuracion.Libreria.Error_Grabar(ex);
            }
            return objRetVal;
        }

        public DataTable ArtAccesoEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaArtAccEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable GridArtTodos(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArticulo obj = new Datos.DAArticulo(_strConString);
            tbl = obj.ListaGridArtTodos(ref blnTodoOK);
            return tbl;
        }
    }
}
