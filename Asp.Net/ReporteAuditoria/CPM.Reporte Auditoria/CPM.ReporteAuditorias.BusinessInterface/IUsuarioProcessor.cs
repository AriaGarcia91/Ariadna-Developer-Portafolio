using CPM.ReporteAuditoria.BusinessType;
using System;
using System.Collections.Generic;

namespace CPM.ReporteAuditoria.BusinessInterface
{
    public interface IUsuarioProcessor
    {
        List<Usuario> RecuperarUsuariosPorOficina(Guid idOficina, int tipoOficina);
        List<Usuario> RecuperarUsuariosPorODG(Guid idOficina);
    }
}
