using CPM.Dummy.BussinesInterface;
using CPM.Dummy.BussinesLayer;
using CPM.Dummy.OperationalManager;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosEspecialesCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _processor;

        public ApiCreditosEspecialesCRMController(ILogger logger, IRespuestaProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [HttpPost]
        [Route("CPM/CreditosAutorizacionAutomatica/[action]")]
        public ContentResult Registrar()
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCreditosEspecialesCRM", "CreditosAutorizacionAutomatica/Registrar");

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

        [HttpGet]
        [Route("CPM/CreditosAutorizacionAutomatica/[action]/{numsocio}")]
        public ContentResult ConsultarAdeudoActualSocio(string numsocio)
        {
            try
            {
                string jsonResult = _processor.ObtenerMensajeJson("ApiCreditosEspecialesCRM", "CreditosAutorizacionAutomatica/ConsultarAdeudoActualSocio");
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
