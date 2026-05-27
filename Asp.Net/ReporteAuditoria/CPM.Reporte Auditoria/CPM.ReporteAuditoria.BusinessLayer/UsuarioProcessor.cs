using CPM.ReporteAuditoria.BusinessInterface;
using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.DataInterface;
using System;
using System.Collections.Generic;


namespace CPM.ReporteAuditoria.BusinessLayer
{
    public class UsuarioProcessor:IUsuarioProcessor
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioProcessor(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public List<Usuario> RecuperarUsuariosPorOficina(Guid idOficina, int tipoOficina)
        {
            List<Usuario> usuarios = _usuarioRepository.RecuperarUsuariosPorOficina(idOficina, tipoOficina);
            return usuarios;
        }

        public List<Usuario> RecuperarUsuariosPorODG(Guid idOficina)
        {
            List<Usuario> usuarios = _usuarioRepository.RecuperarUsuariosPorODG(idOficina);
            return usuarios;
        }
    }
}
