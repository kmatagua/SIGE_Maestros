using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENTipoCambio
    {
        public int intIdTipoCambio { get; set; }
        public decimal decPrecioCompra { get; set; }
        public decimal decPrecioVenta { get; set; }
        public DateTime dttFeTipoCambio { get; set; }
        public int intIdMoneda { get; set; }
        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
       
    }
}
