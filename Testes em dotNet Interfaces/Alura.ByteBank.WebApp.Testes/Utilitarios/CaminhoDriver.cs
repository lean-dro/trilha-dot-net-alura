using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.Utilitarios
{
    public class CaminhoDriver
    {

        public static FirefoxDriver Helper()
        {
            FirefoxOptions Configuracoes = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };
            FirefoxDriver driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Configuracoes);
            return driver;
        }
    }
}
