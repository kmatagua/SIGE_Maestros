using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENArticulo
    {
        public int intIdArt { get; set; }
        public string strCoArt { get; set; }
        public string strNoArt { get; set; }
        public string strDisplay { get; set; }
        public int intEstado { get; set; }
        public int intFav { get; set; }
        public int intKit { get; set; }
        public decimal intComposicion { get; set; }
        public int intIdUniComp { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        public string strCodAlt { get; set; }
        public string strTag { get; set; }
        public int intElim { get; set; }
        public int intIdSubFamilia { get; set; }
        public int intIdUni { get; set; }
        public int intIdClaArt { get; set; }
        public int intReceta { get; set; }

    }
}
