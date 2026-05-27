using CPM.ReporteAuditoria.OperationalManagement.Extensions;
using System;
using System.Diagnostics;


namespace CPM.ReporteAuditoria.OperationalManagement
{
    public class EventLogger:ILogger
    {
        private const string source = "CPM.AuditoriaReporte";

        public void Error(Exception ex)
        {
            string message = string.Format("Error ocurrido {0} detalle: {1}", DateTime.Now, ex.Build());
            EventLog.WriteEntry(source, message, EventLogEntryType.Error);
        }

        public void Error(string error)
        {
            EventLog.WriteEntry(source, error, EventLogEntryType.Error);
        }

        public void Info(string mensaje)
        {
            EventLog.WriteEntry(source, mensaje, EventLogEntryType.Information);
        }
    }
}
