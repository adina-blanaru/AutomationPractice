using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class OrderHistoryPage
    {
        private IWebElement OrderDetailsContainer => _driverWait.Until(ExpectedConditions.ElementExists(By.Id("block-order-detail")));
        
    }
}
