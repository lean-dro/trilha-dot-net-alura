using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class HomePO
    {
        private IWebDriver driver;
        private By linkHome;
        private By linkContasCorrentes;
        private By linkClientes;
        private By linkAgencias;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            linkAgencias = By.Id("agencia");
            linkHome = By.Id("home");
            linkClientes = By.Id("clientes");
            linkContasCorrentes = By.Id("contacorrente");
        }

        public void NavegarParaUrlDesejada(String url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void NavegarParaAgencias()
        {
            driver.FindElement(linkAgencias).Click();
        }
        public void NavegarParaClientes()
        {
            driver.FindElement(linkClientes).Click();
        }
        public void NavegarParaContasCorrentes()
        {
            driver.FindElement(linkContasCorrentes).Click();
        }
        public void NavegarParaHome()
        {
            driver.FindElement(linkHome).Click();
        }
    }
}
