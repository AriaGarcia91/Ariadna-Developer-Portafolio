using System.Collections.Generic;


namespace CPM.ReporteAuditoria.BusinessType
{
    public class DetalleAudit
    {
        public string IdRegistro { get; set; }
        public string EntityName { get; set; }
        public string Fecha { get; set; }
        public string CambiadoPor { get; set; }
        public string Evento { get; set; }
        public string CampoCambiado { get; set; }
        public string Accion { get; set; }
        public string Operacion { get; set; }
        public string ValorAnterior { get; set; }
        public string NuevoValor { get; set; }
        public string UsuarioRoles { get; set; }
        public List<string> RolesAnteriores { get; set; } = new List<string>();
        public List<string> NuevosRoles { get; set; } = new List<string>();
        public List<string> NuevosRolesInvalidos { get; set; } = new List<string>();
        public string Relacion { get; set; }
        public string HoraAcceso { get; set; }
        public string Intervalo { get; set; }
        public List<string> Relacionados { get; set; } = new List<string>();
    }
}
