using AutomationPractice.PageObjects.Dto;
using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class CompareSteps
    {
        private IWebDriver _driver;
        private CategoryPage categoryPage;
        private ComparePage comparePage;
        private HomePage homePage;

        public CompareSteps(IWebDriver driver)
        {
            _driver = driver;
            categoryPage = new CategoryPage(driver);
            comparePage = new ComparePage(driver);
            homePage = new HomePage(driver);
        }

        [Then(@"I should be able to add to compare the '(.*)' product")]
        public void ThenIShouldBeAbleToAddToCompareTheProduct(string product)
        {
            var initialCompareCount = categoryPage.GetCompareCount();
            categoryPage.AddProductTo(product, "compare");
            Thread.Sleep(1000);
            Assert.IsTrue(categoryPage.IsAddToCompareCheckedForProduct(product));
            var finalCompareCount = categoryPage.GetCompareCount();
            Assert.AreEqual(initialCompareCount + 1, finalCompareCount);
        }

        [Then(@"I should be able to remove from compare the '(.*)' product")]
        public void ThenIShouldBeAbleToRemoveFromCompareTheProduct(string product)
        {
            var initialCompareCount = categoryPage.GetCompareCount();
            categoryPage.AddProductTo(product, "compare");
            Thread.Sleep(1000); //TODO find another way to wait until product in added to comparison
            Assert.IsFalse(categoryPage.IsAddToCompareCheckedForProduct(product));
            var finalCompareCount = categoryPage.GetCompareCount();
            Assert.AreEqual(initialCompareCount - 1, finalCompareCount);
        }


        [When(@"I add to compare the first '(\d+)' products")]
        public void WhenIAddToCompareProducts(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var product = new ProductDataDto { Name = categoryPage.GetProductName(i) };
                ProductPage.MyProducts.Add(product);
                categoryPage.AddToCompareByProductIndex(i);
            }
        }

        [Then(@"I (should|shouldn't) see the '(\d+)' products in the comparison page")]
        public void ThenIShouldSeeTheProductsInTheComparisonPage(string exist, int count)
        {
            if (homePage.GetCurrentPageLabel() != "Product Comparison")
                categoryPage.ClickCompareButton();

            if (exist.Equals("should"))
            {
                for (var i = 0; i < count; i++)
                    Assert.IsTrue(comparePage.ProductExistsInComparison(ProductPage.MyProducts[i].Name));
            }
            else
            {
                for (var i = 0; i < count; i++)
                    Assert.IsFalse(comparePage.ProductExistsInComparison(ProductPage.MyProducts[i].Name));
            }
        }

        [When(@"I remove the first (.*) products from the compare list")]
        public void WhenIRemoveTheFirstProductsFromTheCompareList(int count)
        {
            for (var i = 0; i < count; i++)
                comparePage.RemoveProductFromComparison(ProductPage.MyProducts[i].Name);
        }
    }
}
