using CPM.Dummy.BussinesInterface;
using CPM.Dummy.BussinesLayer;
using Microsoft.AspNetCore.Mvc;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[Controller]/")]
    [ApiController]
    public class ApiCreditosDocumentacionConsultasController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;
        public ApiCreditosDocumentacionConsultasController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }
        [HttpGet]
        [Route("CPM/Automotriz/ConsultarDocumentosSolicitudEtapa")]
        public ContentResult ConsultarDocumentosSolicitudEtapa([FromQuery] string FolioSolicitud, [FromQuery] int IdEtapa)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosDocumentacionConsultas", "Automotriz/ConsultarDocumentosSolicitudEtapa");

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
        [Route("CPM/Automotriz/ConsultarArchivo/{id}")]
        public ActionResult AutomotrizConsultarArchivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProccesor.ObtenerDocumentoPdf("ApiCreditosDocumentacionConsultas", "Automotriz/ConsultarArchivo");
                byte[] data = Convert.FromBase64String(documentoPdf64); 
                string decodedBase64 = System.Text.Encoding.UTF8.GetString(data);
                if (!string.IsNullOrEmpty(decodedBase64))
                {
                    byte[] bytes = Convert.FromBase64String(decodedBase64);            
                    return File(new MemoryStream(bytes),"application/octet-stream");

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

        [HttpGet]
        [Route("CPM/Credinamico/ConsultarDocumentosSolicitudEtapa")]
        public ContentResult CredinamicoConsultarDocumentoSolicitudEtapa([FromQuery] string FolioSolicitud, [FromQuery] int IdEtapa)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosDocumentacionConsultas", "Credinamico/ConsultarDocumentosSolicitudEtapa");

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
        [Route("CPM/Credinamico/ConsultarArchivo/{folio}")]
        public ActionResult CredinamicoConsultarArchivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProccesor.ObtenerDocumentoPdf("ApiCreditosDocumentacionConsultas", "Credinamico/ConsultarArchivo");
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

        [HttpGet]
        [Route("CPM/Hipotecario/ConsultarDocumentosSolicitud/{folio}")]
        public ContentResult HipotecarioConsultarDocumentosSolicitud()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosDocumentacionConsultas", "Hipotecario/ConsultarDocumentosSolicitud");

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
        [Route("CPM/Hipotecario/ConsultarArchivo/{id}")]
        public ActionResult HipotecarioConsultarArchivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProccesor.ObtenerDocumentoPdf("ApiCreditosDocumentacionConsultas", "Hipotecario/ConsultarArchivo");
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
        [HttpGet]
        [Route("CPM/PersonalPlus/ConsultarDocumentosSolicitudEtapa")]
        public ContentResult PersonalPlusConsultarDocumentosSolicitudEtapa([FromQuery] string FolioSolicitud, [FromQuery] int IdEtapa)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosDocumentacionConsultas", "PersonalPlus/ConsultarDocumentosSolicitudEtapa");

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
        [Route("CPM/PersonalPlus/ConsultarArchivo/{id}")]
        public ActionResult PersonalPlusConsultarArchivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProccesor.ObtenerDocumentoPdf("ApiCreditosDocumentacionConsultas", "PersonalPlus/ConsultarArchivo");
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

        [HttpGet]
        [Route("CPM/TarjetaCredito/ConsultarDocumentosSolicitud/{folioSolicitud}")]
        public ContentResult TarjetaCreditoConsultarDocumentosSolicitud(string folioSolicitud)
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosDocumentacionConsultas", "TarjetaCredito/ConsultarDocumentosSolicitud");

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
        [Route("CPM/TarjetaCredito/ConsultarArchivo/{claveArchivo}")]
        public ActionResult TarjetaCreditoConsultarArchivo(string claveArchivo)
        {
            try
            {
                string documentoPdf64 = _respuestaProccesor.ObtenerDocumentoPdf("ApiCreditosDocumentacionConsultas", "TarjetaCredito/ConsultarArchivo");
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
