using System;
using System.Collections.Generic;
using System.Text;
using Web.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Web.Pages
{
    class HomePage:BasePage
    {
        #region SearchForm
            [FindsBy(How = How.XPath, Using = "//div[@class='flt-input gws-flights__flex-box gws-flights__flex-filler gws-flights-form__departure-input gws-flights-form__round-trip']")]
            public IWebElement DatePickerShow { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[@id='flt-pax-button']")]
            public IWebElement PassengerPickerShow { get; set; }
            [FindsBy(How = How.XPath, Using = "//div[@class='gws-flights-widgets-numberpicker__flipper']")]
            public IWebElement AddPassengerAdult { get; set; }
        #endregion

        #region DatePickerElements
        [FindsBy(How = How.CssSelector, Using = "//div[@class='gws-travel-calendar__flipper gws-travel-calendar__next']")]
            public IWebElement NextButton { get; set; }
            [FindsBy(How = How.CssSelector, Using = "//calendar-day[@data-day='2019-11-02']")]
            public IWebElement DatePickerPastDate { get; set; }
            [FindsBy(How = How.CssSelector, Using = "//calendar-day[@data-day='2020-10-20']")]
            public IWebElement DatePickerFutureDate { get; set; }
        #endregion
    }
}
