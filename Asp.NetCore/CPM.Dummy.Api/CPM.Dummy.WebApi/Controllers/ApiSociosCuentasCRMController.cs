using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiSociosCuentasCRMController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;

        public ApiSociosCuentasCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {

            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }

        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Ingreso/[action]")]
        public ContentResult RegistrarSocio()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosCuentasCRM", "Ingreso/RegistrarSocio");

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

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("CPM/Ahorro/[action]/{id}")]
        public ContentResult ConsultarCuentas(int id)
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosCuentasCRM", "Ahorro/ConsultarCuentas");

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

        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Ahorro/[action]")]
        public ContentResult RegistrarServicuenta()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosCuentasCRM", "Ahorro/RegistrarServicuenta");

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

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("CPM/Indicadores/[action]/{id}")]
        public ContentResult ObtenerIndicadoresBaja(int id)
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosCuentasCRM", "Indicadores/ObtenerIndicadoresBaja");

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
        [Route("CPM/TarjetasDebito/[action]")]
        public ContentResult EliminarRelacionTarjeta()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosCuentasCRM", "TarjetasDebito/EliminarRelacionTarjeta");

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
        [Route("CPM/CuentaMexicana/[action]")]
        public ContentResult ReaperturaCuentaMexicana()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosCuentasCRM", "CuentaMexicana/ReaperturaCuentaMexicana");

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
