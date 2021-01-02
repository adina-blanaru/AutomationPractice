using OpenQA.Selenium;
using AutomationPractice.PageObjects.PageObjects;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public class BaseSteps
    {
        private IWebDriver _driver;
        private HomePage homePage;

        public BaseSteps(IWebDriver driver)
        {
            _driver = driver;
            homePage = new HomePage(driver);
        }

        [Given(@"I'm on the Home page")]
        public void GivenIMOnTheHomePage()
        {
        }

        [Given(@"I'm on the Authentication page")]
        public void GivenImOnTheAuthenticationPage()
        {
            homePage.GoToAuthenticationPage();
        }

        [Then(@"I should see the '(.*)' page")]
        public void ThenIShouldSeeThePage(string page)
        {
            Assert.AreEqual(page, homePage.GetCurrentPageLabel());
        }

    }
}
