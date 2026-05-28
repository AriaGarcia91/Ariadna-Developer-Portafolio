using CPM.Dummy.BussinesInterface;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiSocioDocumentacionConsultasController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _processor;
        public ApiSocioDocumentacionConsultasController(ILogger logger, IRespuestaProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }


        [HttpGet]
        [Route("CPM/Socio/[action]")]
        public ContentResult ConsultarDocumentosSocio([FromQuery]string NumeroSocio)
        {
            try
            {
                if (NumeroSocio == null || NumeroSocio == "")
                {
                    return new ContentResult
                    {
                        StatusCode = 400,
                        Content = "el parámetro 'creditos'es requerido.",
                        ContentType = "text/plain"
                    };
                }
                string jsonResult = _processor.ObtenerMensajeJson("ApiSocioDocumentacionConsultas", "Socio/ConsultarDocumentosSocio");
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
        [Route("CPM/Socio/[action]")]
        public ActionResult ConsultarArchivo(string ClaveArchivo)
        {
            try
            {
                string documentoPdf64 = _processor.ObtenerDocumentoPdf("ApiSocioDocumentacionConsultas", "Socio/ConsultarArchivo");
                byte[] data = Convert.FromBase64String(documentoPdf64);
                string decodedBase64 = System.Text.Encoding.UTF8.GetString(data);
                if (!string.IsNullOrEmpty(decodedBase64))
                {
                    byte[] bytes = Convert.FromBase64String(decodedBase64);
                    return File(new MemoryStream(bytes), "application/octet-stream");
                }
                return NotFound();
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
