using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using System.Text;


namespace BG_CreacionTablaAmortizacion.DataLayer
{
    public class CrmRepository
    {
        private readonly ITracingService _tracing;
        private readonly IOrganizationService _service;

        public CrmRepository(ITracingService tracing, IOrganizationService service)
        {
            _tracing = tracing;
            _service = service;
        }
        public string RecuperarSimuladorJson(Guid idOportunidad)
        {
            string jsonSimulador = "";
            var resultados = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarSimuladorJson(idOportunidad)));
            if (resultados != null && resultados.Entities.Count > 0)
            {
                var entity = resultados.Entities.FirstOrDefault();
                jsonSimulador = entity.GetAttributeValue<string>("rs_tablasimulador");
            }
            _tracing.Trace($"Recuperando respuesta simulador:{jsonSimulador}");
            return jsonSimulador;
        }

        public Guid CrearNotaAmortizacionPdf(Guid idOportunidad, string documentBody)
        {
            Entity entity = new Entity("annotation");
            entity["filename"] = $"TablaAmortizacion.pdf";
            entity["objectid"] = new EntityReference("opportunity", idOportunidad);
            entity["subject"] = $"Tabla de amortización";
            entity["notetext"] = "Tabla de amortización derivada de simulación crédito en oportunidad";
            entity["mimetype"] = "application/pdf";
            entity["documentbody"] = documentBody;
            entity["isdocument"] = true;

            return _service.Create(entity);
        }

        public string RecuperarTipoTablaTexto(Guid idOportunidad)
        {
            var entity = _service.Retrieve(
                "opportunity",
                idOportunidad,
                new ColumnSet("rs_tipotabla")
            );

            var option = entity.GetAttributeValue<OptionSetValue>("rs_tipotabla");

            if (option == null)
                return string.Empty;

            // Mapear valores conocidos
            switch (option.Value)
            {
                case 0:
                    return "Francesa";
                case 1:
                    return "Alemana";
                default:
                    return string.Empty;
            }
        }


        public string RecuperarPeriodicidadNombre(Guid idOportunidad)
        {
            var entity = _service.Retrieve(
                "opportunity",
                idOportunidad,
                new ColumnSet("rs_periodicidad")
            );

            var periodicidad = entity.GetAttributeValue<EntityReference>("rs_periodicidad");

            return periodicidad?.Name ?? string.Empty;
        }

        public string RecuperarPlazoLabel(Guid idOportunidad)
        {
            var entity = _service.Retrieve(
                "opportunity",
                idOportunidad,
                new ColumnSet("rs_plazo")
            );

            var optionSetValue = entity.GetAttributeValue<OptionSetValue>("rs_plazo");

            if (optionSetValue == null)
                return string.Empty;

            return ObtenerOptionSetLabel(
                "opportunity",
                "rs_plazo",
                optionSetValue.Value
            );
        }

        public byte[] ObtenerPlantillaPdf(string nombrePlantilla)
        {
            var resultados = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarPlantilla(nombrePlantilla))).Entities;

            if (resultados != null && resultados.Count > 0)
            {
                var entity = resultados.FirstOrDefault();
                var base64Contenido = entity.GetAttributeValue<string>("documentbody");

                if (!string.IsNullOrEmpty(base64Contenido))
                {
                    return Convert.FromBase64String(base64Contenido);
                }
            }
            return null;
        }


        #region métodos privados
        private string FetchRecuperarSimuladorJson(Guid idOportunidad)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetch top='50'>");
            sb.Append("<entity name='opportunity'>");
            sb.Append("<attribute name='rs_tablasimulador'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='opportunityid' operator='eq' value='{idOportunidad}'/>");
            sb.Append("</filter>");
            sb.Append("</entity>");
            sb.Append("</fetch>");
            return sb.ToString();
        }

        private string FetchRecuperarPlantilla(string nombrePlantilla)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetch>");
            sb.Append("<entity name='annotation'>");
            sb.Append("<attribute name='annotationid'/>");
            sb.Append("<attribute name='documentbody'/>");
            sb.Append("<attribute name='filename'/>");
            sb.Append("<attribute name='mimetype'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='filename' operator='eq' value='{nombrePlantilla}'/>");
            sb.Append("</filter>");
            sb.Append("</entity>");
            sb.Append("</fetch>");
            return sb.ToString();
        }

        private string ObtenerOptionSetLabel(string entityLogicalName, string attributeLogicalName, int value)
        {
            var request = new RetrieveAttributeRequest
            {
                EntityLogicalName = entityLogicalName,
                LogicalName = attributeLogicalName,
                RetrieveAsIfPublished = true
            };

            var response = (RetrieveAttributeResponse)_service.Execute(request);

            var attributeMetadata = (PicklistAttributeMetadata)response.AttributeMetadata;

            var option = attributeMetadata.OptionSet.Options
                .FirstOrDefault(o => o.Value == value);

            return option?.Label?.UserLocalizedLabel?.Label ?? string.Empty;
        }

        #endregion
    }
}