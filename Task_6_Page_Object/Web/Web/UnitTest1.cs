using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Web.SetUp;
using Web.Pages;

namespace Web
{
    [TestFixture]
    public class Tests : SetUpTest
    {
        #region Page
        HomePage homePage = new HomePage();
        #endregion
        public Boolean IsDisabledAddPassengersAdult(IWebElement element)
        {
            string disabled = element.GetAttribute("aria-disabled");
            return disabled != null;
        }
        public Boolean IsDisabledCalendarDate(IWebElement element)
        {
            string disabledClassName = "gws-travel-calendar__day gws-travel-calendar__disabled";
            string disabled = element.GetAttribute("class");
            return disabled == disabledClassName;
        }

        [Test]
        public void CheckPastDate()
        {
            //PageFactory.InitElements(webDriver, homePage)
            homePage.DatePickerPastDate.Click();
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                homePage.DatePickerPastDate.Click();
            Assert.IsTrue(IsDisabledCalendarDate(homePage.DatePickerPastDate));
        }
        [Test]
        public void CheckFutureDate()
        {
            PageFactory.InitElements(webDriver, homePage);
            homePage.DatePickerPastDate.Click();
            for (int numberOfClick = 9; numberOfClick > 0; numberOfClick--)
                homePage.NextButton.Click();
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                homePage.DatePickerFutureDate.Click();
            Assert.IsTrue(IsDisabledCalendarDate(homePage.DatePickerFutureDate));
        }

        [Test]
        public void CheckMaxPassengerAdultTicket()
        {
            int MaxNumberPassengersAdultTicket = 10;
            homePage.PassengerPickerShow.Click();
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                homePage.AddPassengerAdult.Click();
            Assert.IsTrue(IsDisabledAddPassengersAdult(homePage.AddPassengerAdult));
        }
    }
}