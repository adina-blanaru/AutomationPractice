using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class WishlistSteps
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private CategoryPage categoryPage;

        public WishlistSteps(IWebDriver driver)
        {
            _driver = driver;
            homePage = new HomePage(driver);
            categoryPage = new CategoryPage(driver);
        }

        [When(@"I add to wishlist the '(.*)' product")]
        public void WhenIAddToWishlistTheProduct(string product)
        {
            categoryPage.AddProductTo(product, "wishlist");
            Assert.AreEqual("Added to your wishlist.", categoryPage.GetAlertMessage());
            categoryPage.CloseAlertMessageBox();
        }

        [Then(@"I should see the '(.*)' product in my wishlist")]
        public void ThenIShouldSeeTheProductInMyWishlist(string product)
        {
            //TODO
        }

    }
}
