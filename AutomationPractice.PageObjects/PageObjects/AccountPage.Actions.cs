using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class AccountPage
    {
        private IWebDriver _driver;
        public AccountPage(IWebDriver driver) => _driver = driver;

        public void GoToWishlists()
        {
            MyWishlistsButton.Click();
        }
    }
}
