using CPM.Dummy.BussinesInterface;
using CPM.Dummy.OperationalManager;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiInversionesConsultasCRM : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;
        public ApiInversionesConsultasCRM(ILogger logger, IRespuestaProcessor respuestaProccesor)
        {
            _logger = logger;
            _respuestaProccesor = respuestaProccesor;
        }

        [HttpGet]
        [Route("CPM/Ahorro/ConsultarProductos")]
        public ContentResult ConsultarProductosAhorro()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesConsultasCRM", "Ahorro/ConsultarProductos");

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
        [Route("CPM/MiAlcancia/ConsultarProductos")]
        public ContentResult ConsultarProductosMiAlcancia()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesConsultasCRM", "MiAlcancia/ConsultarProductos");

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
        [Route("CPM/MiAlcancia/ConsultarProducto/{id}")]
        public ContentResult ConsultarProductoMiAlcancia()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesConsultasCRM", "MiAlcancia/ConsultarProducto");

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
        [Route("CPM/Rendicuenta/ConsultarProductos")]
        public ContentResult ConsultarProductosRendiCuenta()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesConsultasCRM", "Rendicuenta/ConsultarProductos");

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
        [Route("CPM/Rendicuenta/ConsultarProducto/{id}")]
        public ContentResult ConsultarProductoRendiCuenta()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesConsultasCRM", "Rendicuenta/ConsultarProducto");

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
