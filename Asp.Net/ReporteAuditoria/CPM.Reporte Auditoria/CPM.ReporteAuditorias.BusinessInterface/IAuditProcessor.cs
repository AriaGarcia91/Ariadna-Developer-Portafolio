using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Catalogos;
using System;
using System.Collections.Generic;

namespace CPM.ReporteAuditoria.BusinessInterface
{
    public interface IAuditProcessor
    {
        BitacoraPaginado RecuperarAuditorias(Guid usuarioId, int tipoOperacion, int tipoEvento, int paginaActual, int numeroElementos, Eventos eventos, string fechaCreacion);
        BitacoraDetalleAudit RecuperarDetalleAuditoria(string entityName, string registroId, int paginaActual, int numeroElementos);
        string RecuperarTodasLasAuditorias(List<Guid> usuariosId, int tipoOperacion, int tipoEvento, DateTime? fechaInicio, DateTime? fechaFin);
        List<Audit> FormarListadoAuditorias(string auditoriasJson);
        void RefrescarEventosAudit();
    }
}
