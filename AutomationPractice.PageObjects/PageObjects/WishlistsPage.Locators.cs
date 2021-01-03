using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class WishlistsPage
    {
        private IWebElement FirstWishlistLink => _driver.FindElement(By.XPath("//tr[starts-with(@id,'wishlist')][1]/td[1]/a"));

    }
}
