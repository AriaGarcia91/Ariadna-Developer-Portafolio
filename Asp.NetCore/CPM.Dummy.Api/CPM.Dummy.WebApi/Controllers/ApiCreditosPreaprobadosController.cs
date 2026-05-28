using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesLayer;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosPreaprobadosController : Controller
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;

        public ApiCreditosPreaprobadosController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {

            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }


        [HttpGet]
        [Route("CPM/Credito/ConsultarSocio/{id}")]
        public ContentResult ConsultarSocio()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiCreditosPreaprobados", "Credito/ConsultarSocio");
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
