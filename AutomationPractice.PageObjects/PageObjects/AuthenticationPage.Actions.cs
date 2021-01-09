using AutomationPractice.PageObjects.Dto;
using OpenQA.Selenium;
using System.Reflection;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class AuthenticationPage
    {
        private IWebDriver _driver;
        public AuthenticationPage(IWebDriver driver) => _driver = driver;

        public void CreateAccount(string email)
        {
            if (email.Equals("NewUniqueEmail"))
            {              
                string NewUniqueEmail = $"AD_{BasePage.GetCurrentTimestamp()}@test.com";
                NewEmailAdressTextBox.SendKeys(NewUniqueEmail);
            }
            else
            {
                NewEmailAdressTextBox.SendKeys(email);
            }
            CreateAccountButton.Click();
        }

        public void LoginWithCredentials(UserCredetialsDto userCredentials)
        {
            var emailValue = userCredentials.GetType().GetRuntimeProperty("Email").GetValue(userCredentials);
            if (emailValue != null)
            {
                EmailAdressTextBox.SendKeys(emailValue.ToString());
            }

            var passwordValue = userCredentials.GetType().GetRuntimeProperty("Password").GetValue(userCredentials);
            if (passwordValue != null)
            {
                PasswordTextBox.SendKeys(passwordValue.ToString());
            }

            SignInButton.Click();
        }

        public string GetAuthenticationError()
        {
            return AuthenticationErrorMessage.Text;
        }
    }
}
