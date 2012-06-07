using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAgenda.Controllers
{
    public abstract class DemoAgendaController : Controller
    {
        protected IStoreContext context;

        public DemoAgendaController()
        {
            this.context = new StoreContext();
        }

        public DemoAgendaController( IStoreContext sc )
        {
            this.context = sc;
        }
    }
}
