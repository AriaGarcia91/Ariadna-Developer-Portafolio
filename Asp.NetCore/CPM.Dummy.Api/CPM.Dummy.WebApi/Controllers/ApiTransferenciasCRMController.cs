using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiTransferenciasCRMController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;


        public ApiTransferenciasCRMController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }

        // POST api/<ApiTransferenciasCRM>
        [HttpPost]
        [Route("CPM/CuentasPropias/[action]")]
        public ContentResult TransferirAhorroAhorro()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiTransferenciasCRM", "CuentasPropias/TransferirAhorroAhorro");

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
        [Route("CPM/CuentasPropias/[action]")]
        public ContentResult TransferirAhorroInversion()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiTransferenciasCRM", "CuentasPropias/TransferirAhorroInversion");

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
