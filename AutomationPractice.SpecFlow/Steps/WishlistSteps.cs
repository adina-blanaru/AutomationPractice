using AutomationPractice.PageObjects.Dto;
using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class WishlistSteps
    {
        private IWebDriver _driver;
        private AccountPage accountPage;
        private CategoryPage categoryPage;
        private HomePage homePage;
        private ProductPage productPage;
        private WishlistsPage wishlistsPage;

        public WishlistSteps(IWebDriver driver)
        {
            _driver = driver;
            accountPage = new AccountPage(driver);    
            categoryPage = new CategoryPage(driver);
            homePage = new HomePage(driver);
            productPage = new ProductPage(driver);
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
            GoToFirstWishlist();
            if (exist.Equals("should"))
                Assert.IsTrue(wishlistsPage.ProductExistsInWishlist(product));
            else
                Assert.IsFalse(wishlistsPage.ProductExistsInWishlist(product));
        }

        public void GoToFirstWishlist()
        {
            homePage.GoToMyAccountPage();
            accountPage.GoToWishlists();
            wishlistsPage.OpenFirstWishlist();
        }

        [When(@"I remove the '(.*)' product from the wishlist")]
        public void WhenIRemoveTheProductFromTheWishlist(string product)
        {
            wishlistsPage.RemoveProductFromWishlist(product);
        }

        [When(@"I add the product to whishlist")]
        public void WhenIAddTheProductToWhishlist()
        {
            var product = new ProductDataDto
            {
                Name = productPage.GetProductName(),
                Quantity = productPage.SelectRandomQuantity(1, 5),
                Size = productPage.SelectRandomSize(),
                Color = productPage.SelectRandomColor()
            };
            ProductPage.MyProducts.Add(product);
            productPage.AddToWishlist();
        }

        [Then(@"I should see the correct product in my wishlist")]
        public void ThenIShouldSeeTheCorrectProductInMyWishlist()
        {
            GoToFirstWishlist();
            var product = ProductPage.MyProducts[0];
            Assert.IsTrue(wishlistsPage.ProductExistsInWishlist(product.Name));
            Assert.AreEqual(product.Size, wishlistsPage.GetProductSize(product.Name));
            Assert.AreEqual(product.Color, wishlistsPage.GetProductColor(product.Name));
            Assert.AreEqual(product.Quantity, wishlistsPage.GetProductQuantity(product.Name));
        }

    }
}
