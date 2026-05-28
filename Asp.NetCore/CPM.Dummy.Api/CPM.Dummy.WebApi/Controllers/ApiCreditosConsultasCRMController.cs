using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesLayer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosConsultasCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;
        public ApiCreditosConsultasCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {

            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }

        [HttpGet]
        [Route("CPM/Productos/[action]")]
        public ContentResult ConsultarConfiguracionProductos()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Productos/ConsultarConfiguracionProductos");

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
        [Route("CPM/Creditos/[action]")]
        public ContentResult ConsultarFechaOperativa()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Creditos/ConsultarFechaOperativa");

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
        [Route("CPM/Hipotecario/[action]/{num}/{prod}")]
        public ContentResult ValidarCreditoSocio()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Hipotecario/ValidarCreditoSocio");

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
        [Route("CPM/Creditos/[action]/{id}")]
        public ContentResult ConsultarIndicadores()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Creditos/ConsultarIndicadores");

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
        [Route("CPM/Creditos/[action]")]
        public ContentResult ConsultarFechasCredito()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Creditos/ConsultarFechasCredito");

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
        [Route("CPM/Hipotecario/ConsultarFechaPrimerPago")]
        public ContentResult ConsultarFechaPrimerPago(string FechaOperacion)
        {
            try
            {
                // Validar el formato de la fecha
                if (!DateTime.TryParseExact(FechaOperacion, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "El formato de la fecha es incorrecto. Debe ser 'yyyy-MM-dd'.",
                        ContentType = "text/plain"
                    };
                }

                // Aquí debes llamar a tu método que procesa la respuesta, similar a "ObtenerMensajeJson".
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "ConsultarFechaPrimerPago/FechaOperacion");

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
        [Route("CPM/Renovaciones/ValidarCreditoSocio/{numerosocio}/{producto}")]
        public ContentResult ValidarCreditoSocioRenovacion()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Renovaciones/ValidarCreditoSocio");

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
        [Route("CPM/Cosechando/[action]")]
        public ContentResult ConsultarCadenasProductivas()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosConsultasCRM", "Cosechando/ConsultarCadenasProductivas");

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
