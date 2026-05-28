using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCuentasConsultasCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _processor;
        public ApiCuentasConsultasCRMController(ILogger logger, IRespuestaProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }
     
        [HttpGet]
        [Route("CPM/Generales/[action]/{id}")]
        public ContentResult ListarCuentasSocio()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "Generales/ListarCuentasSocio");
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
        [Route("CPM/TarjetasCredito/[action]/{id}")]

        public ContentResult ObtenerInformacion()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "TarjetasCredito/ObtenerInformacion");
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
        [Route("CPM/TarjetasCredito/[action]/{id}")]
        public ContentResult ObtenerInformacionCuenta()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "TarjetasCredito/ObtenerInformacionCuenta");
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
        [Route("CPM/Inversion/[action]/{id}")]
        public ContentResult ConsultarCuentas()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "Inversion/ConsultarCuentas");
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
        [Route("CPM/CuentasAhorro/[action]/{numsocio}")]
        public ContentResult ConsultarCuentaMexicana()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "CuentasAhorro/ConsultarCuentaMexicana");
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
        [Route("CPM/Renovaciones/ConsultarDatosCreditos")]
        public ContentResult RenovacionesConsultarCreditos()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "Renovaciones/ConsultarDatosCreditos");
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
        [Route("CPM/Renovaciones/ConsultarDetalleCreditos/{creditos}")]
        public ContentResult RenovacionesDetalleCreditos(string creditos)
        {
            try
            {
                if (creditos == null || creditos == "")
                {
                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "el parámetro 'creditos'es requerido.",
                        ContentType = "text/plain"
                    };
                }
                string jsonResult = _processor.ObtenerMensajeJson("ApiCuentasConsultasCRM", "Renovaciones/ConsultarDetalleCreditos");
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
