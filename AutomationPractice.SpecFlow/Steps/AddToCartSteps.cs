using AutomationPractice.PageObjects.Dto;
using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class AddToCartSteps
    {
        private IWebDriver _driver;
        private CartConfirmationPage cartConfirmationPage;
        private CartPage cartPage;
        private CategoryPage categoryPage;
        private HomePage homePage;
        private ProductPage productPage;

        public AddToCartSteps(IWebDriver driver)
        {
            _driver = driver;
            cartConfirmationPage = new CartConfirmationPage(driver);
            cartPage = new CartPage(driver);
            categoryPage = new CategoryPage(driver);
            homePage = new HomePage(driver);
            productPage = new ProductPage(driver);
        }

        [When(@"I add to cart the '(\d+)(?:st|nd|rd|th)' product(?:s?)")]
        public void WhenIAddToCartThetProduct(int index)
        {
            index--;
            var product = new ProductDataDto
            {
                Name = categoryPage.GetProductName(index),
                Price = categoryPage.GetPriceByProductIndex(index)
            };
            ProductPage.MyProducts.Add(product);
            categoryPage.AddToCartByProductIndex(index);
        }

        [Then(@"I (should|shouldn't) see the '(\d+)' products in my cart")]
        public void ThenIShouldSeeTheProductsInMyCart(string exist, int count)
        {
            if (homePage.GetCurrentPageLabel() != "Your shopping cart")
                homePage.GoToMyCartPage();

            if (exist.Equals("should"))
            {
                for (var i = 0; i < count; i++)
                    Assert.IsTrue(cartPage.ProductExistsInCart(ProductPage.MyProducts[i].Name));
            }
            else
            {
                for (var i = 0; i < count; i++)
                    Assert.IsFalse(cartPage.ProductExistsInCart(ProductPage.MyProducts[i].Name));
            }
        }

        [Then(@"I should see the confirmation for '(\d+)' product(?:s?)")]
        public void ThenIShouldSeeTheConfirmationForProduct(int count)
        {
            var expectedMessage = $"There are {count} items in your cart.";
            if (count == 1)
                expectedMessage = "There is 1 item in your cart.";
            Assert.AreEqual(expectedMessage, cartConfirmationPage.GetCartCountConfirmationMessage());

            var expectedPrice = 0.00;
            foreach (var product in ProductPage.MyProducts)
                expectedPrice += product.Price;
            Assert.AreEqual(expectedPrice, cartConfirmationPage.GetTotalProductsPrice());

            cartConfirmationPage.ContinueShoppingButton.Click();
        }

        [Given(@"I add to my cart '(\d+)' random product(?:s?) from '(.*)' menu")]
        [When(@"I add to my cart '(\d+)' random product(?:s?) from '(.*)' menu")]
        public void GivenIAddToMyCartRandomProductsFromMenu(int count, string menu)
        {
            for (var i = 0; i < count; i++)
            {
                var navigationSteps = new NavigationSteps(_driver);
                navigationSteps.GivenIOpenRandomProductFromMenu(menu);
                AddToCartFromProductPage();
                if (i == count - 1)
                    cartConfirmationPage.ProceedToCheckoutButton.Click();
                else
                    cartConfirmationPage.ContinueShoppingButton.Click();
            }
        }

        public void AddToCartFromProductPage()
        {
            var product = new ProductDataDto
            {
                Name = productPage.GetProductName(),
                Price = productPage.GetProductPrice(),
                Quantity = productPage.SelectRandomQuantity(1, 5),
                Size = productPage.SelectRandomSize(),
                Color = productPage.SelectRandomColor()
            };
            ProductPage.MyProducts.Add(product);
            productPage.AddToCart();
        }

        [Then(@"I should see the correct data in my cart")]
        public void ThenIShouldSeeTheCorrectDataInMyCart()
        {
            if (homePage.GetCurrentPageLabel() != "Your shopping cart")
                homePage.GoToMyCartPage();

            var expectedTotalProductsPrice = 0.00;
            foreach (var product in ProductPage.MyProducts)
            {
                Assert.IsTrue(cartPage.ProductExistsInCart(product.Name));
                Assert.AreEqual(product.Size, cartPage.GetProductSize(product.Name));
                Assert.AreEqual(product.Color, cartPage.GetProductColor(product.Name));
                Assert.AreEqual(product.Quantity, cartPage.GetProductQuantity(product.Name));
                Assert.AreEqual(product.Price, cartPage.GetProductPrice(product.Name));
                Assert.AreEqual(product.Quantity * product.Price, cartPage.GetProductTotal(product.Name));
                expectedTotalProductsPrice += product.Quantity * product.Price;
            }
            Assert.AreEqual(expectedTotalProductsPrice, cartPage.GetTotalProductsPrice());
        }

        [When(@"I remove the '(\d+)(?:st|nd|rd|th)' product from the cart")]
        public void WhenIRemoveTheProductFromTheCart(int index)
        {
            index--;
            cartPage.RemoveProductFromCart(ProductPage.MyProducts[index].Name);
            ProductPage.MyProducts.Remove(ProductPage.MyProducts[index]);
        }
    }
}
