using CPM.ReporteAuditoria.BusinessType;
using System.Collections.Generic;

namespace CPM.ReporteAuditoria.DataInterface
{
    public interface IBusinessUnitRepository
    {
        List<Sucursal> RecuperarOficinas(int tipoOficina);
    }
}
