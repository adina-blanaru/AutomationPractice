using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class CartPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public bool ProductExistsInCart(string product)
        {
            return _driver.FindElements(By.XPath($"//table[@id='cart_summary']//a[contains(text(),'{product}')]")).Count > 0;
        }

        public void RemoveProductFromCart(string product)
        {
            var deleteIcon = GetProductContainer(product).FindElement(By.ClassName("icon-trash"));
            deleteIcon.Click();
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(deleteIcon));
        }

        private IWebElement GetProductContainer(string productName)
        {
            return _driver.FindElement(By.XPath($"//table[@id='cart_summary']//a[contains(text(),'{productName}')]/ancestor::tr"));
        }

        public string GetProductColor(string product)
        {
            var color = GetProductSizeColorDetails(product)[0];
            return color.Substring(color.IndexOf(": ") + 2);
        }

        private string[] GetProductSizeColorDetails(string product)
        {
            var details = GetProductContainer(product).FindElement(By.CssSelector(".cart_description small a")).Text;
            return details.Split(',');
        }

        public string GetProductSize(string product)
        {
            var size = GetProductSizeColorDetails(product)[1];
            return size.Substring(size.IndexOf(": ") + 2);
        }

        public int GetProductQuantity(string product)
        {
            var qty = GetProductContainer(product).FindElement(By.ClassName("cart_quantity_input"));
            return int.Parse(qty.GetAttribute("value"));
        }

        public double GetProductPrice(string product)
        {
            var price = GetProductContainer(product).FindElement(By.CssSelector(".cart_unit .price .price"));
            return BasePage.CurrencyToDouble(price.Text);
        }

        public double GetProductTotal(string product)
        {
            var total = GetProductContainer(product).FindElement(By.CssSelector(".cart_total .price"));
            return BasePage.CurrencyToDouble(total.Text);
        }

        public double GetTotalProductsPrice()
        {            
            return BasePage.CurrencyToDouble(TotalProducts.Text);
        }
    }
}
