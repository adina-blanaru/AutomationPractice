using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    partial class SearchResultsPage
    {
        private IWebElement SearchText => _driver.FindElement(By.ClassName("lighter"));
        private IWebElement ResultsCountText => _driver.FindElement(By.ClassName("heading-counter"));
        private IWebElement SearchErrorText => _driver.FindElement(By.ClassName("alert"));
    }
}
