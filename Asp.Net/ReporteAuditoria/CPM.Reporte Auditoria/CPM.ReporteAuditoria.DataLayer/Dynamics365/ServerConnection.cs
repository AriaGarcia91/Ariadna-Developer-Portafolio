using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CPM.ReporteAuditoria.DataLayer.Dynamics365
{
    public class ServerConnection:IDisposable
    {
        #region Propiedades

        public CrmServiceClient CnxCrm { get; set; }
        public string SqlCnx { get; set; }
        public IOrganizationService Service { get; set; }
        public OrganizationServiceContext Context { get; set; }

        private bool _disposed = false;

        #endregion

        #region Constructores

        public ServerConnection(string conexion = "CRM")
        {
            if (!_disposed)
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                string connectionString = GetServiceConfiguration(conexion);
                SqlCnx = connectionString;
                CnxCrm = new CrmServiceClient(connectionString);
                Service = (IOrganizationService)CnxCrm.OrganizationWebProxyClient != null ?
                    (IOrganizationService)CnxCrm.OrganizationWebProxyClient :
                    (IOrganizationService)CnxCrm.OrganizationServiceProxy;
                Context = new OrganizationServiceContext(Service);
            }
        }
        #endregion

        #region Dispose Objetos

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static String GetServiceConfiguration(string connectionStringName)
        {
            // Get available connection strings from app.config.
            int count = ConfigurationManager.ConnectionStrings.Count;

            // Create a filter list of connection strings so that we have a list of valid
            // connection strings for Microsoft Dynamics CRM only.
            List<KeyValuePair<String, String>> filteredConnectionStrings =
                new List<KeyValuePair<String, String>>();

            for (int a = 0; a < count; a++)
            {
                if (isValidConnectionString(ConfigurationManager.ConnectionStrings[a].ConnectionString))
                    filteredConnectionStrings.Add
                        (new KeyValuePair<string, string>
                            (ConfigurationManager.ConnectionStrings[a].Name,
                            ConfigurationManager.ConnectionStrings[a].ConnectionString));
            }

            // No valid connections strings found. Write out and error message.
            if (filteredConnectionStrings.Count == 0)
            {
                Console.WriteLine("An app.config file containing at least one valid Microsoft Dynamics CRM " +
                    "connection string configuration must exist in the run-time folder.");
                Console.WriteLine("\nThere are several commented out example connection strings in " +
                    "the provided app.config file. Uncomment one of them and modify the string according " +
                    "to your Microsoft Dynamics CRM installation. Then re-run the sample.");
                return null;
            }

            // If one valid connection string is found, use that.
            if (filteredConnectionStrings.Count == 1)
            {
                return filteredConnectionStrings[0].Value;
            }

            // If more than one valid connection string is found, let the user decide which to use.
            if (filteredConnectionStrings.Count > 1)
            {
                for (int i = 0; i < filteredConnectionStrings.Count; i++)
                {
                    if (filteredConnectionStrings[i].Key == connectionStringName)
                        return filteredConnectionStrings[i].Value;
                }

            }
            return null;
        }

        private static Boolean isValidConnectionString(String connectionString)
        {
            // At a minimum, a connection string must contain one of these arguments.
            if (connectionString.Contains("Url=") ||
                connectionString.Contains("Server=") ||
                connectionString.Contains("ServiceUri="))
                return true;

            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Context.Dispose();
            }
        }

        #endregion
    }
}
