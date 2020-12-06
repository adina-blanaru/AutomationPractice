using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class HomePage
    {
        private IWebElement SignInButton => _driver.FindElement(By.ClassName("login"));
        private IWebElement MyAccountButton => _driver.FindElement(By.ClassName("account"));
        private IWebElement SignOutButton => _driver.FindElement(By.ClassName("logout"));

        private IWebElement PageLabel => _driver.FindElement(By.ClassName("navigation_page"));

    }
}
