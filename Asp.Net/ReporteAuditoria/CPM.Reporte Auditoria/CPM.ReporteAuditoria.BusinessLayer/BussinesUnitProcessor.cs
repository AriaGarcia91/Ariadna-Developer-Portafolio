using CPM.ReporteAuditoria.BusinessInterface;
using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.DataInterface;
using System;
using System.Collections.Generic;

namespace CPM.ReporteAuditoria.BusinessLayer
{
    public class BussinesUnitProcessor:IBusinessUnitProcessor
    {
        private readonly IBusinessUnitRepository _oficinasRepository;

        public BussinesUnitProcessor(IBusinessUnitRepository businessUnitRepository)
        {
            _oficinasRepository = businessUnitRepository;
        }

        public List<Sucursal> RecuperarOficinas(int tipoOficina)
        {
            List<Sucursal> oficinas = _oficinasRepository.RecuperarOficinas(tipoOficina);
            return oficinas;
        }
    }
}
