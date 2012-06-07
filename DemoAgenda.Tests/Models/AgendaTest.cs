using DemoAgenda.Models;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoAgenda.UnitTests.Models
{
    [TestClass]
    public class Quando_chamando_mensagemInicial
    {
        public Quando_chamando_mensagemInicial()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private String textoBomDia = "Bom dia";
        private Agenda agenda = null;        

        [TestInitialize()]
        public void TestSetup()
        {
            agenda = new Agenda();
        }

        [TestMethod]
        public void Deve_retornar_Bom_dia()
        {
            // Arrange
            String mensagem = null;

            // Act
            mensagem = agenda.MensagemInicial();

            // Assert
            StringAssert.Matches(mensagem, new Regex(textoBomDia + "!"));
        }

        [TestMethod]
        public void Deve_retornar_Bom_dia_mais_texto_parametrizavel()
        {
            // Arrange
            String mensagem = null;
            String textoParametrizavel = "Alejandro";

            // Act
            mensagem = agenda.MensagemInicial(textoParametrizavel);

            // Assert
            StringAssert.Matches(mensagem, new Regex(textoBomDia + " " + textoParametrizavel + "!"));
        }

    }
}
