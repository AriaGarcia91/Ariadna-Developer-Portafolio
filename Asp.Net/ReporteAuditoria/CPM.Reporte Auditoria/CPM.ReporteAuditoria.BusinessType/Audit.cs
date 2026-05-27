

using System;

namespace CPM.ReporteAuditoria.BusinessType
{
    public class Audit
    {
        public Guid AuditId { get; set; }
        public string TipoRegistro { get; set; }
        public string ObjectId { get; set; }
        public string Nombre { get; set; }
        public string UsuarioDominio { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Operacion { get; set; }
        public string Evento {get;set;}
        public int TipoOperacion { get; set; }
        public int TipoEvento { get; set; }
    }
}
