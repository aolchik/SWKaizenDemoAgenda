using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAgenda.Models;
using DemoAgenda.UnitTests.Support;

namespace DemoAgenda.UnitTests.Models
{
    public static class EventoStub
    {
        public static Evento EventoValido()
        {
            return new Evento { Data = "22/10/2012" };
        }
    }


    [TestClass]
    public class EventoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Você deve informar a data.")]
        public void DeveTerData()
        {
            var evento = new Evento { Titulo = "Teste", Descricao = "Descricao do teste" };
            TestHelpers.ValidateObject(evento);
        }
    }
}
