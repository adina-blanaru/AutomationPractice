using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CartPage
    {
        private IWebElement TotalProducts => _driver.FindElement(By.Id("total_product"));

    }
}
