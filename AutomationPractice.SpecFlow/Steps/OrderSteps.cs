using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class OrderSteps
    {
        private IWebDriver _driver;
        private CartPage cartPage;
        private OrderHistoryPage orderHistoryPage;

        public OrderSteps(IWebDriver driver)
        {
            _driver = driver;
            cartPage = new CartPage(driver);
            orderHistoryPage = new OrderHistoryPage(driver);
        }

        [When(@"I place the order")]
        public void WhenIPlaceTheOrder()
        {
            cartPage.SubmitSummaryStep();
            cartPage.SubmitAddressStep();
            cartPage.SubmitShippingStep();
            cartPage.SubmitPaymentStep("wire");
            cartPage.ConfirmOrder();
            cartPage.BackToOrdersButton.Click();
        }

        [Then(@"I should see the new order with the correct data")]
        public void ThenIShouldSeeTheNewOrder()
        {
            orderHistoryPage.OpenOrderByPosition(1);
            Assert.AreEqual(BasePage.GetCurrentDate("MM/dd/yyyy"), orderHistoryPage.GetOrderDate(1));

            var expectedTotalProductsPrice = 0.00;
            foreach (var product in ProductPage.MyProducts)
            {
                Assert.IsTrue(orderHistoryPage.ProductExistsInOrder(product.Name));
                Assert.AreEqual(product.Size, orderHistoryPage.GetProductSize(product.Name));
                Assert.AreEqual(product.Color, orderHistoryPage.GetProductColor(product.Name));
                Assert.AreEqual(product.Quantity, orderHistoryPage.GetProductQuantity(product.Name));
                Assert.AreEqual(product.Price, orderHistoryPage.GetProductPrice(product.Name));
                Assert.AreEqual(product.Quantity * product.Price, orderHistoryPage.GetProductTotal(product.Name));
                expectedTotalProductsPrice += product.Quantity * product.Price;
            }
            Assert.AreEqual(Math.Round(expectedTotalProductsPrice, 2), Math.Round(orderHistoryPage.GetTotalProductsPrice(), 2));
        }

        [When(@"I proceed to checkout from the Summary step")]
        public void WhenIProceedToCheckout()
        {
            cartPage.SubmitSummaryStep();
        }
    }
}
