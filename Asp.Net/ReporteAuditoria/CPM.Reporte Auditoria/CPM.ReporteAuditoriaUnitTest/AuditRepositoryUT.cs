using CPM.ReporteAuditoria.BusinessType;
using CPM.ReporteAuditoria.BusinessType.Catalogos;
using CPM.ReporteAuditoria.DataInterface;
using CPM.ReporteAuditoria.DataLayer;
using CPM.ReporteAuditoria.DataLayer.Dynamics365;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CPM.ReporteAuditoriaUnitTest
{
    [TestClass]
    public class AuditRepositoryUT
    {
        IAuditRepository _auditRepo = default;
        [TestInitialize]
        public void TestInitialize()
        {
            ServerConnection _connection = new ServerConnection();
            _auditRepo = new AuditRepository(_connection);

        }

        [TestMethod]
        public void RecuperarAuditorias()
        {
            //Arrange
            List<Guid> usuariosId = new List<Guid>();
            usuariosId.Add(new Guid("4906752A-9227-EE11-A811-002248AC5D97"));
            int tipoOperacion = 2;
            int tipoEvento = 2;
            string fecha = "2025/08/06";

            //Act
            //string auditorias = _auditRepo.RecuperarTodasLasAuditorias(usuariosId, tipoOperacion, tipoEvento, fecha);
            //Assert
            //Assert.IsNotNull(auditorias);
        }

        [TestMethod]
        public void DetalleAuditoria()
        {

            //Arragnge
            string entityName = "rs_oportunidadsei";
            string registroId = "DD5C6D9D-2893-EF11-A990-002248AC5D97";
            //Act
            List<DetalleAudit> detalles = _auditRepo.ShowRetrieveRecordChangeHistory(entityName, registroId);
            //Assert
        }
    }
}
