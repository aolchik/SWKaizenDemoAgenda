using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAgenda;
using DemoAgenda.Controllers;

namespace DemoAgenda.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;

        [TestInitialize]
        public void SetUp()
        {
            // Arrange
            controller = new HomeController();

        }

        [TestMethod]
        public void Get_Index_Should_Return_Welcome_Message()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.Message);
        }

        public void Get_Index_Should_Return_List_Of_Events()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Fail();
        }


        [TestMethod]
        public void Get_About_Should_Return_A_View()
        {
            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
