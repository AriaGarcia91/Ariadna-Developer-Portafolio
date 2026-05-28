using BG_CreacionDeOportunidad.BussinesType;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using System.Text;
using Microsoft.Crm.Sdk.Messages;

namespace BG_CreacionDeOportunidad.DataLayer
{
    public class CrmRepository
    {
        private readonly IOrganizationService _service;
        private readonly ITracingService _tracing;
        public CrmRepository(IOrganizationService service, ITracingService tracing)
        {
            _service = service;
            _tracing = tracing;
        }

        #region métodos públicos
        public Entity RecuperarCliente(string entity,string filtro,string campo,string identificacion)
        {
            Entity cliente = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarEntidadRelacionada(entity,filtro,campo,identificacion))).Entities.FirstOrDefault();
            return cliente;
        }
        public Guid RecuperarIdEntidad(string entidad, string filtro, string campo, string identificador)
        {
            if (string.IsNullOrEmpty(identificador))
                return Guid.Empty;

           var results = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarEntidadRelacionada(entidad, filtro, campo, identificador))).Entities;

            var entidadRecuperada = results.FirstOrDefault();
            if (entidadRecuperada == null)
            {
                _tracing.Trace($"No se encontró entidad relacionada: {entidad} con {filtro} = {identificador}");
                return Guid.Empty;
            }

            var id = entidadRecuperada.Id;
            _tracing.Trace($"Entidad relacionada: {entidad}, Guid: {id}");
            return id;
        }

        public Entity RecuperarProductoConMasa(string codigoProducto, string idMasa)
        {
            if (string.IsNullOrEmpty(codigoProducto))
            {
                _tracing.Trace("Código de producto es nulo o vacío.");
                return null;
            }
            var resultados = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarProducto(codigoProducto, idMasa))).Entities;

            var productoConMasa = resultados.FirstOrDefault();

            if (productoConMasa == null)
            {
                _tracing.Trace($"No se encontró producto con código: {codigoProducto}");
                return null;
            }

            _tracing.Trace($"Id Producto: {productoConMasa.Id}");
            return productoConMasa;
        }

        public Guid RecuperarCanal(string id)
        {
            _tracing.Trace($"El id del canal es: {id}");
            var results = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarCanal(id))).Entities;
            var canal = results.FirstOrDefault();
            if(canal== null)
            {
                _tracing.Trace($"No se encontró canal: {id}");
                return Guid.Empty;
            }
            _tracing.Trace($"El guid del canal es {canal.Id}");
            return canal.Id;
        }

        public Guid CrearOportunidad(OportunidadModel oportunidad, Entity cliente)
        {
            Entity entity = new Entity("opportunity");
            if(cliente.LogicalName == "lead")
            {
                entity["originatingleadid"] = new EntityReference(cliente.LogicalName,cliente.Id);
            }
            else
            {
                entity["rs_clienteid"] = new EntityReference(cliente.LogicalName, cliente.Id);
            }    
            //Datos Multicrédito
            entity["rs_afinidad"] = oportunidad.Afinidad;
            entity["budgetamount"] = new Money(oportunidad.MontoSolicitado);
            entity["rs_ingresomensual"] = new Money(oportunidad.MontoSolicitado);
            entity["rs_consolidacion"] = new Money(oportunidad.ConsolidacionDeDeuda);
            entity["rs_montototaldeuda"] = new Money(oportunidad.MontoTotalDeLaDeuda);
            entity["rs_montoconsolidar"] = new Money(oportunidad.MontoAConsolidar);
            entity["rs_valorpaqueteavisoseguro"] = new Money(oportunidad.ValorPaqueteAvisoSeguro);
            entity["rs_numerooperacion"] = oportunidad.NumeroDeOperacion;
            entity["rs_valororiginal"] = new Money(oportunidad.ValorOriginal);
            entity["rs_bin"] = oportunidad.Bin;
            entity["rs_nombretarjeta"] = oportunidad.NombreTarjeta;
            entity["rs_cupotarjeta"] = new Money(oportunidad.CupoTarjeta);
            entity["rs_cuposugeridoanalisiscredito"] = new Money(oportunidad.CupoSugeridoAnalisisCredito);
            _tracing.Trace("El Monto Solicitado es:" + oportunidad.MontoSolicitado);
            _tracing.Trace("El ingreso mensual es:" + oportunidad.IngresoMensual);

            //Entidades relacionadas
            //validacion que los guid no sean empty
            entity["rs_institucionid"] = new EntityReference("rs_institucion", oportunidad.InstitucionId);
            entity["rs_vendedorid"] = new EntityReference("rs_vendedor", oportunidad.VendedorId);
            entity["rs_productoid"] = new EntityReference("product",oportunidad.Producto.productoId);
            entity["rs_masaid"] = new EntityReference("rs_masaproducto", oportunidad.Producto.masaId);
            entity["rs_origen"] = new EntityReference("rs_origen",oportunidad.CanalId);
            entity["rs_periodicidad"] = new EntityReference("rs_periodicidad",oportunidad.PeriodicidadId);
            entity["rs_marcatarjeta"] = new EntityReference("rs_marcatrjeta",oportunidad.MarcaId);
            //entity["rs_tipotarjetadebito"] = new EntityReference("rs_tarjetadedebito", oportunidad.TipoTarjetaId);
            entity["rs_concesionarioid"] = new EntityReference("rs_concesionario", oportunidad.ConcesionarioId);
      
            //Conjunto de opciones
            entity["rs_tipocredito"] = new OptionSetValue(oportunidad.TipoCredito);
            entity["rs_plazo"] = new OptionSetValue(oportunidad.ValorPlazo);
            entity["rs_tipogarantia"] = new OptionSetValue(oportunidad.TipoGarantia);
            entity["rs_tipooperacion"] = new OptionSetValue(oportunidad.TipoOperacion);
            entity["rs_formaenvio"] = new OptionSetValue(oportunidad.FormaEnvioEC);          
            entity["rs_entregatarjeta"] = new OptionSetValue(oportunidad.EntregaDeTarjetaEn);
            entity["rs_tipotabla"] = new OptionSetValue(oportunidad.TipoDeTabla);
            _tracing.Trace($"TipoCreditoModel: {oportunidad.TipoCredito}, TipoGarantiaModel: {oportunidad.TipoGarantia}");
            _tracing.Trace($"TipoCredito: {entity["rs_tipocredito"]}, TipoGarantiaModel: {entity["rs_tipogarantia"]}");

            //Dos opciones
            entity["rs_retanqueo"] = oportunidad.Retanqueo;
            entity["rs_cuposugerido"] = oportunidad.CupoSugerido;
            entity["rs_deseaavisoseguro"] = oportunidad.DeseaAvisoSeguro;
            entity["rs_seguromicrocredito"] = oportunidad.SeguroMicrocredito;
            entity["rs_paqueteavisoseguro"] = oportunidad.PaqueteAvisoSeguro;
            entity["rs_digital"] = true; //Campo bandera indica que la oportunidad pertenece a un canal digital
            Guid idOportunidad = _service.Create(entity);
            _tracing.Trace($"La entidad es: {idOportunidad}");
            return idOportunidad;
        }
        public string RecuperarNumeroSolicitud(Guid idOportunidad)
        {
            _tracing.Trace($"El id de oportunidad es :{idOportunidad}");
            string numeroSolicitud = "";
            var results = _service.RetrieveMultiple(new FetchExpression(FetchRecuperarOportunidad(idOportunidad))).Entities;
            var oportunidad = results.FirstOrDefault();
            if(oportunidad != null)
            {
                numeroSolicitud = oportunidad.GetAttributeValue<string>("name");
            }
            _tracing.Trace($"El número de solicitud es:{numeroSolicitud}");
            return numeroSolicitud;
        }
        //Forma Nativa para descalificar un cliente potencial
        public void DescalificarClientePotencial(Guid clientePotencialId)
        {
            var setStateRequest = new SetStateRequest
            {
                EntityMoniker = new EntityReference("lead", clientePotencialId),
                State = new OptionSetValue(2),      
                Status = new OptionSetValue(4)
            };
            _service.Execute(setStateRequest);
        }
        #endregion

        #region métodos privados


        //Persona Natural : Contact
        private string FetchRecuperarEntidadRelacionada(string entity,string filtro,string campo,string identificacion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetch top='1'>");
            sb.Append($"<entity name='{entity}'>");
            sb.Append($"<attribute name='{campo}'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='{filtro}' operator='eq' value='{identificacion}'/>");
            sb.Append("</filter>");
            sb.Append("</entity>");
            sb.Append("</fetch>");
            return sb.ToString();
        }

        //Recupera el producto y la masa relacionada al mismo
        private string FetchRecuperarProducto(string codigoProducto, string idMasa)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetch top='1'>");
            sb.Append("<entity name='product'>");
            sb.Append("<attribute name='productid'/>");
            sb.Append("<attribute name='productnumber'/>");
            sb.Append($"<attribute name='rs_codigoproducto'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='rs_codigoproducto' operator='eq' value='{codigoProducto}'/>");
            sb.Append("</filter>");
            sb.Append("<link-entity name='rs_masaproducto' from='rs_masaproductoid' to='rs_masaid' link-type='outer' alias='masa'>");
            sb.Append("<attribute name='rs_id' alias='masa.rs_id'/>");
            sb.Append("<attribute name='rs_masaproductoid' alias='masa.rs_masaproductoid'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='rs_id' operator='eq' value='{idMasa}'/>");
            sb.Append("</filter>");
            sb.Append("</link-entity>");
            sb.Append("</entity>");
            sb.Append("</fetch>");
            return sb.ToString();
        }

        private string FetchRecuperarOportunidad(Guid idOportunidad)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetch>");
            sb.Append("<entity name='opportunity'>");
            sb.Append("<attribute name='name'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='opportunityid' operator='eq' value='{idOportunidad}'/>");
            sb.Append("</filter>");
            sb.Append("</entity>");
            sb.Append("</fetch>");
            return sb.ToString();
        }

        //rs_origen entida dy campo en oportunidad
        private string FetchRecuperarCanal(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<fetch>");
            sb.Append("<entity name='rs_origen'>");
            sb.Append("<attribute name='rs_id'/>");
            sb.Append("<attribute name='rs_origenid'/>");
            sb.Append("<filter>");
            sb.Append($"<condition attribute='rs_id' operator='eq' value='{id}'/>");
            sb.Append("</filter>");
            sb.Append("</entity>");
            sb.Append("</fetch>");
            return sb.ToString();
        }
        #endregion
    }
}
