using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoAgenda.Models;
using System.Data.Entity;

namespace DemoAgenda.Controllers
{
    public class EventoController : DemoAgendaController
    {
        public EventoController(IStoreContext context) : base(context) { }
        public EventoController() : base() { }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            ViewBag.Message = "Novo evento";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                context.Eventos.Add(evento);
                context.SaveChanges();
                return View("Obrigado", evento);
            }
            else
            {
                ViewBag.Message = "Novo evento (por favor corrija os erros!)";
                return View();
            }
        }

    }
}
