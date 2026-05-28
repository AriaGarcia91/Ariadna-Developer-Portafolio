using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_CreacionTablaAmortizacion.BussinesType
{
    public class OportunidadModel
    {
        public Guid Id { get; set; }
        public string NombreCliente { get; set; }

        public String TipoTabla { get; set; }

        public string Periodicidad { get; set; }

        public string Plazo { get; set; }
    }
}
