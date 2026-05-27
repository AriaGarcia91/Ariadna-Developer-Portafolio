using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.ReporteAuditoria.BusinessType.Catalogos
{
    public class Operaciones
    {
        public static readonly Dictionary<int,string> Diccionario = new Dictionary<int,string>
        {
            {1, "Crear"},
            {2, "Actualizar"},
            {3, "Eliminar"},
            {4, "Acceso"}
        };
    }
}
