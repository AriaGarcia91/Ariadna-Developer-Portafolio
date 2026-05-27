using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.DataLayer.Dynamics365;
using CPM.ReporteAuditoria.BusinessType.Exceptions;
using CPM.ReporteAuditoria.DataLayer.ExtensionMethods;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using CPM.ReporteAuditoria.DataInterface;

namespace CPM.ReporteAuditoria.DataLayer
{
    public class BusinessUnitRepository : IBusinessUnitRepository
    {
        ServerConnection cnx = new ServerConnection();
        public List<Sucursal> RecuperarOficinas(int tipoOficina)
        {
            try
            {
                List<Sucursal> oficinas = new List<Sucursal>();
                EntityCollection response = cnx.Service.RetrieveMultiple(new FetchExpression(FetchRecuperarUnidadesNegocioPorTipo(tipoOficina)));
                cnx.Dispose();
                if (response != null && response.Entities.Any())
                {
                    response.Entities.ToList().ForEach(oficina => oficinas.Add(new Sucursal { Id = oficina.GetGuidValue("businessunitid", false).ToString(), Nombre = oficina.GetStringValue("name"), NumeroOficina = oficina.GetStringValue("rs_numerooficina") }));
                }
                return oficinas;
            }
            catch (Exception ex)
            {

                throw new CrmExcepcion(ex);
            }
        }
 


        #region MetodosPrivados

        private string FetchRecuperarUnidadesNegocioPorTipo(int tipoOficina)
        {
            return $@"<fetch>
               <entity name='businessunit'>
                 <attribute name='rs_numero' />
                 <attribute name='businessunitid' />
                 <attribute name='parentbusinessunitid' />
                 <attribute name='name' />
                 <attribute name='rs_numerooficina' />
                 <filter>
                   <condition attribute='rs_tipooficina' operator='eq' value='{tipoOficina}'/>
                 </filter>
               </entity>
             </fetch>";
        }

        private string FetchRecuperarSucursales(string oficinaPadreId)
        {
            string fetch = $@"<fetch>
  <entity name='businessunit'>
    <attribute name='rs_numero' />
    <attribute name='businessunitid' />
    <attribute name='name' />
    <filter>
      <condition attribute='rs_tipooficina' operator='eq' value='4' />
      <condition attribute='parentbusinessunitid' operator='eq' value='{oficinaPadreId}' />
    </filter>
  </entity>
</fetch>";

            return fetch;
        }
        private string FetchRecuperarPlazas()
        {
            string fetchPlaza = $@"<fetch>
  <entity name='businessunit'>
    <attribute name='rs_numero' />
    <attribute name='businessunitid' />
    <attribute name='name' />
    <attribute name='rs_numerooficina' />
    <filter>
      <condition attribute='rs_tipooficina' operator='eq' value='3' />
    </filter>
  </entity>
</fetch>";
            return fetchPlaza;
        }


        #endregion
    }
}
