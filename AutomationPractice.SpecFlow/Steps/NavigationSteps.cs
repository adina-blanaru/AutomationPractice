using AutomationPractice.PageObjects.PageObjects;
using AutomationPractice.SpecFlow.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationPractice.SpecFlow.Steps
{
    [Binding]
    public sealed class NavigationSteps
    {
        private IWebDriver _driver;

        private CategoryPage categoryPage;
        private HomePage homePage;

        public NavigationSteps(IWebDriver driver)
        {
            _driver = driver;
            categoryPage = new CategoryPage(driver);
            homePage = new HomePage(driver);
        }

        [Then(@"I should be able to access all the menus")]
        public void ThenIShouldBeAbleToAccessAllTheMenus()
        {
            //string[] menus = { "Women", "Dresses", "T-shirts" };
            string[] menus = Hooks.scenarioData.Menus;

            foreach (var menu in menus)
            {
                homePage.GoToMenu(menu);
                Assert.AreEqual(menu, homePage.GetCurrentPageLabel());
                Assert.AreEqual(menu, categoryPage.GetCategoryPageName());
            }
        }
    }
}
