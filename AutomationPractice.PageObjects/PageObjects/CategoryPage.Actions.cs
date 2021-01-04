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
            GetProductAddButtonElement(product, addButton).Click();
        }

        public void AddToCompareByProductIndex(int index)
        {
            BasePage.HoverOver(_driver, Products[index].Container);
            Products[index].AddToCompareButton.Click();
            Thread.Sleep(500);
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
            var addToCompareButton = GetProductAddButtonElement(product, "compare");
            return addToCompareButton.GetAttribute("class").Contains("checked");
        }

        public int GetCompareCount()
        {
            return int.Parse(CompareButtonCount.Text);
        }
    }
}
