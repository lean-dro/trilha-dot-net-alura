using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome
    {
        ITestOutputHelper SaidaClasse;
        FirefoxOptions Config;
        public NavegandoNaPaginaHome(ITestOutputHelper saidaConstrutor, FirefoxOptions config)
        {
            config.AcceptInsecureCertificates = true;
            Config = config;

            SaidaClasse = saidaConstrutor;

        }

        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {


            //Arrange
 
            IWebDriver driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Config);
            SaidaClasse.WriteLine(Assembly.GetExecutingAssembly().Location);
            //Act
            
            driver.Navigate().GoToUrl("https://localhost:44309");

            
            //Assert
            Assert.Contains("WebApp", driver.Title);
        }

        [Fact]
        public void TestaElementosHtml() { }
    }
}
