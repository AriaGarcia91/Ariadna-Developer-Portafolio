using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosScoringController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestaProccesor;


        public ApiCreditosScoringController(ILogger logger, IRespuestaProcessor respuestasProcessor)
        {
            _logger = logger;
            _respuestaProccesor = respuestasProcessor;
        }


        // GET: api/<ApiCreditosScoringController>
        [HttpGet]
        [Route("CPM/Creditos/[action]/{id}")]
        public ContentResult ConsultarDeudaSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosScoring", "Creditos/ConsultarDeudaSocio");

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
        [Route("CPM/Modelos/[action]/{id}")]
        public ContentResult ConsultarProductosOfertar()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosScoring", "Modelos/ConsultarProductosOfertar");

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
        [Route("CPM/Creditos/[action]")]
        public ContentResult ObtenerPI()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosScoring", "Creditos/ObtenerPI");

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
        [Route("CPM/Creditos/[action]")]
        public ContentResult CalcularTFR()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosScoring", "Creditos/CalcularTFR");

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
        [Route("CPM/Creditos/[action]")]
        public ContentResult ConsultarAcumuladoSocio()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosScoring", "Creditos/ConsultarAcumuladoSocio");

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
        [Route("CPM/Renovaciones/[action]/{id}")]
        public ContentResult CalcularTasaPonderada()
        {
            try
            {
                string jsonResult = _respuestaProccesor.ObtenerMensajeJson("ApiCreditosScoring", "Renovaciones/CalcularTasaPonderada");
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


