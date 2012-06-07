using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace DemoAgenda.AcceptanceTests.Support
{

    public class URLs
    {
        public static string baseURL = ConfigurationSettings.AppSettings["AppUrl"];
        public static string novoEvento = baseURL + "Evento/Create";
    }
}
