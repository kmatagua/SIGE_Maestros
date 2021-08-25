using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENOpeLog
    {
        public int intIdOpeLog { get; set; }
        public string strCoOpeLog { get; set; }
        public string strNoOpeLog { get; set; }
        public int intIdTipo { get; set; }
        public int intTransAut { get; set; }
        public int intIdTransOpe { get; set; }
        public int intTransformar { get; set; }
        public int intCompra { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        public int intElim { get; set; }

    }
}
