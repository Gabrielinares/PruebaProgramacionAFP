using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using Business.Services.Depto;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Tests
{
    [TestClass()]
    public class EmpresaControllerTests
    {
        Mock<IEmpresaService> empresaService = new Mock<IEmpresaService>();

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            EmpresaController controller = new EmpresaController(empresaService.Object);
            Empresa empresa = new Empresa();
            empresa.Nombre = "AES";
            empresa.RazonSocial = "AES Corporation";
            empresa.FecRegistro = DateTime.Now;
            empresa.DetalleBitacora = "Creacion de la empresa AES";
            empresa.Estado = "A";

            // Act
            var result = controller.Add(empresa);

            // Assert
            var objectResult = (ObjectResult)result.Result;
            Assert.AreEqual(201, objectResult.StatusCode);
        }

        [TestMethod()]
        public void GetIdTest()
        {
            // Arrange
            empresaService.Setup(x => x.GetEmpresaId(It.IsAny<int>())).Returns(new Empresa());
            EmpresaController controller = new EmpresaController(empresaService.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            var objectResult = (ObjectResult)result.Result;
            Assert.IsInstanceOfType(objectResult, typeof(OkObjectResult));
        }
    }
}