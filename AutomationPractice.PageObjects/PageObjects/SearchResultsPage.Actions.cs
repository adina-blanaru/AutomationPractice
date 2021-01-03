using OpenQA.Selenium;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class SearchResultsPage
    {
        private IWebDriver _driver;
        public SearchResultsPage(IWebDriver driver) => _driver = driver;

        public string GetSearchText()
        {
            var text = SearchText.Text;
            return text.Substring(text.IndexOf('"') + 1, text.LastIndexOf('"') - 1).ToLower();
        }

        public string GetResultsCount()
        {
            return ResultsCountText.Text.Split(' ')[0];
        }

        public string GetErrorMessage()
        {
            return SearchErrorText.Text;
        }
    }
}
