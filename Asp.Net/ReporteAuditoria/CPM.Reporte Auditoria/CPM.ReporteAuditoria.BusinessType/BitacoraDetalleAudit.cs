using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.ReporteAuditoria.BusinessType
{
    public class BitacoraDetalleAudit
    {
        public List<DetalleAudit> Detalles{ get; set; }
        public Pagination Paginado { get; set; }
        public string IdRegistro { get; set; }
        public string EntityName { get; set; }
    }
}
