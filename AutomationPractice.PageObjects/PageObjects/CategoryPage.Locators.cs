using OpenQA.Selenium;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CategoryPage
    {
        private IWebElement CategoryPageName => _driver.FindElement(By.ClassName("category-name"));
        private IWebElement GridViewButton => _driver.FindElement(By.Id("grid"));
        private IWebElement ListViewButton => _driver.FindElement(By.Id("list"));
        private IWebElement AlertMessageBox => _driver.FindElement(By.ClassName("fancybox-error"));
        private IWebElement AlertMessageCloseIcon => _driver.FindElement(By.ClassName("fancybox-close"));

        private IWebElement GetProductContainerElement(string productName)
        {
            return _driver.FindElement(By.XPath($"//h5[@itemprop='name']/a[@title='{productName}']/ancestor::div[@class='product-container']"));
        }

        private IWebElement GetProductAddButtonElement(string productName, string addButton)
        {
            string buttonClassName;
            switch (addButton)
            {
                case "cart":
                    buttonClassName = "ajax_add_to_cart_button";
                    break;
                case "wishlist":
                    buttonClassName = "addToWishlist";
                    break;
                case "compare":
                    buttonClassName = "add_to_compare";
                    break;
                default:
                    throw new InvalidOperationException($"Unexpected value: {addButton}");
            }

            var productContainer = GetProductContainerElement(productName);
            return productContainer.FindElement(By.ClassName(buttonClassName));
        }
    }
}
