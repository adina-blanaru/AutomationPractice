using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class SearchSteps
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private SearchResultsPage searchResultsPage;

        public SearchSteps(IWebDriver driver)
        {
            _driver = driver;
            homePage = new HomePage(driver);
            searchResultsPage = new SearchResultsPage(driver);
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string text)
        {
            homePage.SearchFor(text);
        }

        [Then(@"I should see expected results")]
        public void ThenIShouldSeeExpectedResults(Table table)
        {
            var result = table.CreateInstance<(string SearchText, string ResultsCount, string ErrorMessage)>();
            Assert.AreEqual(result.ResultsCount, searchResultsPage.GetResultsCount());
            if (result.ResultsCount != "0")
            {
                Assert.AreEqual(result.SearchText, searchResultsPage.GetSearchText());
            }
            else
            {
                Assert.AreEqual($"{result.ErrorMessage} \"{result.SearchText}\"", searchResultsPage.GetErrorMessage());
            }

        }
    }
}
