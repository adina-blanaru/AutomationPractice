using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CategoryPage
    {
        public IList<IWebElement> ProductContainerList => _driver.FindElements(By.ClassName("product-container"));
        private IWebElement CategoryPageName => _driver.FindElement(By.ClassName("category-name"));
        private IWebElement GridViewButton => _driver.FindElement(By.Id("grid"));
        private IWebElement ListViewButton => _driver.FindElement(By.Id("list"));
        private IWebElement CompareButton => _driver.FindElement(By.ClassName("bt_compare"));
        private IWebElement CompareButtonCount => _driver.FindElement(By.ClassName("total-compare-val"));
        private IWebElement AlertMessageBox => _driver.FindElement(By.ClassName("fancybox-error"));
        private IWebElement AlertMessageCloseIcon => _driver.FindElement(By.ClassName("fancybox-close"));

        private IWebElement GetProductContainerElement(string productName)
        {
            return _driver.FindElement(By.XPath($"//h5[@itemprop='name']/a[@title='{productName}']/ancestor::div[@class='product-container']"));
        }

        private IWebElement GetAddButtonElement(string productName, string addButton)
        {
            var productContainer = GetProductContainerElement(productName);
            return productContainer.FindElement(By.ClassName(GetClassNameForAddButton(addButton)));
        }
        private IWebElement GetAddButtonElement(int index, string addButton)
        {
            return ProductContainerList[index].FindElement(By.ClassName(GetClassNameForAddButton(addButton)));
        }

        private string GetClassNameForAddButton(string addButton)
        {
            switch (addButton)
            {
                case "cart":
                    return "ajax_add_to_cart_button";
                case "wishlist":
                    return "addToWishlist";
                case "compare":
                    return "add_to_compare";
                default:
                    throw new InvalidOperationException($"Unexpected value: {addButton}");
            }
        }

        public string GetProductName(int index)
        {
            return ProductContainerList[index].FindElement(By.ClassName("product-name")).Text.Trim();
        }
    }
}
