using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{

    [Route("[controller]/")]
    [ApiController]
    public class ApiSociosDemograficosConsultasController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;

        public ApiSociosDemograficosConsultasController(ILogger logger, IRespuestaProcessor respuestaProccesor)
        {
            _logger = logger;
            _respuestaProccesor = respuestaProccesor;
        }

        // GET api/<ApiSociosDemograficosConsultasController>/5
        [HttpGet]
        [Route("CPM/Generales/[action]/{id}")]
        public ContentResult ConsultarDatosSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiSociosDemograficosConsultas", "Generales/ConsultarDatosSocio");

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
