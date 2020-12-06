using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationPractice.PageObjects.Dto;
using System;
using System.Linq;

namespace AutomationPractice.PageObjects.PageObjects
{
    public partial class RegistrationPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;
        public RegistrationPage(IWebDriver driver)
        { 
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void FillRegisterForm(UserDataDto user)
        {
            FirstNameTextBox.SendKeys(user.FirstName);
            LastNameTextBox.SendKeys(user.LastName);
            SelectTitle(user.Title);
            PasswordTextBox.SendKeys(user.Password);
            SelectDateOfBirth(user.DateOfBirth);
            AddressTextBox.SendKeys(user.Address);
            CityTextBox.SendKeys(user.City);
            StateDropdown.SelectByText(user.State);
            ZipCodeTextBox.SendKeys(user.ZipCode);
            CountryDropdown.SelectByText(user.Country);
            MobilePhoneTextBox.SendKeys(user.MobilePhone);
            AliasAddressTextBox.SendKeys(user.AddressAlias);
            RegisterButton.Click();
        }

        private void SelectTitle(string title)
        {
            switch (title)
            {
                case "Mr.":
                    TitleMrRadioButton.Click();
                    break;
                case "Mrs.":
                    TitleMrsRadioButton.Click();
                    break;
                default: 
                    throw new ArgumentException($"Unexpected value: {title}");
            }           
        }

        private void SelectDateOfBirth(string dateOfBirth)
        {
            var dobInfo = dateOfBirth.Split('/').ToList();
            DobDayDropdown.SelectByValue(dobInfo[0]);
            DobMonthDropdown.SelectByValue(dobInfo[1]);
            DobYearDropdown.SelectByValue(dobInfo[2]);
        }
    }
}
