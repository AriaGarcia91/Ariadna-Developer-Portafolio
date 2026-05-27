using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.ReporteAuditoria.BusinessType
{
    public class BitacoraPaginado
    {
        public List<Audit> Auditorias { get; set; }
        public Pagination Paginacion { get; set; }
    }
}
