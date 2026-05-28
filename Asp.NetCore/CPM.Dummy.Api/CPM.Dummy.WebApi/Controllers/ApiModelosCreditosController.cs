using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{

    [Route("[controller]/")]
    [ApiController]
    public class ApiModelosCreditosController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasProcessor;

        public ApiModelosCreditosController (ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestasProcessor = respuestasProcessor;
        }

        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Modelos/[action]")]
        public ContentResult ValidarGarantiaAval()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiModelosCreditos", "Modelos/ValidarGarantiaAval");

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
        [Route("CPM/Modelos/[action]")]
        public ContentResult ValidarViabilidadSolicitud()
        {
            try
            {
                string jsonResult = _respuestasProcessor.ObtenerMensajeJson("ApiModelosCreditos", "Modelos/ValidarViabilidadSolicitud");

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
