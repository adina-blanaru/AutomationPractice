using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
            return System.DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss");
        }
    }
}
