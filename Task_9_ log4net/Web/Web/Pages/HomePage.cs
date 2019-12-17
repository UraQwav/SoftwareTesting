using System;
using System.Collections.Generic;
using System.Text;
using Web.SetUp;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Web.Models;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Web.Services;

namespace Web.Pages
{
    public class HomePage
    {
        #region SearchForm
        [FindsBy(How = How.XPath, Using = "//div[@class='flt-input gws-flights__flex-box gws-flights__flex-filler gws-flights-form__departure-input gws-flights-form__round-trip']")]
        public IWebElement DatePickerShow;
        [FindsBy(How = How.XPath, Using = "//div[@id='flt-pax-button']")]
        public IWebElement PassengerPickerShow;
        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Increase']")]
        public IList<IWebElement> AddPassenger;
        public int selectAdultPassenger = 0;
        public int selectChildrenPassenger = 1;
        public int selectInfantsPassenger = 2;
        public int selectInfantsOnSlapPassenger = 3;
        [FindsBy(How = How.XPath, Using = "//floating-action-button[@class='gws-flights-form__search-button flt-form-sb gws-flights-fab__mini']")]
        public IWebElement SearchButton;
        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        public IWebElement ErrorMessage;
        #endregion

        #region DatePickerElements
        [FindsBy(How = How.XPath, Using = "//div[@class='gws-travel-calendar__flipper gws-travel-calendar__next']")]
        public IWebElement NextButton;
        [FindsBy(How = How.XPath, Using = "//calendar-day[@data-day='2019-12-01']")]
        public IWebElement DatePickerPastDate;
        [FindsBy(How = How.XPath, Using = "//calendar-day[@data-day='2020-11-30']")]
        public IWebElement DatePickerFutureDate;
        #endregion

        #region CityInput
        [FindsBy(How = How.XPath, Using = "//*[@id='flt-app']/div[2]/main[1]/div[4]/div/div[3]/div/div[2]/div[2]")]
        public IWebElement GoArrivalCityButton;
        [FindsBy(How = How.XPath, Using = "//input[@data-placeholder='Where to?']")]
        public IWebElement GoArrivalCityInput;
        #endregion

        #region SuggestedTrips
        [FindsBy(How = How.XPath, Using = "//div[@data-flt-ve-index='0'][@class='gws-flights-results__destination-result-button uKOpFp4SF2X__card uKOpFp4SF2X__with-dates']")]
        public IWebElement SuggestedTripsFromDepartureCity;
        #endregion

        #region SignIn
        [FindsBy(How = How.XPath, Using = "//a[@class='gb_4 gb_5 gb_9d gb_Vc']")]
        public IWebElement SignInButton;
        [FindsBy(How = How.XPath, Using = " //a[@class='gb_D gb_Oa gb_i']")]
        public IWebElement IsSign;
        #endregion
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public bool IsDisabledAddPassengersAdult(IWebElement element)
        {
            string disabled = element.GetAttribute("aria-disabled");
            return disabled != null;
        }
        public bool IsDisabledCalendarDate(IWebElement element)
        {
            string disabledClassName = "gws-travel-calendar__day gws-travel-calendar__disabled";
            string disabled = element.GetAttribute("class");
            return disabled == disabledClassName;
        }
        public HomePage ClickDatePickerPastDate()
        {
            DatePickerShow.Click();
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                DatePickerPastDate.Click();
            return this;
        }
        public HomePage ClickDatePickerFutureDate()
        {
            int NumberNextMonthDatePicker = 9;
            DatePickerShow.Click();
            for (int numberOfClick = NumberNextMonthDatePicker; numberOfClick > 0; numberOfClick--)
                NextButton.Click();
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                DatePickerFutureDate.Click();
            return this;
        }
        public HomePage AddAdultPassenger()
        {
            int MaxNumberPassengersAdultTicket = 10;
            PassengerPickerShow.Click();
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                AddPassenger[selectAdultPassenger].Click();
            return this;
        }
        public HomePage AddAdultAndInfantsOnSlapPassenger()
        {
            int MaxNumberPassengersAdultTicket = 2;
            PassengerPickerShow.Click();
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                AddPassenger[selectInfantsOnSlapPassenger].Click();
            return this;
        }
        public HomePage AddAdultAndInfantsPassenger()
        {
            int MaxNumberPassengersAdultTicket = 5;
            PassengerPickerShow.Click();
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                AddPassenger[selectInfantsPassenger].Click();
            return this;
        }
        public HomePage AddAdultAndInfantsAndChildrenPassenger()
        {
            int MaxNumberPassengersAdultTicket = 5;
            PassengerPickerShow.Click();
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                AddPassenger[selectChildrenPassenger].Click();
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                AddPassenger[selectInfantsPassenger].Click();
            return this;
        }
        public SearchResultPage InputValueInTheSearchBar(Route route, IWebDriver Driver)
        {
            GoArrivalCityButton.Click();
            GoArrivalCityInput.SendKeys(route.ArrivalCity);
            GoArrivalCityInput.SendKeys(Keys.Enter);
            SearchButton.Click();
            return new SearchResultPage(Driver);
        }
        public FlightOfferPage InputValueInTheSearchBarWithoutArrivalCity(IWebDriver Driver)
        {
            SearchButton.Click();
            return new FlightOfferPage(Driver);
        }
        public SearchResultPage OpenSuggestedTripsFromDepartureCity(IWebDriver Driver)
        {
            SuggestedTripsFromDepartureCity.Click();
            return new SearchResultPage(Driver);
        }
        public SignInPage OpenSignInPage(IWebDriver Driver)
        {
            SignInButton.Click();
            return new SignInPage(Driver);
        }
        public bool IsSignInComplite()
        {
            return IsSign.Displayed;
        }
    }
}
