using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class OrderHistoryPage
    {
        private IWebElement OrderDetailsContainer => _driverWait.Until(ExpectedConditions.ElementExists(By.CssSelector("#block-order-detail p")));
        private IWebElement ItemsTotalWithTaxes => _driver.FindElement(By.XPath("//tfoot/tr[2]//span[@class='price']"));        
    }
}
