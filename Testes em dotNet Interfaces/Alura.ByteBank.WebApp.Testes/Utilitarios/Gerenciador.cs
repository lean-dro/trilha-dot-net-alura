using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.Utilitarios
{
    public class Gerenciador : IDisposable
    {
        public IWebDriver Driver { get; private set; }
       
        public Gerenciador()
        {
            Driver = CaminhoDriver.Helper();
        }
        public void Dispose() {
            Driver.Quit();
        }
    }
}
