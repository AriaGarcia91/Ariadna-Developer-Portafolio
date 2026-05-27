using CPM.ReporteAuditoria.DataInterface;
using CPM.ReporteAuditoria.DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CPM.ReporteAuditoriaUnitTest
{
	[TestClass]
	public class UsuarioRepositoryUT
	{
		IUsuarioRepository _usuarioRepository;

		[TestInitialize]
        public void TestInitialize()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [TestMethod]
        public void RecuperarUsuariosPorOficina()
        {
            //Arrange
            Guid idOficina = new Guid("57ff742a-9227-ee11-a811-002248ac5d97");
            //Act
            var usuarios = _usuarioRepository.RecuperarUsuariosPorOficina(idOficina , 1);
            //Assert
            Assert.IsNotNull(usuarios);
        }
    }
}
