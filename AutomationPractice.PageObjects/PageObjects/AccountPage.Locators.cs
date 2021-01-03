using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class AccountPage
    {
        private IWebElement MyWishlistsButton => _driver.FindElement(By.CssSelector("a[title='My wishlists']"));

    }
}
