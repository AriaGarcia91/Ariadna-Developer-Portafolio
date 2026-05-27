using CPM.ReporteAuditoria.BusinessType;
using System.Collections.Generic;

namespace CPM.ReporteAuditoria.BusinessInterface
{
    public interface IBusinessUnitProcessor
    {
       List<Sucursal> RecuperarOficinas(int tipoOficina);
    }
}
