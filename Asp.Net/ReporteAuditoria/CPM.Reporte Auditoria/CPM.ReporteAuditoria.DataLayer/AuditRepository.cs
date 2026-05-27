using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Catalogos;
using CPM.ReporteAuditoria.BusinessType.Exceptions;
using CPM.ReporteAuditoria.DataInterface;
using CPM.ReporteAuditoria.DataLayer.Dynamics365;
using CPM.ReporteAuditoria.DataLayer.ExtensionMethods;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CPM.ReporteAuditoria.DataLayer
{
    public class AuditRepository : IAuditRepository
    {
        private readonly ServerConnection _connection;
        public AuditRepository(ServerConnection connection)
        {
            _connection = connection;

        }
        public string RecuperarTodasLasAuditorias(List<Guid> usuariosId, int tipoOperacion, int tipoEvento, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                List<Audit> auditorias = new List<Audit>();
                HashSet<Guid> procesados = new HashSet<Guid>();
                string pagingCookie = null;
                bool masRegistros = true;
                int numPagina = 1;
                int tamanioPagina = 1000;

                while (masRegistros)
                {
                    string fetchXml = FetchRecuperarAuditorias(usuariosId, tipoOperacion, tipoEvento, fechaInicio, fechaFin, pagingCookie, numPagina, tamanioPagina);
                    EntityCollection response = _connection.Service.RetrieveMultiple(new FetchExpression(fetchXml));
                    if (response?.Entities?.Any() == true)
                    {
                        foreach (var item in response.Entities)
                        {
                            var auditId = item.GetAttributeValue<Guid>("auditid");

                            // Evitar duplicados
                            if (!procesados.Add(auditId))
                                continue;
                            var objectId = item.GetLookUpValue(item, "objectid");
                            var user = item.GetLookUpValue(item, "userid");
                            var domainName = item.GetAliasedStringValue("usr.domainname");
                            var fullName = item.GetAliasedStringValue("usr.fullname");
                                auditorias.Add(new Audit
                                {
                                    UsuarioDominio = string.IsNullOrEmpty(domainName) ? user?.Name : domainName,
                                    UsuarioNombre = string.IsNullOrEmpty(fullName) ? user?.Name : fullName,
                                    FechaCreacion = item.GetDateTimeValue("createdon"),
                                    Nombre = objectId?.Name,
                                    TipoEvento = item.GetOptionSetValue("action"),
                                    TipoOperacion = item.GetOptionSetValue("operation"),
                                    ObjectId = item.GetLookUpValue(item, "objectid").Id.ToString(),
                                    TipoRegistro = objectId?.LogicalName
                                });
                        }
                    }

                    masRegistros = response.MoreRecords;
                    if (masRegistros)
                    {
                        pagingCookie = response.PagingCookie;
                        numPagina++;
                    }
                }

                _connection.Dispose();
                return JsonConvert.SerializeObject(auditorias);
            }
            catch (Exception ex)
            {
                throw new CrmExcepcion(ex);
            }
        }
        public BitacoraPaginado RecuperarAuditorias(Guid usuarioId, int tipoOperacion, int tipoEvento, string fechaCreacion, int paginaActual, int numeroElementos, Eventos eventos)
        {
            try
            {

                BitacoraPaginado bitacora = new BitacoraPaginado();
                EntityCollection response = _connection.Service.RetrieveMultiple(new FetchExpression(FetchAuditCRUD(usuarioId, tipoOperacion, tipoEvento, fechaCreacion, numeroElementos, paginaActual)));
                _connection.Dispose();
                if (response != null && response.Entities.Any())
                {
                    bitacora.Paginacion = new Pagination();
                    bitacora.Paginacion.CurrentPage = paginaActual;
                    bitacora.Paginacion.ItemByPage = numeroElementos;
                    bitacora.Paginacion.TotalItem = response.TotalRecordCount;
                    var paginas = bitacora.Paginacion.TotalItem / numeroElementos;
                    var mod = bitacora.Paginacion.TotalItem % numeroElementos;
                    if (mod != 0) { paginas = paginas + 1; }
                    bitacora.Paginacion.TotalPage = paginas;
                }
                return bitacora;
            }
            catch (Exception ex)
            {
                throw new CrmExcepcion(ex);
            }

        }
        public DetalleAudit ShowAuditDetail(Guid auditid)
        {
            ServerConnection cnx = new ServerConnection();
            RetrieveAuditDetailsRequest req =
                        new RetrieveAuditDetailsRequest
                        {
                            AuditId = auditid
                        };

            RetrieveAuditDetailsResponse resp =
                (RetrieveAuditDetailsResponse)cnx.Service.Execute(req);
            cnx.Dispose();
            DetalleAudit detalle = new DetalleAudit();
            DisplayAuditDetail(resp.AuditDetail, detalle);
            return detalle;
        }

        public BitacoraDetalleAudit ShowRetrieveRecordChangeHistory(string entityName, string registroId, int numeroPagina, int registrosPorPagina)
        {
            ServerConnection cnx = new ServerConnection();
            EntityReference record = new EntityReference(entityName, new Guid(registroId));
            BitacoraDetalleAudit bitacoraDetalle = new BitacoraDetalleAudit();
            var req = new RetrieveRecordChangeHistoryRequest
            {
                Target = record,
                PagingInfo = new PagingInfo
                {
                    PageNumber = numeroPagina,
                    Count = registrosPorPagina,
                    ReturnTotalRecordCount = true
                }
            };


            var resp = (RetrieveRecordChangeHistoryResponse)cnx.Service.Execute(req);

            var auditDetailCollection = resp.AuditDetailCollection;
            cnx.Dispose();
            int recordsReturned = auditDetailCollection.AuditDetails.Count;
            int totalRecords = auditDetailCollection.TotalRecordCount;
            bitacoraDetalle.Paginado = new Pagination();
            bitacoraDetalle.Paginado.ItemByPage = registrosPorPagina;
            bitacoraDetalle.Paginado.TotalItem = totalRecords;
            bitacoraDetalle.Paginado.CurrentPage = numeroPagina;

            var paginas = totalRecords / registrosPorPagina;
            var mod = bitacoraDetalle.Paginado.TotalItem % registrosPorPagina;
            if (mod != 0) { paginas = paginas + 1; }
            bitacoraDetalle.Paginado.TotalPage = paginas;

            //Console.WriteLine($"Retrieved {recordsReturned} of {totalRecords} auditdetail records.");
            bitacoraDetalle.Detalles = new List<DetalleAudit>();
            auditDetailCollection.AuditDetails.ToList().ForEach(x =>
            {

                Entity auditRecord = x.AuditRecord;

                DetalleAudit detalle = new DetalleAudit
                {
                    Fecha = $"{auditRecord.FormattedValues["createdon"]}",
                    CambiadoPor = $"{((EntityReference)auditRecord["userid"]).Name}",
                    Accion = $"{auditRecord.FormattedValues["action"]}",
                    Operacion = $"{auditRecord.FormattedValues["operation"]}",
                    EntityName = entityName,
                    IdRegistro = registroId

                };
                DisplayAuditDetail(auditDetail: x, detalle);

                bitacoraDetalle.Detalles.Add(detalle);

                //Console.WriteLine();
            });
            return bitacoraDetalle;
        }
        public string ObtenerNombreAMostrarEntidad(string logicalName)
        {
            ServerConnection cnx = new ServerConnection();
            var request = new RetrieveEntityRequest
            {
                LogicalName = logicalName,
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            var response = (RetrieveEntityResponse)cnx.Service.Execute(request);
            cnx.Dispose();
            return response.EntityMetadata.DisplayName?.UserLocalizedLabel?.Label ?? logicalName;

        }

       
        #region MetodosPrivados
       
        private string FetchAuditCRUD(Guid usuarioId, int tipoOperacion, int tipoEvento, string fechaCreacion, int numeroElementos, int paginaActual)
        {
            var condiciones = new List<string>();
            if (fechaCreacion != null)
            {
                condiciones.Add($@"<condition attribute='createdon' operator='on' value='{fechaCreacion:yyyy-MM-ddTHH:mm:ss}' />");
            }

            if (usuarioId != Guid.Empty)
            {
                condiciones.Add($@"<condition attribute='userid' operator='eq' value='{usuarioId}' />");
            }

            if (tipoEvento != -1 && tipoEvento != 0)
            {
                condiciones.Add($@"<condition attribute='action' operator='eq' value='{tipoEvento}'/>");
            }

            if (tipoOperacion != -1)
            {
                condiciones.Add($@"<condition attribute='operation' operator='eq' value='{tipoOperacion}' />");
            }

            var filtroXml = condiciones.Any()
                ? $"<filter type='and'>{string.Join("", condiciones)}</filter>"
                : string.Empty;

            var fetchXml = $@"
                  <fetch distinct='true' returntotalrecordcount='true' count='{numeroElementos}' page='{paginaActual}'>
                  <entity name='audit'>
                          <attribute name='operation'/>
		                  <attribute name='operation'/>
		                  <attribute name='operation'/>
		                  <attribute name='operation'/>
		                  <attribute name='operation'/>
		                  <attribute name='operation'/>
		                  <attribute name='objectid'/>
		                  <attribute name='transactionid'/>
		                  <attribute name='useradditionalinfo'/>
		                  <attribute name='auditid'/>
                          <attribute name='createdon'/>
		                  <attribute name='userid'/>
		                  <attribute name='regardingobjectid'/>
		                  <attribute name='action'/>
		                  <attribute name='callinguserid'/>
                    {filtroXml}
                  </entity>
                </fetch>";

            return fetchXml;
        }
        private string FetchRecuperarAuditorias(List<Guid> usuariosId, int tipoOperacion, int tipoEvento, DateTime? fechaInicio,DateTime? fechaFin, string paginCookie, int numPagina, int tamanioPagina)
        {
            var condiciones = new List<string>();
            string atributoARelacionar = "userid";

            if (fechaInicio.HasValue)
            {
                string fechaInicioStr = fechaInicio.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                condiciones.Add($"<condition attribute='createdon' operator='on-or-after' value='{fechaInicioStr}' />");
            }
            if (fechaFin.HasValue)
            {
                string fechaFinStr = fechaFin.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                condiciones.Add($"<condition attribute='createdon' operator='on-or-before' value='{fechaFinStr}' />");
            }
            if (usuariosId.Any() && !((tipoOperacion == 4 || tipoOperacion == -1) && (tipoEvento == 64 || tipoEvento == -1 || tipoEvento ==65)))
            {
                condiciones.Add(CrearCondicionIn("userid", usuariosId));
            }

            if (tipoEvento != -1)
            {
                condiciones.Add($"<condition attribute='action' operator='eq' value='{tipoEvento}' />");
            }

            //if (tipoEvento == 64)
            //{
            //    condiciones.Add(CrearCondicionIn("objectid", usuariosId));
            //}

            if (tipoOperacion != -1)
            {
                condiciones.Add($"<condition attribute='operation' operator='eq' value='{tipoOperacion}' />");
            }
            //Sí el tipo de operación es acceso se hará el link entity a systemuser mediante  objectid = systemuserid
            if (tipoOperacion == 4)
            {
                atributoARelacionar = "objectid";
            }
            if (tipoOperacion == 4 && usuariosId.Any())
            {
                condiciones.Add(CrearCondicionIn("objectid", usuariosId));
            }

            string filtroXml = condiciones.Any()
                ? $"<filter type='and'>{string.Join("", condiciones)}</filter>"
                : string.Empty;

            string cookieAttribute = string.IsNullOrEmpty(paginCookie)
                ? ""
                : $" paging-cookie='{System.Security.SecurityElement.Escape(paginCookie)}'";

            var fetchXml = $@"
            <fetch distinct='true' returntotalrecordcount='true' page='{numPagina}' count='{tamanioPagina}'{cookieAttribute}>
              <entity name='audit'>
                <attribute name='operation'/>
                <attribute name='objectid'/>
                <attribute name='transactionid'/>
                <attribute name='useradditionalinfo'/>
                <attribute name='auditid'/>
                <attribute name='createdon'/>
                <attribute name='userid'/>
                <attribute name='regardingobjectid'/>
                <attribute name='action'/>
                <attribute name='callinguserid'/>
                {filtroXml}
                <link-entity name='systemuser' from='systemuserid' to='{atributoARelacionar}' alias='usr'>
                <attribute name='domainname'/>
                <attribute name ='fullname'/>
                </link-entity>        
              </entity>
            </fetch>";

            return fetchXml;
        }
        private string CrearCondicionIn(string atributo, List<Guid> usuariosId)
        {
            if (usuariosId == null || !usuariosId.Any())
                return string.Empty;

            var valoresXml = string.Join("", usuariosId.Select(id => $"<value>{id}</value>"));
            return $"<condition attribute='{atributo}' operator='in'>{valoresXml}</condition>";
        }
        private DetalleAudit DisplayAuditDetail(AuditDetail auditDetail, DetalleAudit detalleAudit)
        {
            switch (auditDetail)
            {
                case AttributeAuditDetail aad:

                    Entity oldRecord = aad.OldValue;
                    Entity newRecord = aad.NewValue;
                    List<string> oldKeys = new List<string>();

                    //Look for changed or deleted values that are included in the OldValue collection
                    oldRecord.Attributes.Keys.ToList().ForEach(k =>
                    {
                        if (oldRecord.FormattedValues.Keys.Contains(k))
                        {
                            if (newRecord.FormattedValues.Contains(k))
                            {
                                detalleAudit.CampoCambiado = k;
                                detalleAudit.ValorAnterior = oldRecord.FormattedValues[k];
                                detalleAudit.NuevoValor = newRecord.FormattedValues[k];
                            }
                            else
                            {
                                detalleAudit.CampoCambiado = k;
                                detalleAudit.ValorAnterior = oldRecord.FormattedValues[k];
                            }
                        }
                        else
                        {
                            if (newRecord.Attributes.Keys.Contains(k))
                            {
                                detalleAudit.CampoCambiado = k;
                                detalleAudit.ValorAnterior = $"{oldRecord[k]}";
                                detalleAudit.NuevoValor = $"{newRecord[k]}";
                            }
                            else
                            {
                                detalleAudit.CampoCambiado = k;
                                detalleAudit.ValorAnterior = $"{oldRecord[k]}";
                            }
                        }

                        oldKeys.Add(k); //Add to list so we don't check again
                    });

                    //Look for New values that are only in the NewValues collection
                    newRecord.Attributes.Keys.ToList().ForEach(k =>
                    {
                        if (!oldKeys.Contains(k))//Exclude any keys for changed or deleted values
                        {
                            if (newRecord.FormattedValues.Keys.Contains(k))
                            {
                                detalleAudit.CampoCambiado = k;
                                detalleAudit.NuevoValor = newRecord.FormattedValues[k];
                            }
                            else
                            {
                                detalleAudit.CampoCambiado = k;
                                detalleAudit.NuevoValor = $"{newRecord[k]}";
                            }
                        }
                    });
                    break;

                case ShareAuditDetail sad:
                    detalleAudit.UsuarioRoles = $"{sad.Principal.Name}";
                    detalleAudit.RolesAnteriores.Add($"{sad.OldPrivileges}");
                    detalleAudit.NuevosRoles.Add($"{sad.NewPrivileges}");
                    break;

                //Applies to operations on N:N relationships
                case RelationshipAuditDetail rad:
                    detalleAudit.Relacion = ($"{rad.RelationshipName}");

                    rad.TargetRecords.ToList().ForEach(y =>
                    {
                        detalleAudit.Relacionados.Add(y.Name);
                    });

                    break;

                //Only applies to role record
                case RolePrivilegeAuditDetail rpad:

                    List<string> newRolePrivileges = new List<string>();
                    rpad.NewRolePrivileges.ToList().ForEach(y =>
                    {
                        if (y != null)
                        {
                            detalleAudit.NuevosRoles.Add(
                            $"Privilege Id{y.PrivilegeId} Depth:{y.Depth}");
                        }
                    });

                    List<string> oldRolePrivileges = new List<string>();
                    rpad.OldRolePrivileges.ToList().ForEach(y =>
                    {
                        if (y != null)
                        {
                            detalleAudit.RolesAnteriores.Add(
                            $"Privilege Id:{(y.PrivilegeId)} Depth:{y.Depth}");
                        }
                    });

                    List<string> invalidNewPrivileges = new List<string>();
                    rpad.InvalidNewPrivileges.ToList().ForEach(y =>
                    {
                        if (y != null)
                        {
                            detalleAudit.NuevosRolesInvalidos.Add(
                            $"Guid:{y}");
                        }
                    });

                    //Console.WriteLine($"\tNew Role Privileges:\n{string.Join(string.Empty, newRolePrivileges.ToArray())}");
                    //Console.WriteLine($"\tOld Role Privileges:\n{string.Join(string.Empty, oldRolePrivileges.ToArray())}");
                    //Console.WriteLine($"\tInvalid New Privileges:\n{string.Join(string.Empty, invalidNewPrivileges.ToArray())}"); ;
                    break;

                //Only applies for systemuser record
                case UserAccessAuditDetail uaad:
                    detalleAudit.HoraAcceso = $"Access Time:{uaad.AccessTime}";
                    detalleAudit.Intervalo = $"Interval:{uaad.Interval}";
                    break;
            }

            return detalleAudit;
        }

        public List<DetalleAudit> ShowRetrieveRecordChangeHistory(string entityName, string registroId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
