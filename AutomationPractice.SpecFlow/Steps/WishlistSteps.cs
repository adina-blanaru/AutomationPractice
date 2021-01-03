using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class WishlistSteps
    {
        private IWebDriver _driver;
        private AccountPage accountPage;
        private CategoryPage categoryPage;
        private HomePage homePage;
        private WishlistsPage wishlistsPage;

        public WishlistSteps(IWebDriver driver)
        {
            _driver = driver;
            accountPage = new AccountPage(driver);    
            categoryPage = new CategoryPage(driver);
            homePage = new HomePage(driver);
            wishlistsPage = new WishlistsPage(driver);
        }

        [When(@"I add to wishlist the '(.*)' product")]
        public void WhenIAddToWishlistTheProduct(string product)
        {
            categoryPage.AddProductTo(product, "wishlist");
            /*
            //only in debug mode
            Assert.AreEqual("Added to your wishlist.", categoryPage.GetAlertMessage());
            categoryPage.CloseAlertMessageBox();
            */
        }

        [Then(@"I (should|shouldn't) see the '(.*)' product in my wishlist")]
        public void ThenIShouldSeeTheProductInMyWishlist(string exist, string product)
        {
            homePage.GoToMyAccountPage();
            accountPage.GoToWishlists();
            wishlistsPage.OpenFirstWishlist();

            if (exist.Equals("should"))
                Assert.IsTrue(wishlistsPage.ProductExistsInWishlist(product));
            else
                Assert.IsFalse(wishlistsPage.ProductExistsInWishlist(product));
        }

        [When(@"I remove the '(.*)' product from the wishlist")]
        public void WhenIRemoveTheProductFromTheWishlist(string product)
        {
            wishlistsPage.RemoveProductFromWishlist(product);
        }
    }
}
