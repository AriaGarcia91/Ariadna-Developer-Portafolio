using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesLayer;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiModelosScoringController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasprocessor;

        public ApiModelosScoringController(ILogger logger, IRespuestaProcessor processor)
        {
            _logger = logger;
            _respuestasprocessor = processor;
        }

        [HttpGet]
        [Route("CPM/PersonalPlus/[action]/{id}")]
        public ContentResult ConsultarOfertas()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiModelosScoring", "PersonalPlus/ConsultarOfertas");

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
