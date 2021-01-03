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

        [When(@"I login with credentials")]
        public void WhenILoginWithCredentials(Table table)
        {
            var userCredentials = table.CreateInstance<UserCredetialsDto>();
            authenticationPage.LoginWithCredentials(userCredentials);
        }

        [Then(@"I should see the '(.*)' authentication error")]
        public void ThenIShouldSeeTheAuthenticationError(string error)
        {
            Assert.AreEqual(error, authenticationPage.GetAuthenticationError());
        }

        [Given(@"I'm logged into the site")]
        public void GivenIMLoggedIntoTheSite(Table table)
        {
            homePage.GoToAuthenticationPage();
            var userCredentials = table.CreateInstance<UserCredetialsDto>();
            authenticationPage.LoginWithCredentials(userCredentials);
        }
    }
}
