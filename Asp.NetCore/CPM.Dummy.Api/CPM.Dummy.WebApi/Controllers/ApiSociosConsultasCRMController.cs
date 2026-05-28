using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiSociosConsultasCRMController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;
        public ApiSociosConsultasCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }

        // GET: api/<ApiSociosConsultasCRMController>
        [HttpGet]
        [Route("CPM/[action]/{id}")]
        public ContentResult Socio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosConsultasCRM", "CPM/Socio");

                if (string.IsNullOrEmpty(jsonResult))
                {
                    return new ContentResult
                    {
                        StatusCode = 404,
                        Content = "No se encontró la respuesta para la solicitud.",
                        ContentType = "text/plain"
                    };
                }

                return new ContentResult
                {
                    StatusCode = 200,
                    Content = jsonResult,
                    ContentType = "application/json"
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                return new ContentResult
                {
                    StatusCode = 500,
                    Content = "Error Interno.",
                    ContentType = "text/plain"
                };
            }
        }
        [HttpGet]
        [Route("CPM/TarjetaCredito/[action]/{id}")]
        public ContentResult ObtenerInformacionTarjetasPreautorizadasSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosConsultasCRM", "TarjetaCredito/ObtenerInformacionTarjetasPreautorizadasSocio");

                if (string.IsNullOrEmpty(jsonResult))
                {
                    return new ContentResult
                    {
                        StatusCode = 404,
                        Content = "No se encontró la respuesta para la solicitud.",
                        ContentType = "text/plain"
                    };
                }

                return new ContentResult
                {
                    StatusCode = 200,
                    Content = jsonResult,
                    ContentType = "application/json"
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                return new ContentResult
                {
                    StatusCode = 500,
                    Content = "Error Interno.",
                    ContentType = "text/plain"
                };
            }
        }




    }
}
