using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.DataInterface;
using CPM.ReporteAuditoria.DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CPM.ReporteAuditoriaUnitTest
{
    [TestClass]
    public class BusinessUnitRepositoryUT
    {
        IBusinessUnitRepository _businessUnitRepository = default;

        [TestInitialize]
        public void TestInitialize()
        {
            _businessUnitRepository = new BusinessUnitRepository();
        }

        [TestMethod]
        public void RecuperarOficinas()
        {
            //Arrange
            int tipoOficina = 3;
            //Act
            List<Sucursal> oficinas = _businessUnitRepository.RecuperarOficinas(tipoOficina);
            //Assert
            Assert.IsNotNull(oficinas);
        }
    }
}
