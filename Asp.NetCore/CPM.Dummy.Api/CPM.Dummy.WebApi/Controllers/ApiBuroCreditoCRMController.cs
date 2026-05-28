using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesLayer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiBuroCreditoCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;

        public ApiBuroCreditoCRMController(ILogger logger, IRespuestaProcessor respuestaProccesor)
        {
            _logger = logger;
            _respuestaProccesor = respuestaProccesor;
        }
        // GET api/<ApiBuroCreditoCRMController>/
        [HttpGet]
        [Route("CPM/BuroCredito/[action]/{id}")]
        public ContentResult ConsultarVigencias(int id)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiBuroCreditoCRM", "BuroCredito/ConsultarVigencias");

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
        // GET api/<ApiBuroCreditoCRMController>/
        [HttpGet]
        [Route("CPM/BuroCredito/[action]/{id}")]
        public ContentResult ObtenerInformacionActual(int id)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiBuroCreditoCRM", "BuroCredito/ObtenerInformacionActual");

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
        // GET api/<ApiBuroCreditoCRMController>/
        [HttpGet]
        [Route("CPM/BuroCredito/[action]/{id}")]
        public ContentResult ConsultarInformacionOnline(int id)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiBuroCreditoCRM", "BuroCredito/ConsultarInformacionOnline");

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
