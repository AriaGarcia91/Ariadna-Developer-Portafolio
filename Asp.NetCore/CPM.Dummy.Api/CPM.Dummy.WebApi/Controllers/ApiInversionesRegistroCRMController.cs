using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiInversionesRegistroCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;


        public ApiInversionesRegistroCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }


        // POST api/<ApiInversionesRegistroCRM>
        [HttpPost]
        [Route("CPM/MiAlcancia/[action]")]
        public ContentResult RegistrarMiAlcancia()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesRegistroCRM", "MiAlcancia/RegistrarMiAlcancia");

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
        [Route("CPM/Rendicuenta/[action]")]
        public ContentResult RegistrarRendicuenta()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiInversionesRegistroCRM", "Rendicuenta/RegistrarRendicuenta");

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
