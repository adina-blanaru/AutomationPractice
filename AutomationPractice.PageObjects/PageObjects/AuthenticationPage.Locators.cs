using OpenQA.Selenium;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class AuthenticationPage
    {
        private IWebElement NewEmailAdressTextBox => _driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountButton => _driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement EmailAdressTextBox => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordTextBox => _driver.FindElement(By.Id("passwd"));
        private IWebElement SignInButton => _driver.FindElement(By.Id("SubmitLogin"));
        private IWebElement AuthenticationErrorMessage => _driver.FindElement(By.CssSelector(".alert-danger li"));
    }
}
