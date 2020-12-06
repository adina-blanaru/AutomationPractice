using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace TestSpecSelProj
{
    public enum BrowserType
    {
        Chrome,
        Firefox
    }
    [Binding]
    public sealed class Hooks
    {
        //learn more http://www.marcusoft.net/2013/04/ContextInjectionSpecFlow.html

        private readonly IObjectContainer _objectContainer;
        private BrowserType _browserType;
        public static IWebDriver _driver;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public void CreateDriver()
        {
            var browserType = TestContext.Parameters.Get("Browser", "Chrome");
            _browserType = (BrowserType)Enum.Parse(typeof(BrowserType), browserType);
            ChooseDriverInstance(_browserType);
            _driver.Manage().Window.Maximize();
        }

        public void ChooseDriverInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.Firefox:
                    _driver = new FirefoxDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
            }
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            CreateDriver();
            _driver.Navigate().GoToUrl("http://automationpractice.com");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
