using OpenQA.Selenium;

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
    }
}
