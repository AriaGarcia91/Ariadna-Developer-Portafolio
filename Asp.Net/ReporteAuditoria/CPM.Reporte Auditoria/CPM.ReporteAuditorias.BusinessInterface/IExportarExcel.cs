using CPM.ReporteAuditoria.BusinessType;
using System.Collections.Generic;


namespace CPM.ReporteAuditoria.BusinessInterface
{
    public interface IExportarExcel
    {
        byte[] FormarExcel(List<Audit> auditorias);
    }
}
