using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Catalogos;
using System;
using System.Collections.Generic;


namespace CPM.ReporteAuditoria.DataInterface
{
    public interface IAuditRepository
    {
        
        string RecuperarTodasLasAuditorias(List<Guid> usuariosId, int tipoOperacion, int tipoEvento, DateTime? fechaInicio, DateTime? fechaFin);
        string ObtenerNombreAMostrarEntidad(string logicalName);
        BitacoraPaginado RecuperarAuditorias(Guid usuarioId, int tipoOperacion, int tipoEvento, string fechaCreacion, int paginaActual, int numeroElementos, Eventos eventos);
        //Eventos RecuperarEventos();
        DetalleAudit ShowAuditDetail(Guid auditid);
        BitacoraDetalleAudit ShowRetrieveRecordChangeHistory(string entityName, string registroId, int paginaActual, int numeroElementos);
        List<DetalleAudit> ShowRetrieveRecordChangeHistory(string entityName, string registroId);
   
    }
}
