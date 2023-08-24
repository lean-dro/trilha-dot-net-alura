using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Utilitarios;
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

namespace Alura.ByteBank.WebApp.Testes
{


    public class NavegandoNaPaginaHome : IDisposable, IClassFixture<Gerenciador>
    {
        private string servidor = "https://localhost:44309";
       
      
        ITestOutputHelper SaidaClasse;
        static FirefoxOptions Configuracoes = new FirefoxOptions
        {
            AcceptInsecureCertificates = true
        };
        IWebDriver Driver;
       
        private HomePO home;
        private LoginPO login;
        public NavegandoNaPaginaHome(ITestOutputHelper saidaConstrutor)
        {
            home = new HomePO(Driver);
            login = new LoginPO(Driver);
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
            home.NavegarParaUrlDesejada("https://localhost:44309/UsuarioApps/Login");
            login.PreencherCampoELogar("andre@email.com", "senha01");
            login.btnClick();
        }
        [Fact]
        public void ValidaLinkLoginNaHome()
        {
            home.NavegarParaUrlDesejada(servidor);
            Driver.FindElement(By.LinkText("Login")).Click();

            Assert.Contains("img", Driver.PageSource);
        }

        [Theory]
        [InlineData($"/Agencia/Index")]
        [InlineData($"/Agencia/Create")]
        [InlineData($"/Agencia/Edit/1")]
        [InlineData($"/Agencia/Details/1")]

        [InlineData($"/Clientes/Create")]
        [InlineData($"/Clientes/Edit/1")]
        [InlineData($"/Clientes/Details/1")]

        [InlineData($"/ContaCorrentes/Create")]
        [InlineData($"/ContaCorrentes/Edit/1")]
        [InlineData($"/ContaCorrentes/Details/1")]
        public void TentaAcessarPaginaSemEstarLogado(string url)
        {
            home.NavegarParaUrlDesejada("https://localhost:44309/UsuarioApps/Login");
            string urlCompleta = servidor + url;
            home.NavegarParaUrlDesejada(urlCompleta);
           
            Assert.DoesNotContain("ByteBank",   Driver.PageSource);
        }
        [Theory]
        [InlineData($"/Agencia/Index")]
        [InlineData($"/Agencia/Create")]
        [InlineData($"/Agencia/Edit/1")]
        [InlineData($"/Agencia/Details/1")]

        [InlineData($"/Clientes/Create")]
        [InlineData($"/Clientes/Edit/1")]
        [InlineData($"/Clientes/Details/1")]

        [InlineData($"/ContaCorrentes/Create")]
        [InlineData($"/ContaCorrentes/Edit/1")]
        [InlineData($"/ContaCorrentes/Details/1")]
        public async Task TentaAcessarPaginaEstandoLogadoAsync(string url)
        {
            home.NavegarParaUrlDesejada("https://localhost:44309/UsuarioApps/Login");
            string urlCompleta = servidor + url;
            login.PreencherCampoELogar("andre@email.com", "senha01");
            login.btnClick();
          
            home.NavegarParaUrlDesejada(urlCompleta);
            Assert.Contains("ByteBank", Driver.PageSource);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
