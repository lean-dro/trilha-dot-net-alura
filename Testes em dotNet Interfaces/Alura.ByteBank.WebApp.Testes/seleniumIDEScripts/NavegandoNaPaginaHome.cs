using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes.seleniumIDEScripts
{


    public class NavegandoNaPaginaHome : IDisposable
    {
        private string servidor = "https://localhost:44309";
        ITestOutputHelper SaidaClasse;
        static FirefoxOptions Configuracoes = new FirefoxOptions
        {
            AcceptInsecureCertificates = true
        };
        IWebDriver Driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Configuracoes);

        public NavegandoNaPaginaHome(ITestOutputHelper saidaConstrutor)
        {

            SaidaClasse = saidaConstrutor;

        }

        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {

            //Act

            Driver.Navigate().GoToUrl("https://localhost:44309");


            //Assert
            Assert.Contains("WebApp", Driver.Title);
        }

        [Fact]
        public void TestaOpcoesHomeLoginNaNavBarHome()
        {
            //Act
            Driver.Navigate().GoToUrl("https://localhost:44309");

            //Assert
            Assert.Contains("Home", Driver.PageSource);
            Assert.Contains("Login", Driver.PageSource);
        }

        [Fact]
        public void LogandoNoSistema()
        {
            Driver.Navigate().GoToUrl("https://localhost:44309");
            Driver.FindElement(By.LinkText("Login")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            Driver.FindElement(By.Id("Senha")).Click();
            Driver.FindElement(By.Id("Senha")).SendKeys("senha01");

            Driver.FindElement(By.Id("btn-logar")).Click();
            Driver.FindElement(By.Id("agencia")).Click();
            Driver.FindElement(By.Id("home")).Click();
        }
        [Fact]
        public void ValidaLinkLoginNaHome()
        {
            Driver.Navigate().GoToUrl(servidor);
            Driver.FindElement(By.LinkText("Login")).Click();


            Assert.Contains("img", Driver.PageSource);

        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
