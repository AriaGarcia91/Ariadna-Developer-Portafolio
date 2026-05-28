using CPM.Dummy.OperationalManager.ExtensionMethods;
using System.Diagnostics;

namespace CPM.Dummy.OperationalManager
{
    public class EventLogger : ILogger
    {
        #region Variables Globales

        private string _source = "CPM.Dummy";

        #endregion
        public void Info(string message)
        {
            EventLog.WriteEntry(_source, message, EventLogEntryType.Information);
        }

        public void Error(Exception ex)
        {
            string message = string.Format("Error ocurrido {0} detalle: {1}", DateTime.Now.ToShortDateString(), ex.Build());
            EventLog.WriteEntry(_source, message, EventLogEntryType.Error);
        }

        public void Error(string error)
        {
            EventLog.WriteEntry(_source, error, EventLogEntryType.Error);
        }
    }
}
