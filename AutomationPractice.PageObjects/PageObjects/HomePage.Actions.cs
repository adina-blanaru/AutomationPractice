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

        public void GoToMyAccountPage()
        {
            MyAccountButton.Click();
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

        public void HoverOverMenu(string name)
        {
            BasePage.HoverOver(_driver, GetMenuElement(name));
        }

        public void ClickSubmenu(string name)
        {
            GetSubmenuElement(name).Click();
        }

        public void ClickSubmenuCategory(string submenu, string category)
        {
            GetSubmenuCategoryElement(submenu, category).Click();
        }

        public void SearchFor(string text)
        {
            SearchTextBox.SendKeys(text + Keys.Enter);
        }
    }
}
