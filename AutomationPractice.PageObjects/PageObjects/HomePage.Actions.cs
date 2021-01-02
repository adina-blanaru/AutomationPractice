using OpenQA.Selenium;
using System;

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
            string[] breadcrumbs = GetPageBreadcrumbs();
            return breadcrumbs[breadcrumbs.Length - 1].Trim();
        }

        public string[] GetPageBreadcrumbs()
        {
            return PageBreadcrumbs.Text.Split('>');
        }

        public void GoToMenu(string menu)
        {
            GetMenuElement(menu).Click();
        }

        private IWebElement GetMenuElement(string menu)
        {
            return _driver.FindElement(By.XPath($"//ul[contains(@class,'sf-menu')]/li/a[text()='{menu}']"));
        }
    }
}
