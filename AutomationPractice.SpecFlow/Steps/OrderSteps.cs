using AutomationPractice.PageObjects.Dto;
using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class OrderSteps
    {
        private IWebDriver _driver;
        private CartConfirmationPage cartConfirmationPage;
        private CartPage cartPage;
        private CategoryPage categoryPage;
        private HomePage homePage;
        private OrderHistoryPage orderHistoryPage;

        public OrderSteps(IWebDriver driver)
        {
            _driver = driver;
            cartConfirmationPage = new CartConfirmationPage(driver);
            cartPage = new CartPage(driver);
            categoryPage = new CategoryPage(driver);
            homePage = new HomePage(driver);
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
            //TODO check products details - name, color, size, qty, price
        }


        [When(@"I proceed to checkout from the Summary step")]
        public void WhenIProceedToCheckout()
        {
            cartPage.SubmitSummaryStep();
        }
    }
}
