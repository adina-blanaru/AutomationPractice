using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class AuthenticationPage
    {
        private IWebElement NewEmailAdressTextBox => _driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountButton => _driver.FindElement(By.Id("SubmitCreate"));
    }
}
