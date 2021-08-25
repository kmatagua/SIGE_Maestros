using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENBancos
    {
        public int intIdBancos { get; set; }
        public string strCoBancos { get; set; }
        public string strNoBancos { get; set; }

        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        
    }
}
