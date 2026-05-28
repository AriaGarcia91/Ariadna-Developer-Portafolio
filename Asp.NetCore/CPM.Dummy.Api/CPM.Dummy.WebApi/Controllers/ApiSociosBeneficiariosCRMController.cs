using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiSociosBeneficiariosCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;


        public ApiSociosBeneficiariosCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {

            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }

        // POST api/<ApiSocioBeneficiarioCRMController>
        [HttpPost]
        [Route("CPM/Beneficiarios/[action]")]
        public ContentResult RegistrarBeneficiario()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Beneficiarios/RegistrarBeneficiario");

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

        // PUT api/<ApiSocioCuentaCRMController>/5
        [HttpPut]
        [Route("CPM/Beneficiarios/[action]")]
        public ContentResult ActualizarBeneficiario()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Beneficiarios/ActualizarBeneficiario");

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
        [Route("CPM/Beneficiarios/{action}/{id}")]
        public ContentResult ConsultarBeneficiarios()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Beneficiarios/ConsultarBeneficiarios");

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
        [Route("CPM/Beneficiarios/ConsultarBeneficiarios")]
        public ContentResult ConsultarBeneficiariosPorNumeroCuenta(Int64 numeroSocio, Int64 numeroCuenta)
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Beneficiarios/ConsultarBeneficiariosPorNumeroCuenta");

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
        [Route("CPM/Cuentas/{action}")]
        public ContentResult RegistrarCuentaBeneficiario()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Cuentas/RegistrarCuentaBeneficiario");

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
        [Route("CPM/Cuentas/{action}")]
        public ContentResult ActualizarCuentaBeneficiario()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Cuentas/ActualizarCuentaBeneficiario");

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

        [HttpDelete]
        [Route("CPM/Cuentas/{action}")]
        public ContentResult EliminarCuentaBeneficiario()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosBeneficiariosCRM", "Cuentas/EliminarCuentaBeneficiario");

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
