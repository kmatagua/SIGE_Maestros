using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENDireccionProveedor
    {
        public int intIdDireccionProveedor { get; set; }
        public int intIdProveedor { get; set; }
        public int intIdCalle { get; set; }
        public string strNoCalle { get; set; }
        public string strNro { get; set; }
        public string strPabellon { get; set; }
        public string strMz { get; set; }
        public string strLote { get; set; }
        public int intIdTipoDep { get; set; }
        public string strNoTipoDep { get; set; }
        public int intIdUrbanismo { get; set; }
        public string strNoUrb { get; set; }
        public int intIdSector { get; set; }
        public string strNoSector { get; set; }
        public int intIdUbigeo { get; set; }
        public string strDireccion { get; set; }
        public int intDefault { get; set; }
        public int intEstado { get; set; }
        public int intElim { get; set; }

        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
    }
}
