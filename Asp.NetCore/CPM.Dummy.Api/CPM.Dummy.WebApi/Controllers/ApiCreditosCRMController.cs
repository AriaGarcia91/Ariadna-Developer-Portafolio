using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;

        public ApiCreditosCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/PersonalPlus/ActualizarEstatus")]
        public ContentResult ActualizarEstatusPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "PersonalPlus/ActualizarEstatus");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Credinamico/ActualizarEstatus")]
        public ContentResult ActualizarEstatusCredinamico()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Credinamico/ActualizarEstatus");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Automotriz/ActualizarEstatus")]
        public ContentResult ActualizarEstatusAutomotriz()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Automotriz/ActualizarEstatus");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Hipotecario/[action]")]
        public ContentResult ActualizarEstatusSolicitud()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Hipotecario/ActualizarEstatusSolicitud");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Credinamico/[action]")]
        public ContentResult ActualizarSolicitudApertura()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Credinamico/ActualizarSolicitudApertura");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/PersonalPlus/[action]")]
        public ContentResult ActualizarSolicitud()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "PersonalPlus/ActualizarSolicitud");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Credinamico/[action]")]
        public ContentResult ActualizarSolicitudAmpliacion()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Credinamico/ActualizarSolicitudAmpliacion");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Automotriz/ActualizarDatosSolicitud")]
        public ContentResult ActualizarDatosSolicitudAutomotriz()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Automotriz/ActualizarDatosSolicitud");

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

        // PUT api/<ApiCreditosCRMController>/5
        [HttpPut]
        [Route("CPM/Hipotecario/ActualizarDatosSolicitud")]
        public ContentResult ActualizarDatosSolicitudHipotecario()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosCRM", "Hipotecario/ActualizarDatosSolicitud");

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
