using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CartConfirmationPage
    {
        public IWebElement ContinueShoppingButton =>
            _driverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[title='Continue shopping']")));
        public IWebElement ProceedToCheckoutButton =>
            _driverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[title='Proceed to checkout']")));
        private IWebElement CartCountConfirmationMessage => 
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h2 [class^='ajax_cart_product_txt']:not([style*='none'])")));
        private IWebElement TotalProducts => _driver.FindElement(By.ClassName("ajax_block_products_total"));

    }
}
