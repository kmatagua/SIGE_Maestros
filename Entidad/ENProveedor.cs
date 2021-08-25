using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENProveedor
    {
        public int intIdProv { get; set; }
        public DateTime dttFeIng { get; set; }
        public string strRazSoc { get; set; }
        public string strApePat { get; set; }
        public string strApeMat { get; set; }
        public string strNomb { get; set; }
        public string strNombProv { get; set; }
        public string strRUC { get; set; }
        public string strDir { get; set; }
        public string strDNI { get; set; }
        public string strContacto { get; set; }
        public string strTel { get; set; }
        public string strCorreo { get; set; }
        public int intIdTipPer { get; set; }
        public int intFlPes { get; set; }

        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
    }
}
