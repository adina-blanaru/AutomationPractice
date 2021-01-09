using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace AutomationPractice.PageObjects.PageObjects
{
    public static class BasePage
    {
        public static void HoverOver(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public static string GetCurrentTimestamp()
        {
            return DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss");
        }

        public static int GetRandomNumberBetween(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
