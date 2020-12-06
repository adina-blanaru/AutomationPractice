using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class AuthenticationPage
    {
        private IWebDriver _driver;
        public AuthenticationPage(IWebDriver driver) => _driver = driver;

        public void CreateAccount(string email)
        {
            NewEmailAdressTextBox.SendKeys(email);
            CreateAccountButton.Click();
        }
    }
}
