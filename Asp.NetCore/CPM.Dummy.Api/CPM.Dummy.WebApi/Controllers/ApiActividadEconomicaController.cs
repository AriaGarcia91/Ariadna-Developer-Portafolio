using CPM.Dummy.BussinesInterface;
using CPM.Dummy.OperationalManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiActividadEconomicaController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProcessor;
        public ApiActividadEconomicaController(ILogger logger, IRespuestaProcessor respuestaProcessor)
        {
            _logger = logger;
            _respuestaProcessor = respuestaProcessor;
        }
        [HttpGet]
        [Route("CPM/Consultas/ActividadEconomica/{id}")]
        public ContentResult ConsultasActividadEconomica()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiActividadEconomica", "Consultas/ActividadEconomica");

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
        [Route("CPM/Consultas/ActividadesEconomicas")]
        public ContentResult ConsultasActividadesEconomicas()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiActividadEconomica", "Consultas/ActividadesEconomicas");

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
        [Route("CPM/Consultas/Ocupaciones")]
        public ContentResult ConsultasOcupaciones()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiActividadEconomica", "Consultas/Ocupaciones");

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

