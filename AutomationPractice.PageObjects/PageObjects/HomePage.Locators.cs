using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class HomePage
    {
        private IWebElement SignInButton => _driver.FindElement(By.ClassName("login"));
        private IWebElement MyAccountButton => _driver.FindElement(By.ClassName("account"));
        private IWebElement SignOutButton => _driver.FindElement(By.ClassName("logout"));

        private IWebElement SearchTextBox => _driver.FindElement(By.Id("search_query_top"));
        private IWebElement CartButton => _driver.FindElement(By.CssSelector("a[title='View my shopping cart']"));

        private IWebElement PageBreadcrumbs => _driver.FindElement(By.ClassName("breadcrumb"));

        private IWebElement GetMenuElement(string name)
        {
            return _driver.FindElement(By.XPath($"//ul[contains(@class,'sf-menu')]/li/a[text()='{name}']"));
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
    }
}
