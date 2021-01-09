using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class ProductPage
    {
        private IWebDriver _driver;
        public ProductPage(IWebDriver driver) => _driver = driver;

        public string GetProductName()
        {
            return ProductName.Text.Trim();
        }

        public void AddToWishlist()
        {
            AddToWishlistButton.Click();
        }

        public void AddToCart()
        {
            AddToCartButton.Click();
        }

        public int SelectRandomQuantity(int min, int max)
        {
            var random = BasePage.GetRandomNumberBetween(min, max);
            QuantityTextBox.Clear();
            QuantityTextBox.SendKeys(random.ToString());
            return random;
        }

        public string SelectRandomSize()
        {
            SelectElement size = new SelectElement(SizeSelectorDropdown);
            var random = BasePage.GetRandomNumberBetween(0, size.Options.Count - 1);
            size.SelectByIndex(random);
            return size.Options[random].GetAttribute("title");
        }

        public string SelectRandomColor()
        {
            var random = BasePage.GetRandomNumberBetween(0, ColorButtonList.Count - 1);
            ColorButtonList[random].Click();
            return ColorButtonList[random].GetAttribute("title");
        }
    }
}
