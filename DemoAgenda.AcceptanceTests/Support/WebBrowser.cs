using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using TechTalk.SpecFlow;

namespace DemoAgenda.AcceptanceTests.Support
{
    public static class WebBrowser
    {
        public static IE Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    string windowName = "Demo Agenda";
                    if (Browser.Exists<IE>(Find.ByTitle(windowName)))
                        ScenarioContext.Current["browser"] = Browser.AttachTo(typeof(IE), Find.ByTitle(windowName));
                    else
                        ScenarioContext.Current["browser"] = new IE();
                }
                return ScenarioContext.Current["browser"] as IE;
            }
        }
    }
}
