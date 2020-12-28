using AutomationPractice.PageObjects.Dto;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Reflection;

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
            var FirstNameValue = user.GetType().GetRuntimeProperty("FirstName").GetValue(user);
            if (FirstNameValue != null)
            {
                FirstNameTextBox.SendKeys(user.FirstName);
            }

            var LastNameValue = user.GetType().GetRuntimeProperty("LastName").GetValue(user);
            if (LastNameValue != null)
            {
                LastNameTextBox.SendKeys(user.LastName);
            }

            var TitleValue = user.GetType().GetRuntimeProperty("Title").GetValue(user);
            if (TitleValue != null)
            {
                SelectTitle(user.Title);
            }

            var PasswordValue = user.GetType().GetRuntimeProperty("Password").GetValue(user);
            if (PasswordValue != null)
            {
                PasswordTextBox.SendKeys(user.Password);
            }

            var DateOfBirthValue = user.GetType().GetRuntimeProperty("DateOfBirth").GetValue(user);
            if (DateOfBirthValue != null)
            {
                SelectDateOfBirth(user.DateOfBirth);
            }

            var AddressValue = user.GetType().GetRuntimeProperty("Address").GetValue(user);
            if (AddressValue != null)
            {
                AddressTextBox.SendKeys(user.Address);
            }

            var CityValue = user.GetType().GetRuntimeProperty("City").GetValue(user);
            if (CityValue != null)
            {
                CityTextBox.SendKeys(user.City);
            }

            var StateValue = user.GetType().GetRuntimeProperty("State").GetValue(user);
            if (StateValue != null)
            {
                StateDropdown.SelectByText(user.State);
            }

            var ZipCodeValue = user.GetType().GetRuntimeProperty("ZipCode").GetValue(user);
            if (ZipCodeValue != null)
            {
                ZipCodeTextBox.SendKeys(user.ZipCode);
            }

            var CountryValue = user.GetType().GetRuntimeProperty("Country").GetValue(user);
            if (CountryValue != null)
            {
                CountryDropdown.SelectByText(user.Country);
            }

            var MobilePhoneValue = user.GetType().GetRuntimeProperty("MobilePhone").GetValue(user);
            if (MobilePhoneValue != null)
            {
                MobilePhoneTextBox.SendKeys(user.MobilePhone);
            }

            var AddressAliasValue = user.GetType().GetRuntimeProperty("AddressAlias").GetValue(user);
            if (AddressAliasValue != null)
            {
                AddressAliasTextBox.SendKeys(user.AddressAlias);
            }

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
