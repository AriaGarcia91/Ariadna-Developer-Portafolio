using CPM.Dummy.BussinesInterface;
using CPM.Dummy.OperationalManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosSimuladorCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProcessor;
        public ApiCreditosSimuladorCRMController(ILogger logger,IRespuestaProcessor respuestaProcessor)
        {
            _logger = logger;
            _respuestaProcessor = respuestaProcessor;
        }

        [HttpPost]
        [Route("CPM/PersonalPlus/SimularCredito")]
        public ContentResult SimularCreditoPersonal()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "PersonalPlus/SimularCredito");

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
        [Route("CPM/PersonalPlus/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariablePersonal()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "PersonalPlus/SimularCreditoVariable");

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
        [Route("CPM/PersonalPlus/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoPersonal()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "PersonalPlus/SimularPagoUnico");

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
        [Route("CPM/PersonalPlus/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosPersonalPlus()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "PersonalPlus/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/PersonalPlus/DescargarPlanPagosUnico")]
        public ActionResult DescargarPlanPagosUnicoPersonalPlus()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "PersonalPlus/DescargarPlanPagosUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/PersonalPlus/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariablePersonalPlus()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "PersonalPlus/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

  
        [HttpPost]
        [Route("CPM/Productivo/SimularCredito")]
        public ContentResult SimularCreditoProductivo()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Productivo/SimularCredito");

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
        [Route("CPM/Productivo/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariableProductivo()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Productivo/SimularCreditoVariable");

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
        [Route("CPM/Productivo/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoProductivo()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Productivo/SimularPagoUnico");

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
        [Route("CPM/Productivo/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosProductivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Productivo/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Productivo/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariableProductivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Productivo/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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


        [HttpPost]
        [Route("CPM/Productivo/DescargarPlanPagosUnico")]
        public ActionResult DescargarPlanPagosUnicoProductivo()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Productivo/DescargarPlanPagosUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Contingente/SimularCredito")]
        public ContentResult SimularCreditoContingente()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Contingente/SimularCredito");

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
        [Route("CPM/Contingente/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariableContingente()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Contingente/SimularCreditoVariable");

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
        [Route("CPM/Contingente/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoContigente()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Contingente/SimularPagoUnico");

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
        [Route("CPM/Contingente/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosContingente()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Contingente/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Contingente/DescargarPlanPagosUnico")]
        public ActionResult DescargarPlanPagosUnicoContingente()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Contingente/DescargarPlanPagosUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Contingente/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariableContingente()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Contingente/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Renovacion/SimularCredito")]
        public ContentResult SimularCreditoRenovacion()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Renovacion/SimularCredito");

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
        [Route("CPM/Renovacion/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariableRenovacion()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Renovacion/SimularCreditoVariable");

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
        [Route("CPM/Renovacion/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoRenovacion()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Renovacion/SimularPagoUnico");

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
        [Route("CPM/Renovacion/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosRenovacion()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Renovacion/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Renovacion/DescargarPlanPagosUnico")]
        public ActionResult DescargarPlanPagosUnicoRenovacion()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Renovacion/DescargarPlanPagosUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Renovacion/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariableRenovacion()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Renovacion/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Inmediato/SimularCredito")]
        public ContentResult SimularCreditoInmediato()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Inmediato/SimularCredito");

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
        [Route("CPM/Inmediato/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariableInmediato()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Inmediato/SimularCreditoVariable");

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
        [Route("CPM/Inmediato/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoInmediato()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Inmediato/SimularPagoUnico");

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
        [Route("CPM/Inmediato/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosInmediato()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Inmediato/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Inmediato/[action]")]
        public ActionResult DescargarPlanPagosUnico()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Inmediato/DescargarPlanPagosUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Inmediato/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariableInmediato()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Inmediato/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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


        [HttpPost]
        [Route("CPM/Credinamico/SimularCredito")]
        public ContentResult SimularCreditoCredinamico()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Credinamico/SimularCredito");

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
        [Route("CPM/Credinamico/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosCredinamico()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Credinamico/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Automotriz/SimularCredito")]
        public ContentResult SimularCreditoAutomotriz()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Automotriz/SimularCredito");

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
        [Route("CPM/Automotriz/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariableAutomotriz()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Automotriz/SimularCreditoVariable");

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
        [Route("CPM/Automotriz/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosAutomotriz()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Automotriz/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Automotriz/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariableAutomotriz()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Automotriz/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Hipotecario/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoHipotecario()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Hipotecario/SimularPagoUnico");

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
        [Route("CPM/Hipotecario/SimularCreditoVivienda")]
        public ContentResult SimularCreditoViviendaHipotecario()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Hipotecario/SimularCreditoVivienda");

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
        [Route("CPM/Hipotecario/SimularCreditoLiquidez")]
        public ContentResult SimularCreditoLiquidezHipotecario()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Hipotecario/SimularCreditoLiquidez");

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
        [Route("CPM/Hipotecario/SimularCreditoViviendaVariable")]
        public ContentResult SimularCreditoViviendaVariableHipotecario()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Hipotecario/SimularCreditoViviendaVariable");

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
        [Route("CPM/Hipotecario/SimularCreditoLiquidezVariable")]
        public ContentResult SimularCreditoLiquidezVariableHipotecario()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Hipotecario/SimularCreditoLiquidezVariable");

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
        [Route("CPM/Hipotecario/[action]")]
        public ActionResult DescargarPlanPagosVivienda()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Hipotecario/DescargarPlanPagosVivienda");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Hipotecario/[action]")]
        public ActionResult DescargarPlanPagosLiquidez()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Hipotecario/DescargarPlanPagosLiquidez");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Hipotecario/[action]")]
        public ActionResult DescargarPlanPagosViviendaVariable()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Hipotecario/DescargarPlanPagosViviendaVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Hipotecario/[action]")]
        public ActionResult DescargarPlanPagosLiquidezVariable()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Hipotecario/DescargarPlanPagosLiquidezVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
        [HttpPost]
        [Route("CPM/Hipotecario/[action]")]
        public ActionResult DescargarPlanPagosPagoUnico()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Hipotecario/DescargarPlanPagosPagoUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Estudiantil/SimularCredito")]
        public ContentResult SimularCreditoEstudiantil()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Estudiantil/SimularCredito");

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
        [Route("CPM/Estudiantil/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosEstudiantil()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Estudiantil/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Cosechando/SimularCredito")]
        public ContentResult SimularCreditoCosechando()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Cosechando/SimularCredito");

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
        [Route("CPM/Cosechando/SimularCreditoVariable")]
        public ContentResult SimularCreditoVariableCosechando()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Cosechando/SimularCreditoVariable");

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
        [Route("CPM/Cosechando/SimularPagoUnico")]
        public ContentResult SimularPagoUnicoCosechando()
        {
            try
            {
                string jsonResult = _respuestaProcessor.ObtenerMensajeJson("ApiCreditosSimuladorCRM", "Cosechando/SimularPagoUnico");

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
        [Route("CPM/Cosechando/DescargarPlanPagos")]
        public ActionResult DescargarPlanPagosCosechando()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Cosechando/DescargarPlanPagos");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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

        [HttpPost]
        [Route("CPM/Cosechando/DescargarPlanPagosVariable")]
        public ActionResult DescargarPlanPagosVariableCosechando()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Cosechando/DescargarPlanPagosVariable");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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


        [HttpPost]
        [Route("CPM/Cosechando/DescargarPlanPagosUnico")]
        public ActionResult DescargarPlanPagosUnicoCosechando()
        {
            try
            {
                string documentoPdf64 = _respuestaProcessor.ObtenerDocumentoPdf("ApiCreditosSimuladorCRM", "Cosechando/DescargarPlanPagosUnico");

                if (!string.IsNullOrEmpty(documentoPdf64))
                {
                    byte[] pdfBytes = Convert.FromBase64String(documentoPdf64);
                    return File(pdfBytes, "application/pdf", "PlanPagos.pdf");

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
