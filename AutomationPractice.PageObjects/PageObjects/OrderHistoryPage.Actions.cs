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
    }
}
