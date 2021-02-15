using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class CategoryPage
    {
        private IWebDriver _driver;
        public CategoryPage(IWebDriver driver) => _driver = driver;

        public string GetCategoryPageName()
        {
            return CategoryPageName.Text.Trim();
        }

        public void SetViewMode(string viewMode)
        {
            switch (viewMode)
            {
                case "Grid":
                    {
                        if (GridViewButton.GetAttribute("class") != "selected")
                            GridViewButton.Click();
                        break;
                    }
                case "List":
                    {
                        if (ListViewButton.GetAttribute("class") != "selected")
                            ListViewButton.Click();
                        break;
                    }
                default:
                    throw new InvalidOperationException($"Unexpected value: {viewMode}");
            }
        }

        public void AddProductTo(string product, string addButton)
        {
            BasePage.HoverOver(_driver, GetProductContainerElement(product));
            GetAddButtonElement(product, addButton).Click();
        }

        public void AddToCompareByProductIndex(int index)
        {
            BasePage.HoverOver(_driver, ProductContainerList[index]);
            GetAddButtonElement(index, "compare").Click();
            Thread.Sleep(500);  //TODO find another way to wait until product in added to comparison
        }

        public string GetAlertMessage()
        {
            return AlertMessageBox.Text;
        }

        public void CloseAlertMessageBox()
        {
            AlertMessageCloseIcon.Click();
        }

        public void ClickCompareButton()
        {
            CompareButton.Click();
        }

        public bool IsAddToCompareCheckedForProduct(string product)
        {
            Thread.Sleep(3000); //TODO find another way to wait until product in added to comparison
            var addToCompareButton = GetAddButtonElement(product, "compare");
            return addToCompareButton.GetAttribute("class").Contains("checked");
        }

        public int GetCompareCount()
        {
            return int.Parse(CompareButtonCount.Text);
        }

        public void OpenProductByIndex(int index)
        {
            BasePage.HoverOver(_driver, ProductContainerList[index]);
            ProductContainerList[index].FindElement(By.ClassName("product-name")).Click();
        }

        public void AddToCartByProductIndex(int index)
        {
            BasePage.HoverOver(_driver, ProductContainerList[index]);
            GetAddButtonElement(index, "cart").Click();
        }

        public double GetPriceByProductIndex(int index)
        {
            var price = ProductContainerList[index].FindElement(By.CssSelector(".right-block .price")).Text;
            return BasePage.CurrencyToDouble(price);
        }
    }
}
