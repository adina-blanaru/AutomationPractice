using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class HomePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver) => _driver = driver;

        public void NavigateToUrl(string pageUrl)
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        public void GoToAuthenticationPage()
        {
            SignInButton.Click();
        }

        public string GetCurrentPageLabel()
        {
            return PageLabel.Text.Trim();
        }
    }
}
