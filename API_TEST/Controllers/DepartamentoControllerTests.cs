using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Business.Services.Depto;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Tests
{
    [TestClass()]
    public class DepartamentoControllerTests
    {
        Mock<IDepartamentoService> departamentoService = new Mock<IDepartamentoService>();

        Mock<IEmpresaService> empresaService = new Mock<IEmpresaService>();

        [TestMethod]
        public void addDepartamentoTest()
        {
            // Arrange
            empresaService.Setup(x => x.GetEmpresaId(It.IsAny<int>())).Returns(new Empresa());
            DepartamentoController controller = new DepartamentoController(departamentoService.Object, empresaService.Object);
            Departamento departamento = new Departamento();
            departamento.Id = 1;
            departamento.Nombre = "Departamento 1";
            departamento.IdEmpresa = 0;
            departamento.NumeroEmpleados = 10;
            departamento.NivelOrganizacion = "Nivel 1";
            departamento.Estado = "A";

            // Act
            var result = controller.Add(departamento);

            // Assert
            var objectResult = (ObjectResult)result.Result;
            Assert.AreEqual(201, objectResult.StatusCode);
        }

        [TestMethod()]
        public void getDepartamentoIdTest()
        {
            // Arrange
            empresaService.Setup(x => x.GetEmpresaId(It.IsAny<int>())).Returns(new Empresa());
            departamentoService.Setup(x => x.GetDepartamentoId(It.IsAny<int>())).Returns(new Departamento());
            DepartamentoController controller = new DepartamentoController(departamentoService.Object, empresaService.Object);
            int id = 1;

            // Act
            var result = controller.Get(id);

            // Assert
            var objectResult = (ObjectResult)result.Result;
            Assert.IsInstanceOfType(objectResult, typeof(OkObjectResult));
        }

    }
}