using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class LoginPO
    {
        private IWebDriver Driver;
        private By CampoEmail;
        private By CampoSenha;
        private By BtnLogar;
        public LoginPO(IWebDriver driver) {
            this.Driver = driver;
            CampoEmail = By.Id("Email");
            CampoSenha = By.Id("Senha");

            BtnLogar = By.Id("btn-logar");
        }

        public void PreencherCampoELogar(string email, string senha) {
            Driver.FindElement(CampoEmail).SendKeys(email);
            Driver.FindElement(CampoSenha).SendKeys(senha);
           
        }

        public void btnClick()
        {
            Driver.FindElement(BtnLogar).Click();
            
        }
    }
}
