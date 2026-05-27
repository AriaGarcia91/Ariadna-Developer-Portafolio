using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Exceptions;
using CPM.ReporteAuditoria.DataInterface;
using CPM.ReporteAuditoria.DataLayer.Dynamics365;
using CPM.ReporteAuditoria.DataLayer.ExtensionMethods;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPM.ReporteAuditoria.DataLayer
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ServerConnection cnx = new ServerConnection();
        public List<Usuario> RecuperarUsuariosCRM()
        {

            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                EntityCollection response = cnx.Service.RetrieveMultiple(new FetchExpression(FetchUsuarios()));

                if (response != null && response.Entities.Any())
                {
                    foreach (var item in response.Entities)
                    {
                        usuarios.Add(new Usuario
                        {
                            UsuarioId = item.GetGuidValue("systemuserid", false),
                            NombreUsuario = item.GetStringValue("fullname")
                            //                        NombreUsuario = string.IsNullOrWhiteSpace(item.GetStringValue("fullname"))
                            //                        ? item.GetStringValue("fullname")
                            //:                       item.GetStringValue("domainname")
                        });
                    }
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new CrmExcepcion(ex);
            }
        }

        public List<Usuario> RecuperarUsuariosPorOficina(Guid idOficina, int tipoOficina)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                EntityCollection response = cnx.Service.RetrieveMultiple(new FetchExpression(FetchUsuariosPorOficina(idOficina, tipoOficina)));
                if (response != null && response.Entities.Any())
                {
                    foreach (var item in response.Entities)
                    {
                        usuarios.Add(new Usuario
                        {
                            UsuarioId = item.GetGuidValue("systemuserid", false),
                            NombreUsuario = item.GetStringValue("fullname")
                        });
                    }
                }
                return usuarios;

            }
            catch (Exception ex)
            {

                throw new CrmExcepcion(ex);
            }
        }

        public List<Usuario> RecuperarUsuariosPorODG(Guid idOdg)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                EntityCollection response = cnx.Service.RetrieveMultiple(new FetchExpression(FetchUsuariosPorOdg(idOdg)));
                if (response != null && response.Entities.Any())
                {
                    foreach (var item in response.Entities)
                    {
                        usuarios.Add(new Usuario
                        {
                            UsuarioId = item.GetGuidValue("systemuserid", false),
                            NombreUsuario = item.GetStringValue("fullname")
                        });
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new CrmExcepcion(ex);
            }
        }

        #region MetodosPrivados
        private string FetchUsuariosPorOficina(Guid idOficina, int tipoOficina)
        {
            var filtroXml = tipoOficina == 4 ? $@"<filter>
                         <condition attribute='businessunitid' operator='eq' value='{idOficina}'/>
                       </filter>" : $@"<filter>
                         <condition attribute='parentbusinessunitid' operator='eq' value='{idOficina}'/>
                       </filter>";
            var fetchXml = $@"<fetch distinct='true'>
                   <entity name='systemuser'>
                     <attribute name='systemuserid'/>
                     <attribute name='domainname'/>
                     <attribute name='fullname' />
                     <link-entity name='businessunit' from='businessunitid' to='businessunitid' link-type='inner' alias='businessunit'>
                       {filtroXml}
                     </link-entity>
                   </entity>
                 </fetch>";
            return fetchXml;
        }

        private string FetchUsuariosPorOdg(Guid idOdg)
        {
            return $@"<fetch>
                  <entity name='systemuser'>
                    <attribute name='systemuserid' />
                    <attribute name='domainname' />
                    <attribute name='fullname' />
                    <link-entity name='businessunit' from='businessunitid' to='businessunitid' link-type='inner' alias='suc' intersect='true'>
                      <link-entity name='businessunit' from='businessunitid' to='parentbusinessunitid'>
                        <filter>
                          <condition attribute='parentbusinessunitid' operator='eq' value='{idOdg}' />
                        </filter>
                      </link-entity>
                    </link-entity>
                  </entity>
                </fetch>";
        }
        private string FetchUsuarios()
        {
            string fetch = $@"<fetch>
                <entity name='systemuser'>
                <attribute name='systemuserid' />
                <attribute name='domainname' />
                <attribute name='fullname' />
                </entity>
                </fetch>";
            return fetch;
        }
        #endregion
    }
}
