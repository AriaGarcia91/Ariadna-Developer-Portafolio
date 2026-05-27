using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.ReporteAuditoria.BusinessType.Catalogos
{
    public class Oficinas
    {
        public static readonly Dictionary<int, string> Diccionario = new Dictionary<int, string>
        {
            {1, "ODG"},
            {3, "Plaza"},
            {4, "Sucursal"}
        };
    }
}
