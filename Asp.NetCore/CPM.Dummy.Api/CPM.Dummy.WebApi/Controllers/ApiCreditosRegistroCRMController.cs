using Microsoft.AspNetCore.Mvc;
using CPM.Dummy.BussinesInterface;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesLayer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Dummy.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ApiCreditosRegistroCRMController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRespuestaProcessor _respuestasprocessor;

        public ApiCreditosRegistroCRMController (ILogger logger, IRespuestaProcessor processor)
        {
            _logger = logger;
            _respuestasprocessor = processor;
        }

        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Inmediato/RegistrarGarantia")]
        public ContentResult RegistrarGarantiaInmediato()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Inmediato/RegistrarGarantia");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/PersonalPlus/RegistrarGarantia")]
        public ContentResult RegistrarGarantiaPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "PersonalPlus/RegistrarGarantia");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Inmediato/RegistrarCuenta")]
        public ContentResult RegistrarCuentaInmediato()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Inmediato/RegistrarCuenta");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/PersonalPlus/RegistrarCuenta")]
        public ContentResult RegistrarCuentaPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "PersonalPlus/RegistrarCuenta");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Credinamico/RegistrarCuenta")]
        public ContentResult RegistrarCuentaCredinamico()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Credinamico/RegistrarCuenta");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Inmediato/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoInmediato()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Inmediato/DesembolsarCredito");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/PersonalPlus/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "PersonalPlus/DesembolsarCredito");

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
        // POST api/<ApiSocioCuentaCRMController>
        [HttpPost]
        [Route("CPM/Credinamico/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoCredinamico()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Credinamico/DesembolsarCredito");

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
        [Route("CPM/Automotriz/[action]")]
        public ContentResult RegistrarGarantiaPrendaria()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Automotriz/RegistrarGarantiaPrendaria");

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
        [Route("CPM/Automotriz/RegistrarCuenta")]
        public ContentResult RegistrarCuentaAutomotriz()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Automotriz/RegistrarCuenta");

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
        [Route("CPM/Automotriz/[action]")]
        public ContentResult RegistrarCuentaSeminuevo()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Automotriz/RegistrarCuentaSeminuevo");

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
        [Route("CPM/Automotriz/[action]")]
        public ContentResult DesembolsarCredito()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Automotriz/DesembolsarCredito");

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
        public ContentResult RegistrarGarantiaHipotecaria()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/RegistrarGarantiaHipotecaria");

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
        public ContentResult RegistrarCuentaLiquidez()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/RegistrarCuentaLiquidez");

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
        public ContentResult RegistrarCuentaVivienda()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/RegistrarCuentaVivienda");

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
        [Route("CPM/Hipotecario/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoHipotecario()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/DesembolsarCredito");

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
        [Route("CPM/InmediatoConRendicuenta/[action]")]
        public ContentResult RegistrarGarantiaRendicuenta()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "InmediatoConRendicuenta/RegistrarGarantiaRendicuenta");

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
        [Route("CPM/InmediatoConRendicuenta/RegistrarCuenta")]
        public ContentResult RegistrarCuentaInmediatoConRendicuenta()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "InmediatoConRendicuenta/RegistrarCuenta");

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
        [Route("CPM/InmediatoConRendicuenta/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoInmediatoConRendicuenta()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "InmediatoConRendicuenta/DesembolsarCredito");

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
        [Route("CPM/PersonalPlus/RegistrarGarantiaPrendaria")]
        public ContentResult RegistrarGarantiaPrendariaPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "PersonalPlus/RegistrarGarantiaPrendaria");

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
        [Route("CPM/PersonalPlus/RegistrarGarantiaHipotecaria")]
        public ContentResult RegistrarGarantiaHipotecariaPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "PersonalPlus/RegistrarGarantiaPrendaria");

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
        [Route("CPM/Productivo/RegistrarGarantia")]
        public ContentResult RegistrarGarantiaProductivo()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Productivo/RegistrarGarantia");

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
        [Route("CPM/Productivo/RegistrarGarantiaPrendaria")]
        public ContentResult RegistrarGarantiaPrendariaProductivo()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Productivo/RegistrarGarantiaPrendaria");

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
        [Route("CPM/Productivo/RegistrarGarantiaHipotecaria")]
        public ContentResult RegistrarGarantiaHipotecariaProductivo()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Productivo/RegistrarGarantiaHipotecaria");

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
        [Route("CPM/Productivo/RegistrarCuenta")]
        public ContentResult ProductivoRegistrarCuenta()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Productivo/RegistrarCuenta");

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
        [Route("CPM/Productivo/DesembolsarCredito")]
        public ContentResult ProductivoDesembolsarCredito() 
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Productivo/RegistrarCuenta");

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
        public ContentResult RegistrarCuentaLiquidezPagoPersonalizado()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/RegistrarCuentaLiquidezPagoPersonalizado");

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
        public ContentResult RegistrarCuentaViviendaPagoPersonalizado()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/RegistrarCuentaViviendaPagoPersonalizado");

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
        [Route("CPM/Automotriz/[action]")]
        public ContentResult RegistrarCuentaPagoPersonalizado()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Automotriz/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/Automotriz/[action]")]
        public ContentResult RegistrarCuentaSeminuevoPagoPersonalizado()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Automotriz/RegistrarCuentaSeminuevoPagoPersonalizado");

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
        [Route("CPM/Inmediato/RegistrarCuentaPagoPersonalizado")]
        public ContentResult RegistrarCuentaPagoPersonalizadoInmediato()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Inmediato/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/Productivo/RegistrarCuentaPagoPersonalizado")]
        public ContentResult RegistrarCuentaPagoPersonalizadoProductivo()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Productivo/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/PersonalPlus/RegistrarCuentaPagoPersonalizado")]
        public ContentResult RegistrarCuentaPagoPersonalizadoPersonalPlus()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "PersonalPlus/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/Hipotecario/RegistrarCuentaViviendaInfonavit")]
        public ContentResult RegistrarCuentaViviendaInfonavit()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Hipotecario/RegistrarCuentaViviendaInfonavit");

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
        [Route("CPM/Estudiantil/RegistrarGarantiaHipotecaria")]
        public ContentResult RegistrarGarantiaHipotecariaEstudiantil()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Estudiantil/RegistrarGarantiaHipotecaria");

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
        [Route("CPM/Estudiantil/RegistrarCuenta")]
        public ContentResult RegistrarCuentaEstudiantil()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Estudiantil/RegistrarCuenta");

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
        [Route("CPM/Estudiantil/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoEstudiantil()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "Estudiantil/DesembolsarCredito");

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
        [Route("CPM/RenovacionConsumo/RegistrarGarantiaHipotecaria")]
        public ContentResult RenovacionConsumoGarantiaHipotecaria()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionConsumo/RegistrarGarantiaHipotecaria");

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
        [Route("CPM/RenovacionConsumo/RegistrarGarantiaPrendaria")]
        public ContentResult RenovacionConsumoGarantiaPrendaria()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionConsumo/RegistrarGarantiaPrendaria");

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
        [Route("CPM/RenovacionConsumo/RegistrarCuenta")]
        public ContentResult RenovacionConsumoCuenta()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionConsumo/RegistrarCuenta");

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
        [Route("CPM/RenovacionConsumo/RegistrarCuentaPagoPersonalizado")]
        public ContentResult RenovacionConsumoCuentaPagoPersonalizado()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionConsumo/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/RenovacionConsumo/DesembolsarCredito")]
        public ContentResult RenovacionConsumoDesembolsarCredito()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionConsumo/DesembolsarCredito");

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
        [Route("CPM/RenovacionHipotecario/RegistrarGarantiaPrendaria")]
        public ContentResult RenovacionHipotecarioGarantiaPrendaria()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionHipotecario/RegistrarGarantiaPrendaria");

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
        [Route("CPM/RenovacionHipotecario/RegistrarGarantiaHipotecaria")]
        public ContentResult RenovacionHipotecarioGarantiaHipotecaria()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionHipotecario/RegistrarGarantiaHipotecaria");

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
        [Route("CPM/RenovacionHipotecario/RegistrarCuenta")]
        public ContentResult RenovacionHipoteacrioCuenta()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionHipotecario/RegistrarCuenta");

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
        [Route("CPM/RenovacionHipotecario/RegistrarCuentaPagoPersonalizado")]
        public ContentResult RenovacionHipotecarioCuentaPagoPersonalizado()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionHipotecario/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/RenovacionHipotecario/DesembolsarCredito")]
        public ContentResult RenovacionHipotecarioDesembolsarCredito()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "RenovacionHipotecario/DesembolsarCredito");

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
        [Route("CPM/CosechandoCPM/RegistrarGarantiaHipotecaria")]
        public ContentResult RegistrarGarantiaHipotecariaCosechando()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "CosechandoCPM/RegistrarGarantiaHipotecaria");

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
        [Route("CPM/CosechandoCPM/RegistrarCuenta")]
        public ContentResult RegistrarCuentaCosechando()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "CosechandoCPM/RegistrarCuenta");

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
        [Route("CPM/CosechandoCPM/RegistrarCuentaPagoPersonalizado")]
        public ContentResult RegistrarCuentaPagoPersonalizadoCosechando()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "CosechandoCPM/RegistrarCuentaPagoPersonalizado");

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
        [Route("CPM/CosechandoCPM/DesembolsarCredito")]
        public ContentResult DesembolsarCreditoCosechando()
        {
            try
            {
                string jsonResult = _respuestasprocessor.ObtenerMensajeJson("ApiCreditosRegistroCRM", "CosechandoCPM/DesembolsarCredito");

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
