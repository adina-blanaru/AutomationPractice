using OpenQA.Selenium;
using System;

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

        public string GetAlertMessage()
        {
            return AlertMessageBox.Text;
        }

        public void CloseAlertMessageBox()
        {
            AlertMessageCloseIcon.Click();
        }
    }
}
