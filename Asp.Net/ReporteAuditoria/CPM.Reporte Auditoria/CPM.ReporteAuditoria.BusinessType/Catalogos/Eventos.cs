using System.Collections.Generic;

namespace CPM.ReporteAuditoria.BusinessType.Catalogos
{
    public class Eventos
    {
        //public Dictionary<string,int> Diccionario { get; set; }
        public static readonly Dictionary<int,string> DiccionarioEstatico = new Dictionary<int,string>
        {
            {1, "Crear"},
            {2, "Actualizar"},
            {3, "Eliminar"},
            {4, "Activar"},
            {5, "Desactivar"},
            {13, "Asignar"},
            {14, "Compartir"},
            {16, "Cerrar"},
            {17, "Cancelar"},
            {64, "Acceso de usuario mediante web"},
            {65, "Acceso de usuario mediante servicios web" }
        };
    }
}
