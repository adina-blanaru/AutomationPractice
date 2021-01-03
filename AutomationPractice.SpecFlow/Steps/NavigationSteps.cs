using AutomationPractice.PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
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
                GoToSubmenuInMenu(category.Name, menuName);
                VerifyCurrentPageIs(category.Name);
                foreach (var subcategory in category.Subcategories)
                {
                    homePage.HoverOverMenu(menuName);
                    homePage.ClickSubmenuCategory(category.Name, subcategory);
                    VerifyCurrentPageIs(subcategory);
                }
            }            
        }

        private void GoToSubmenuInMenu(string submenu, string menu)
        {
            homePage.HoverOverMenu(menu);
            homePage.ClickSubmenu(submenu);
        }

        [Given(@"I'm on the '(.*)' '(.*)' category in '(.*)' view")]
        public void GivenIAmOnCategoryPageWithView(string menu, string category, string viewMode)
        {
            GoToSubmenuInMenu(category, menu);
            categoryPage.SetViewMode(viewMode);
        }

    }
}
