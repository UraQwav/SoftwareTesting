using System;
using System.Collections.Generic;
using System.Text;
using Web.SetUp;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Web.Pages
{
    public class HomePage
    {
        #region SearchForm
        [FindsBy(How = How.XPath, Using = "//div[@class='flt-input gws-flights__flex-box gws-flights__flex-filler gws-flights-form__departure-input gws-flights-form__round-trip']")]
        public IWebElement DatePickerShow { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@id='flt-pax-button']")]
        public IWebElement PassengerPickerShow { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='RW1Yff']")]
        public IWebElement AddPassengerAdult { get; set; }
        #endregion

        #region DatePickerElements
        [FindsBy(How = How.XPath, Using = "//div[@class='gws-travel-calendar__flipper gws-travel-calendar__next']")]
        public IWebElement NextButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//calendar-day[@data-day='2019-12-01']")]
        public IWebElement DatePickerPastDate { get; set; }
        [FindsBy(How = How.XPath, Using = "//calendar-day[@data-day='2020-10-31']")]
        public IWebElement DatePickerFutureDate { get; set; }
        #endregion
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
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
    }
}
