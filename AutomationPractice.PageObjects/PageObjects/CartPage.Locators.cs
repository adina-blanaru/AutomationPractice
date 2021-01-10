using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CartPage
    {
        private IWebElement TotalProducts => _driver.FindElement(By.Id("total_product"));
        private IWebElement ProceedToCheckoutButton => 
            _driver.FindElement(By.XPath("//p[contains(@class,'cart_navigation')]//span[contains(text(),'Proceed to checkout')]"));
        private IWebElement TermsOfServiceCheckbox => _driver.FindElement(By.CssSelector("input[type='checkbox']"));
        private IWebElement PayByBankWireButton => _driver.FindElement(By.ClassName("bankwire"));
        private IWebElement PayByCheckButton => _driver.FindElement(By.ClassName("cheque"));
        private IWebElement ConfirmOrderButton => _driver.FindElement(By.XPath("//span[text()='I confirm my order']"));
        public IWebElement BackToOrdersButton => _driver.FindElement(By.CssSelector("[title='Back to orders']"));
    }
}
