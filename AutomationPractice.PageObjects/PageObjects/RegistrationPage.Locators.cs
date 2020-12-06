using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class RegistrationPage
    {
        private IWebElement TitleMrRadioButton => _driver.FindElement(By.Id("id_gender1"));
        private IWebElement TitleMrsRadioButton => _driver.FindElement(By.Id("id_gender2"));
        private IWebElement FirstNameTextBox => 
            _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("customer_firstname")));
        private IWebElement LastNameTextBox => _driver.FindElement(By.Id("customer_lastname"));
        private IWebElement EmailTextBox => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordTextBox => _driver.FindElement(By.Id("passwd"));
        private SelectElement DobDayDropdown => new SelectElement(_driver.FindElement(By.Id("days")));
        private SelectElement DobMonthDropdown => new SelectElement(_driver.FindElement(By.Id("months")));
        private SelectElement DobYearDropdown => new SelectElement(_driver.FindElement(By.Id("years")));
        private IWebElement AddressTextBox => _driver.FindElement(By.Id("address1"));
        private IWebElement CityTextBox => _driver.FindElement(By.Id("city"));
        private IWebElement ZipCodeTextBox => _driver.FindElement(By.Id("postcode"));
        private SelectElement StateDropdown => new SelectElement(_driver.FindElement(By.Id("id_state")));
        private SelectElement CountryDropdown => new SelectElement(_driver.FindElement(By.Id("id_country")));
        private IWebElement MobilePhoneTextBox => _driver.FindElement(By.Id("phone_mobile"));
        private IWebElement AliasAddressTextBox => _driver.FindElement(By.Id("alias"));
        private IWebElement RegisterButton => _driver.FindElement(By.Id("submitAccount"));
    }
}
