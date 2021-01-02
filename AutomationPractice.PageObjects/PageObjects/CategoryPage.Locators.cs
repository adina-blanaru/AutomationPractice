using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class CategoryPage
    {
        private IWebElement CategoryPageName => _driver.FindElement(By.ClassName("category-name"));

    }
}
