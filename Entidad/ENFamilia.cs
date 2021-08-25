using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENFamilia
    {
        public int intIdFamilia { get; set; }
        public string strCoFamilia { get; set; }
        public string strNoFamilia { get; set; }
        public int intIdClaArt { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        public int intElim { get; set; }

    }
}
