using System;

namespace CPM.ReporteAuditoria.OperationalManagement
{
    public interface ILogger
    {
        void Error(Exception ex);
        void Error(string error);
        void Info(string mensaje);
    }
}
