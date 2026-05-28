using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiSociosDependientesEconomicosCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;

        public ApiSociosDependientesEconomicosCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }

        [HttpPost]
        [Route("CPM/DependientesEconomicos/[action]")]
        public ContentResult Registrar()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosDependientesEconomicosCRM", "DependientesEconomicos/Registrar");

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
        [Route("CPM/DependientesEconomicos/Actualizar/{id}")]
        public ContentResult ActualizarNumeroSocio()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosDependientesEconomicosCRM", "DependientesEconomicos/Actualizar");

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
        [Route("CPM/DependientesEconomicos/Eliminar/{id}")]
        public ContentResult EliminarNumeroSocio()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiSociosDependientesEconomicosCRM", "DependientesEconomicos/Eliminar");

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
