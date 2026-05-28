using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using Microsoft.AspNetCore.Mvc;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiCatalogosSpeiController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProcessor;
        public ApiCatalogosSpeiController(ILogger logger, IRespuestaProcessor respuestaProcessor)
        {
            _logger = logger;
            _respuestaProcessor = respuestaProcessor;
        }

        [HttpGet]
        [Route("CPM/Instituciones/ConsultarInstituciones")]
        public ContentResult ConsultarInstituciones()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCatalogosSpei", "Instituciones/ConsultarInstituciones");

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
        [Route("CPM/Instituciones/{action}/{id}")]
        public ContentResult ValidarBINTarjeta()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCatalogosSpei", "Instituciones/ValidarBINTarjeta");
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
        [Route("CPM/Instituciones/{action}/{id}")]
        public ContentResult ValidarBINClabe()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCatalogosSpei", "Instituciones/ValidarBINClabe");
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
