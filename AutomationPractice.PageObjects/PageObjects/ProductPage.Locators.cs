using AutomationPractice.PageObjects.Dto;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class ProductPage
    {
        public static List<ProductDataDto> MyProducts = new List<ProductDataDto>();

        private IWebElement ProductName => _driver.FindElement(By.CssSelector("[itemprop='name']"));
        private IWebElement ProductPrice => _driver.FindElement(By.Id("our_price_display"));
        private IWebElement AddToWishlistButton => _driver.FindElement(By.Id("wishlist_button"));
        private IWebElement AddToCartButton => _driver.FindElement(By.CssSelector("#add_to_cart button"));
        private IWebElement QuantityTextBox => _driver.FindElement(By.Id("quantity_wanted"));
        private IList<IWebElement> ColorButtonList => _driver.FindElements(By.ClassName("color_pick"));
        private IWebElement SizeSelectorDropdown => _driver.FindElement(By.Id("group_1"));
    }
}
