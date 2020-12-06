using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AutomationPractice.PageObjects.Dto;
using AutomationPractice.PageObjects.PageObjects;


namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public class AuthenticationSteps
    {

        private IWebDriver _driver;
        private AuthenticationPage authenticationPage;
        private HomePage homePage;
        private RegistrationPage registrationPage;

        public AuthenticationSteps(IWebDriver driver)
        {
            _driver = driver;
            authenticationPage = new AuthenticationPage(driver);
            homePage = new HomePage(driver);
            registrationPage = new RegistrationPage(driver);
        }

        [When(@"I create an account")]
        public void WhenICreateAnAccount(Table table)
        {
            var myUser = table.CreateInstance<UserDataDto>();
            authenticationPage.CreateAccount(myUser.Email);
            registrationPage.FillRegisterForm(myUser);
        }

        [Then(@"I should see the '(.*)' page")]
        public void ThenIShouldSeeThePage(string page)
        {
            Assert.AreEqual(page, homePage.GetCurrentPageLabel());
        }
    }
}
