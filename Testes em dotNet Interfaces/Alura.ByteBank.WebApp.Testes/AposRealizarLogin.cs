using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Utilitarios;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin:IDisposable, IClassFixture<Gerenciador>
    {
        private string servidor = "https://localhost:44309";
        private IWebElement Email;
        private IWebElement Senha;
        private IWebElement BotaoEntrar;
        ITestOutputHelper SaidaClasse;

        IWebDriver Driver;

        public AposRealizarLogin(ITestOutputHelper saidaConstrutor, Gerenciador gerenciador)
        {
            Driver = gerenciador.Driver;
            Driver.Navigate().GoToUrl(servidor);
            SaidaClasse = saidaConstrutor;
            var login = Driver.FindElement(By.LinkText("Login"));
            login.Click();
            Email = Driver.FindElement(By.Id("Email"));
            Senha = Driver.FindElement(By.Id("Senha"));
            BotaoEntrar = Driver.FindElement(By.Id("btn-logar"));
        }
        [Fact]
        public void AposRealizarLoginVerificarOpcaoAgenciasNoMenu()
        {
            var LoginPO = new LoginPO(Driver);
            LoginPO.PreencherCampoELogar("andre@email.com", "senha01");
            LoginPO.btnClick();

            Assert.Contains("Agência", Driver.PageSource);
          
        }
        [Fact]
        public void TentativaDeLoginComCamposVazios()
        {
            BotaoEntrar.Click();
            Assert.Contains("The Email field is required", Driver.PageSource);
            Assert.Contains("The Senha field is required", Driver.PageSource);
        }
        
        [Fact]
        public void TentativaLoginComSenhaInvalida()
        {
            Email.Click();
            Email.SendKeys("andre@email.com");
            Senha.Click();
            Senha.SendKeys("senha012");
            BotaoEntrar.Click();
            Assert.Contains("Login", Driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaListagemDeContas()
        {
            Email.Click();
            Email.SendKeys("andre@email.com");
            Senha.Click();
            Senha.SendKeys("senha01");

            BotaoEntrar.Click();
            Driver.FindElement(By.Id("contacorrente")).Click();

            IReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.TagName("a"));
            
            var elemento = (from webElemento in elements
                            where webElemento.Text.Contains("Detalhes")
                            select webElemento).First();
            elemento.Click();
            Assert.Contains("Voltar", Driver.PageSource);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
