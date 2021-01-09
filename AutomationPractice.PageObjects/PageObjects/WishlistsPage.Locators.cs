using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class WishlistsPage
    {
        private IWebElement FirstWishlistLink => _driver.FindElement(By.XPath("//tr[starts-with(@id,'wishlist')][1]/td[1]/a"));
        private IWebElement WishlistContainer => _driverWait.Until(ExpectedConditions.ElementExists(By.CssSelector("#block-order-detail p")));

    }
}
