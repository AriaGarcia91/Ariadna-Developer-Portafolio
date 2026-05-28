using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiInversionesSimuladorController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;

        public ApiInversionesSimuladorController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {

            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }

        [HttpPost]
        [Route("CPM/Rendicuenta/[action]")]
        public ContentResult SimularInversion()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiInversionesSimulador", "Rendicuenta/SimularInversion");

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
        [Route("CPM/Mialcancia/SimularInversion")]
        public ContentResult MiAlcanciaSimularInversion()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiInversionesSimulador", "Mialcancia/SimularInversion");

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
