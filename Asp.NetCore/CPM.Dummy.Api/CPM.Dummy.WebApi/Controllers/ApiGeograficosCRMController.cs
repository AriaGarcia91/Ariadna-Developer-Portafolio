using CPM.Dummy.BussinesInterface;
using CPM.Dummy.OperationalManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiGeograficosCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProcessor;
        public ApiGeograficosCRMController(ILogger logger, IRespuestaProcessor respuestaProcessor)
        {
            _logger = logger;
            _respuestaProcessor = respuestaProcessor;
        }

        [HttpGet]
        [Route("CPM/SITI/[action]")]
        public ContentResult ConsultarEstados()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiGeograficosCRM", "SITI/ConsultarEstados");

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
        [Route("CPM/SITI/[action]")]
        public ContentResult ConsultarMunicipios([FromQuery]int?claveEstado=1)
        {
            try
            {
                if (claveEstado == null)
                {
                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "El párametro 'claveEstado' es requerido.",
                        ContentType = "text/plain"
                    };
                }

                string jsonResult = _respuestaProcessor.ObtenerMensajeJson(
                    "ApiGeograficosCRM", "SITI/ConsultarMunicipios");

                if (string.IsNullOrEmpty(jsonResult))
                {
                    return new ContentResult
                    {
                        StatusCode = 404,
                        Content = "No se encontró información para los parámetros proporcionados.",
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
        [Route("CPM/SITI/[action]")]
        public ContentResult ConsultarLocalidades([FromQuery] int? claveEstado, [FromQuery] int? claveMunicipio)
        {
            try
            {
                if (claveEstado == null || claveMunicipio == null)
                {
                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "Los parámetros 'claveEstado' y 'claveMunicipio' son requeridos.",
                        ContentType = "text/plain"
                    };
                }

                string jsonResult = _respuestaProcessor.ObtenerMensajeJson(
                    "ApiGeograficosCRM", "SITI/ConsultarLocalidades");

                if (string.IsNullOrEmpty(jsonResult))
                {
                    return new ContentResult
                    {
                        StatusCode = 404,
                        Content = "No se encontró información para los parámetros proporcionados.",
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
