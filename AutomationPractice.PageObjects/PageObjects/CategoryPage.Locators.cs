using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CategoryPage
    {
        public class ProductDetails
        {
            public IWebElement Container;
            public string Name;
            public IWebElement AddToCompareButton;
        }

        public static List<ProductDetails> Products;
        private IList<IWebElement> ProductContainerList => _driver.FindElements(By.ClassName("product-container"));
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

        public List<ProductDetails> GetProductDetailsList()
        {
            var products = new List<ProductDetails>();
            foreach (var container in ProductContainerList)
            {
                var productDetails = new ProductDetails()
                {
                    Container = container,
                    Name = container.FindElement(By.ClassName("product-name")).Text.Trim(),
                    AddToCompareButton = container.FindElement(By.ClassName("add_to_compare"))
                };
                products.Add(productDetails);
            }
            return products;
        }
    }
}
