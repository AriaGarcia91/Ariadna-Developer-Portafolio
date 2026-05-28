using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiPersonasBloqueadasController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasprocessor;

        public ApiPersonasBloqueadasController(ILogger logger, IRespuestaProcessor processor)
        {
            _logger = logger;
            _respuestasprocessor = processor;
        }

        [HttpPost]
        [Route("CPM/Auth/[action]")]
        public ContentResult APIPersonasBloqueadas()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiPersonasBloqueadas", "Auth/APIPersonasBloqueadas");

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
