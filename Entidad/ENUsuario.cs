using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENUsuario
    {
        public int intIdUsu { get; set; }
        public string password { get; set; }
        public string strCoUsu { get; set; }
        public string strNombreCompleto { get; set; }
        public string strNoUsu { get; set; }
        public string strClave { get; set; }
        public int intEstado { get; set; }
        
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        public int intElim { get; set; }

    }
}
