using CPM.Dummy.BussinesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiAsignacionTarjetaCreditoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProcessor;
        public ApiAsignacionTarjetaCreditoController(ILogger logger, IRespuestaProcessor respuestaProcessor)
        {
            _logger = logger;
            _respuestaProcessor = respuestaProcessor;
        }

        [HttpGet]
        [Route("CPM/Rastreo/[action]/{folio}")]
        public ContentResult ConsultarInformacion(string folio, string numeroSocio)
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiAsignacionTarjetaCredito", "Rastreo/ConsultarInformacion");
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

        [HttpPut]
        [Route("CPM/Rastreo/[action]")]
        public ContentResult AsociarCuentaTarjeta()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiAsignacionTarjetaCredito", "Rastreo/AsociarCuentaTarjeta");

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

        [HttpPost]
        [Route("CPM/ActivacionNIP/[action]")]
        public ContentResult InyeccionNIP()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiAsignacionTarjetaCredito", "ActivacionNIP/InyeccionNIP");

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

        [HttpPost]
        [Route("CPM/ActivacionNIP/[action]")]
        public ContentResult ValidarTarjeta()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiAsignacionTarjetaCredito", "ActivacionNIP/ValidarTarjeta");

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
        [Route("CPM/TarjetaVirtual/[action]/{numeroSocio}")]
        public ContentResult GenerarScoring(string numeroSocio)
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiAsignacionTarjetaCredito", "TarjetaVirtual/GenerarScoring");
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
