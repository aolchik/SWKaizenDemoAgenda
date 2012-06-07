using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAgenda;
using DemoAgenda.Controllers;
using DemoAgenda.Models;
using DemoAgenda.UnitTests.Models;
using MvcContrib;
using MvcContrib.TestHelper;
using Rhino.Mocks;

namespace DemoAgenda.UnitTests.Controllers
{
    [TestClass]
    public class CreateEventoControllerTest
    {
        private EventoController controller;
        private MockRepository mocks;
        private IStoreContext mockStoreContext;

        [TestInitialize]
        public void SetUp()
        {
            // Arrange
            mocks = new MockRepository();
            mockStoreContext = mocks.StrictMock<IStoreContext>();
            controller = new EventoController(mockStoreContext);
        }

        [TestMethod]
        public void Get_Deve_Retorar_Uma_View()
        {
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_Deve_Retorar_Título()
        {
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.Message);
        }

        [TestMethod]
        public void Post_Deve_Retorar_View()
        {
            // Act
            ViewResult result = controller.Create(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post_Deve_Retornar_View_Obrigado_Quando_Com_Sucesso()
        {
            // Arrange
            var eventoDummy = EventoStub.EventoValido() as Evento;
            const string expectedViewName = "Obrigado";

            // Act
            ViewResult result = controller.Create(eventoDummy) as ViewResult;

            // Assert
            result.AssertViewRendered().ForView(expectedViewName);
        }

        [TestMethod]
        public void Post_Deve_Retornar_View_Novo_Evento_Quando_Com_Falha()
        {
            // Arrange
            var eventoDummy = EventoStub.EventoValido() as Evento;
            const string expectedViewName = "";
            controller.ModelState.AddModelError("Um Erro", "Mensagem");

            // Act
            ViewResult result = controller.Create(eventoDummy) as ViewResult;

            // Assert
            result.AssertViewRendered().ForView(expectedViewName);
            Assert.IsNotNull(result.ViewBag.Message);
        }

        [TestMethod]
        public void Post_Deve_Salvar_Evento_Quando_Com_Sucesso()
        {
            // Arrange
            var eventoDummy = EventoStub.EventoValido() as Evento;

            Expect.Call(delegate { mockStoreContext.Eventos.Add(eventoDummy); });
            Expect.Call(mockStoreContext.SaveChanges()).Return(1);
            mocks.ReplayAll();

            // Act
            ViewResult result = controller.Create(eventoDummy) as ViewResult;

            // Assert
            mocks.VerifyAll();
        }

    
    }
}
