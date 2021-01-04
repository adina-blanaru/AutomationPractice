using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class ComparePage
    {
        private IWebDriver _driver;
        public ComparePage(IWebDriver driver) => _driver = driver;

        public bool ProductExistsInComparison(string product)
        {
            return _driver.FindElements(By.XPath($"//a[@class='product-name'][contains(text(),'{product}')]")).Count > 0;
        }

        public void RemoveProductFromComparison(string product)
        {
            _driver.FindElement(By.XPath($"//a[@class='product-name'][contains(text(),'{product}')]/ancestor::td//a[@class='cmp_remove']")).Click();
        }
    }
}
