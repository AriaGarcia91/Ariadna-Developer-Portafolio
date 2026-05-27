using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.ReporteAuditoria.BusinessType
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalItem { get; set; }
        public int ItemByPage { get; set; }
    }
}
