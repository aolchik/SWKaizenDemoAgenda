using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoAgenda.Models;

namespace DemoAgenda.Controllers
{
    public class HomeController : DemoAgendaController
    {
        public ActionResult Index()
        {
            Agenda agenda = new Agenda();

            ViewBag.Message = agenda.MensagemInicial();

            var eventList = context.Eventos.ToList();
            return View(eventList);
        }

        public ActionResult About()
        {
            return View();
        }    
    }
}
