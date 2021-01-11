using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class OrderHistoryPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        public OrderHistoryPage(IWebDriver driver)
        {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void OpenOrderByPosition(int position)
        {
            GetOrderRow(position).FindElement(By.CssSelector(".history_link a")).Click();
        }

        private IWebElement GetOrderRow(int position)
        {
            return _driver.FindElement(By.XPath($"//table[@id='order-list']/tbody/tr[{position}]"));
        }

        public string GetOrderDate(int position) 
        {
            return GetOrderRow(position).FindElement(By.ClassName("history_date")).Text;
        }

        public bool ProductExistsInOrder(string product)
        {
            BasePage.HoverOver(_driver, OrderDetailsContainer);
            return _driver.FindElements(By.XPath($"//label[contains(text(),'{product}')]")).Count > 0;
        }

        private IWebElement GetProductRow(string productName)
        {
            return _driver.FindElement(By.XPath($"//label[contains(text(),'{productName}')]/ancestor::tr"));
        }

        public string GetProductColor(string product)
        {
            var color = GetProductSizeColorDetails(product)[0];
            return color.Substring(color.IndexOf(": ") + 2);
        }

        private string[] GetProductSizeColorDetails(string product)
        {
            var details = _driver.FindElement(By.XPath($"//label[contains(text(),'{product}')]")).Text;
            return details.Split(',');
        }

        public string GetProductSize(string product)
        {
            var size = GetProductSizeColorDetails(product)[1];
            return size.Substring(size.IndexOf(": ") + 2);
        }

        public int GetProductQuantity(string product)
        {
            var qty = GetProductRow(product).FindElement(By.ClassName("order_qte_input"));
            return int.Parse(qty.GetAttribute("value"));
        }

        public double GetProductPrice(string product)
        {
            var price = GetProductRow(product).FindElement(By.XPath("./td[@class='price'][1]/label"));
            return BasePage.CurrencyToDouble(price.Text);
        }

        public double GetProductTotal(string product)
        {
            var total = GetProductRow(product).FindElement(By.XPath("./td[@class='price'][2]/label"));
            return BasePage.CurrencyToDouble(total.Text);
        }

        public double GetTotalProductsPrice()
        {
            return BasePage.CurrencyToDouble(ItemsTotalWithTaxes.Text);
        }
    }
}
