using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.ReporteAuditoria.BusinessType
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public Guid UsuarioId { get; set; }   
        public string DomainName { get; set; }
    }
}
