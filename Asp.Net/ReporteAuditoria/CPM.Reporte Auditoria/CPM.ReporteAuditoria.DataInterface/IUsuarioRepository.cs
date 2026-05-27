using CPM.ReporteAuditoria.BusinessType;
using System;
using System.Collections.Generic;

namespace CPM.ReporteAuditoria.DataInterface
{
    public interface IUsuarioRepository
    {
        List<Usuario> RecuperarUsuariosCRM();
        List<Usuario> RecuperarUsuariosPorOficina(Guid idOficina, int tipoOficina);
        List<Usuario> RecuperarUsuariosPorODG(Guid idOdg);  

    }
}
