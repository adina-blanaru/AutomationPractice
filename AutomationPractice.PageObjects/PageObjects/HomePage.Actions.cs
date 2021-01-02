using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public void ClickMenu(string name)
        {
            GetMenuElement(name).Click();
        }

        private IWebElement GetMenuElement(string name)
        {
            return _driver.FindElement(By.XPath($"//ul[contains(@class,'sf-menu')]/li/a[text()='{name}']"));
        }

        public void HoverOverMenu(string name)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(GetMenuElement(name)).Perform();
        }

        public void ClickSubmenu(string name)
        {
            GetSubmenuElement(name).Click();
        }

        private IWebElement GetSubmenuElement(string name)
        {
            return _driver.FindElement(By.XPath($"//ul[contains(@class,'submenu-container')]/li/a[text()='{name}']"));
        }

        private IWebElement GetSubmenuCategoryElement(string submenu, string category)
        {
            IWebElement submenuElement = GetSubmenuElement(submenu);
            return submenuElement.FindElement(By.XPath($"//parent::li/ul/li/a[text()='{category}']"));
        }

        public void ClickSubmenuCategory(string submenu, string category)
        {
            GetSubmenuCategoryElement(submenu, category).Click();
        }
    }
}
