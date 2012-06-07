using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;
using DemoAgenda.AcceptanceTests.Support;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DemoAgenda.AcceptanceTests.Steps
{
    [Binding]
    public class InitialSteps
    {

        [Given(@"que estou n[oa] '(.*)'")]
        public void DadoQueEstouEm(string nomePagina)
        {
            switch (nomePagina)
            {
                case "página principal":
                    WebBrowser.Current.GoTo(URLs.baseURL);
                    break;

                case "formulário de Novo evento":
                    WebBrowser.Current.GoTo(URLs.novoEvento);
                    break;

                default:
                    Assert.Fail(string.Format("Não foi possível encontrat a página {0} na página", nomePagina));
                    break;
            }
        }

        [When(@"eu clicar em '(.*)'")]
        public void QuandoEuClicarEm(string textoLinkBotao)
        {
            var link = WebBrowser.Current.Link(Find.ByText(textoLinkBotao));
            if (!link.Exists)
            {
                var button = WebBrowser.Current.Button(Find.ByValue(textoLinkBotao));
                if (!button.Exists)
                    Assert.Fail(string.Format("Não foi possível encontrat o link/botão {0} na página", textoLinkBotao));
                else
                    button.Click();
            } else
                link.Click();
        }

        [Then(@"devo ser redirecionado para o formulário de '(.*)'")]
        public void EntaoDevoSerRedirecionadoParaOFormularioDe(string textoFormulario)
        {
            Assert.IsTrue(WebBrowser.Current.ContainsText(textoFormulario));
        }

        [Then(@"o seguinte formulário deve ser exibido")]
        public void EntaoOSeguinteFormularioDeveSerExibido(TechTalk.SpecFlow.Table campos)
        {
            foreach (var campo in campos.Rows)
            {
                var nomeCampo = campo["Rótulo"];

                var textField = WebBrowser.Current.TextField(Find.ByName(nomeCampo));
                Assert.IsTrue(textField.Exists,
                  string.Format(
                    "Não foi possível encontrar o campo {0} na página", nomeCampo));
            }
        }

        [When(@"preencher os campos da seguinte forma")]
        public void QuandoPreencherOsCamposDaSeguinteForma(TechTalk.SpecFlow.Table valoresAPreencher)
        {
            foreach (var rotuloValor in valoresAPreencher.Rows)
            {
                var rotulo = rotuloValor["Rótulo"];
                var valor = rotuloValor["Valor"];

                var field = WebBrowser.Current.TextField(Find.ByName(rotulo));
                if (!field.Exists)
                    Assert.Fail("Não foi possível encontrar o campo {0} na página", rotulo);
                field.TypeText(valor);
            }
        }

        [Then(@"o evento deve ser armazenado no sistema")]
        public void EntaoOEventoDeveSerArmazenadoNoSistema()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"devo ver a mensagem 'Bom dia!'")]
        public void EntaoDevoVerBomDia()
        {
            var textExists = WebBrowser.Current.ContainsText("Bom dia!");
            Assert.IsTrue(textExists); 
        }

    }
}