using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            Thread.Sleep(1000);
            Assert.IsFalse(categoryPage.IsAddToCompareCheckedForProduct(product));
            var finalCompareCount = categoryPage.GetCompareCount();
            Assert.AreEqual(initialCompareCount - 1, finalCompareCount);
        }


        [When(@"I add to compare the first '(\d+)' products")]
        public void WhenIAddToCompareProducts(int count)
        {
            CategoryPage.Products = categoryPage.GetProductDetailsList();
            for (var i = 0; i < count; i++)
                categoryPage.AddToCompareByProductIndex(i);
        }

        [Then(@"I (should|shouldn't) see the '(\d+)' products in the comparison page")]
        public void ThenIShouldSeeTheProductsInTheComparisonPage(string exist, int count)
        {
            if (homePage.GetCurrentPageLabel() != "Product Comparison")
                categoryPage.ClickCompareButton();

            if (exist.Equals("should"))
            {
                for (var i = 0; i < count; i++)
                    Assert.IsTrue(comparePage.ProductExistsInComparison(CategoryPage.Products[i].Name));
            }
            else
            {
                for (var i = 0; i < count; i++)
                    Assert.IsFalse(comparePage.ProductExistsInComparison(CategoryPage.Products[i].Name));
            }
        }

        [When(@"I remove the first (.*) products from the compare list")]
        public void WhenIRemoveTheFirstProductsFromTheCompareList(int count)
        {
            for (var i = 0; i < count; i++)
                comparePage.RemoveProductFromComparison(CategoryPage.Products[i].Name);
        }
    }
}
