using OpenQA.Selenium;
using System.Threading;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class WishlistsPage
    {
        private IWebDriver _driver;
        public WishlistsPage(IWebDriver driver) => _driver = driver;

        public void OpenFirstWishlist()
        {
            FirstWishlistLink.Click();
            Thread.Sleep(1000);
        }

        public bool ProductExistsInWishlist(string product)
        {
            return _driver.FindElements(By.XPath($"//p[@id='s_title'][contains(text(),'{product}')]")).Count > 0;
        }

        public void RemoveProductFromWishlist(string product)
        {
            _driver.FindElement(By.XPath($"//p[@id='s_title'][contains(text(),'{product}')]/parent::div/a[@title='Delete']")).Click();
        }
    }
}
