using CPM.ReporteAuditoria.BusinessType;
using System.Collections.Generic;


namespace CPM.ReporteAuditoria.Models
{
	public class ViewReporteAuditoriaModel
	{
        public List<Sucursal> Oficinas { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Dictionary<int, string> TipoOficinas{ get; set; }
        public Dictionary<int,string> Operaciones { get; set; }
        public Dictionary<int,string> Eventos { get; set; }
    }
}