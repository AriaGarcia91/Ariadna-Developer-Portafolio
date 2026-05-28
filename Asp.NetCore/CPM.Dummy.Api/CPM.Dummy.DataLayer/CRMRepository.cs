using CPM.Dummy.DataInterface;
using CPM.Dummy.OperationalManager;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Data.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace CPM.Dummy.DataLayer
{
    public class CRMRepository : ICRMRepository
    {
        private readonly ILogger _logger;
        private readonly ApiConnection _connection;
        public CRMRepository(ApiConnection connection, ILogger logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public string ConsultaFetchRespuestaApiDocumento(string api, string firma)
        {
            return $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                      <entity name='rs_respuestaapi'>
                        <attribute name='rs_respuestaapiid' />
                        <attribute name='rs_name'/>
                        <attribute name='rs_dummy'/>
                        <attribute name='createdon'/>
                        <order attribute='rs_name' descending='false'/>
                    <filter type='and'>
                        <condition attribute='rs_firma' operator='eq' value='{firma}'/>
                    </filter>
                    <link-entity name='rs_api' from='rs_apiid' to='rs_api' link-type='inner' alias='ab'>
                     <filter type='and'>
                        <condition attribute='rs_name' operator='eq' value='{api}'/>
                    </filter>
                    </link-entity>
                    <link-entity name='annotation' from='objectid' to='rs_respuestaapiid' link-type='inner' alias='nota' intersect='true'>
                        <attribute name='documentbody'/>
                    </link-entity>
              </entity>
             </fetch>";
        }
        public string ConsultaFetchRespuestaApi(string api, string firma)
        {
            return $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                        <entity name='rs_respuestaapi'>
                            <attribute name='rs_respuestaapiid' />
                            <attribute name='rs_name' />
                            <attribute name='rs_dummy' />
                            <attribute name='createdon' />
                            <order attribute='rs_name' descending='false' />
                            <filter type='and'>
                               <condition attribute='rs_firma' operator='eq' value='{firma}' />
                            </filter>
                        <link-entity name='rs_api' from='rs_apiid' to='rs_api' link-type='inner' alias='ab'>
                        <filter type='and'>
                            <condition attribute='rs_name' operator='eq' value='{api}' />
                        </filter>
                        </link-entity>
                      </entity>
                    </fetch>";
        }

      
        public string ConsultaRespuestaApi(string api, string firma)
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    string fetchXml = ConsultaFetchRespuestaApi(api, firma);
                    string uri = "rs_respuestaapis?fetchXml=" + HttpUtility.UrlEncode(fetchXml);
                    HttpResponseMessage response = client.GetAsync(uri,
                            HttpCompletionOption.ResponseHeadersRead).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        var jsonObject = JObject.Parse(content);
                        string rsDummyValue = jsonObject["value"]?[0]?["rs_dummy"]?.ToString();
                        return rsDummyValue;
                    }
                    else
                    {
                        throw new Exception($"The request failed with a status of {response.ReasonPhrase}");
                    }
                }
            }

            catch (Exception ex)
            {

                _logger.Error(ex);
                return "Error al realizar solicitud";
            }
        }

        public string ConsultaRespuestaApiDocumento(string api, string firma)
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    string fetchXml = ConsultaFetchRespuestaApiDocumento(api, firma);
                    string uri = "rs_respuestaapis?fetchXml=" + HttpUtility.UrlEncode(fetchXml);
                    HttpResponseMessage response = client.GetAsync(uri,
                            HttpCompletionOption.ResponseHeadersRead).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        var jsonObject = JObject.Parse(content);
                        string document64 = jsonObject["value"]?[0]?["nota.documentbody"]?.ToString();
                        return document64;
                    }
                    else
                    {
                        throw new Exception($"The request failed with a status of {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        private HttpClient GetHttpClient()
        {
            NetworkCredential credentials = new NetworkCredential(_connection.UserName, _connection.Password, _connection.Domain);
            HttpMessageHandler messageHandler = new HttpClientHandler() { Credentials = credentials };
            HttpClient httpClient = new HttpClient(messageHandler)
            {
                BaseAddress = new Uri(string.Format("{0}/api/data/{1}/", _connection.UrlBase, "v9.0")),

                Timeout = new TimeSpan(0, 2, 0)  //2 minutes
            };
            return httpClient;
        }
    }
}
