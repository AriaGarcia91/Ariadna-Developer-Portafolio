using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using Microsoft.AspNetCore.Razor.TagHelpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiSociosRegistroCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;


        public ApiSociosRegistroCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }


        [HttpPost]
        [Route("CPM/Ingreso/[action]")]
        public ContentResult RegistrarSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "Ingreso/RegistrarSocio");

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
        [Route("CPM/ActualizacionDatos/[action]")]
        public ContentResult ActualizarDatosSEI()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "ActualizacionDatos/ActualizarDatosSEI");

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
        [Route("CPM/ActualizacionDatos/[action]")]
        public ContentResult ActualizarDatosContacto()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "ActualizacionDatos/ActualizarDatosContacto");

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
        [Route("CPM/ActualizacionDatos/[action]")]
        public ContentResult RegistrarCambioDomicilio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "ActualizacionDatos/RegistrarCambioDomicilio");

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
        [Route("CPM/ActualizacionDatos/[action]")]
        public ContentResult ModificarSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "ActualizacionDatos/ModificarSocio");

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
        [Route("CPM/ActualizacionDatos/[action]")]
        public ContentResult ActualizarDatosOcupacion()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "ActualizacionDatos/ActualizarDatosOcupacion");

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
        [Route("CPM/Reingreso/RegistrarSocio")]
        public ContentResult ReingresoRegistarSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "Reingreso/RegistrarSocio");

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
        [Route("CPM/Conversion/[action]/{id}")]
        public ContentResult ConvertirNoSocioPersonaFisica()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosRegistroCRM", "Conversion/ConvertirNoSocioPersonaFisica");

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
