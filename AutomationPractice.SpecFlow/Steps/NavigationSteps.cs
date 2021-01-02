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
                homePage.ClickMenu(menu);
                VerifyCurrentPageIs(menu);
                //Assert.AreEqual(menu, homePage.GetCurrentPageLabel());
                //Assert.AreEqual(menu, categoryPage.GetCategoryPageName());
            }
        }

        private void VerifyCurrentPageIs(string menu)
        {
            Assert.AreEqual(menu, homePage.GetCurrentPageLabel());
            Assert.AreEqual(menu, categoryPage.GetCategoryPageName());
        }

        [Then(@"I should be able to access the (.*) submenus")]
        public void ThenIShouldBeAbleToAccessTheSubmenus(string menuName)
        {
            var categories = Hooks.scenarioData.Categories;
            foreach (var category in categories)
            {
                homePage.HoverOverMenu(menuName);
                homePage.ClickSubmenu(category.Name);
                VerifyCurrentPageIs(category.Name);
                foreach (var subcategory in category.Subcategories)
                {
                    homePage.HoverOverMenu(menuName);
                    homePage.ClickSubmenuCategory(category.Name, subcategory);
                    VerifyCurrentPageIs(subcategory);
                }
            }
            
        }

    }
}
