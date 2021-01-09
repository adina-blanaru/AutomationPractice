using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class WishlistsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        public WishlistsPage(IWebDriver driver)
        {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void OpenFirstWishlist()
        {
            FirstWishlistLink.Click();
            WishlistContainer.Click();  //to wait until wishlist loads
        }

        public bool ProductExistsInWishlist(string product)
        {
            return _driver.FindElements(By.XPath($"//p[@id='s_title'][contains(text(),'{product}')]")).Count > 0;

            //var products = _driver.FindElements(By.XPath($"//p[@id='s_title'][contains(text(),'{product}')]"));
            //if (products.Count > 0)
            //    BasePage.HoverOver(_driver, products[0]);
            //return products.Count > 0;
        }

        public void RemoveProductFromWishlist(string product)
        {
            GetProductContainer(product).FindElement(By.CssSelector("a[title='Delete']")).Click();
        }
        private IWebElement GetProductContainer(string product)
        {
            return _driver.FindElement(By.XPath($"//p[@id='s_title'][contains(text(),'{product}')]/ancestor::li"));
        }

        public string GetProductSize(string product)
        {
            return GetProductSizeColorDetails(product)[0].Trim();
        }

        private string[] GetProductSizeColorDetails(string product)
        {
            var details = GetProductContainer(product).FindElement(By.CssSelector("#s_title [title='Product detail']")).Text;
            return details.Split(',');
        }
        public string GetProductColor(string product)
        {
            return GetProductSizeColorDetails(product)[1].Trim();
        }

        public int GetProductQuantity(string product)
        {
            var qty = GetProductContainer(product).FindElement(By.CssSelector("[id^='quantity_']"));
            return int.Parse(qty.GetAttribute("value"));
        }
    }
}
