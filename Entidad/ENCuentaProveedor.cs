using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENCuentaProveedor
    {
        public int intIdCuentas { get; set; }
        public int intIdBanco { get; set; }
        public int intIdMoneda { get; set; }
        public int intIdProveedor { get; set; }
        public string strNroCuenta { get; set; }
        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
    }
}
