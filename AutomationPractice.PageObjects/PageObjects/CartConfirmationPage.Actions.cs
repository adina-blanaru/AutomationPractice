using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class CartConfirmationPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        public CartConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public string GetCartCountConfirmationMessage()
        {
            return CartCountConfirmationMessage.Text;
        }

        public double GetTotalProductsPrice()
        {
            return BasePage.CurrencyToDouble(TotalProducts.Text);
        }
    }
}
