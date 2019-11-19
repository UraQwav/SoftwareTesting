using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Web
{
    public abstract class SetUpTest
    {
        protected IWebDriver webDriver;
        [SetUp]
        public void StartBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.google.com/flights/");
        }
        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
        protected IWebElement GetWebElement(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
    public class Tests : SetUpTest 
    {
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
        public void TestObtainPastDate()
        {
            IWebElement datePickerShow = GetWebElement("//div[@class='flt-input gws-flights__flex-box gws-flights__flex-filler gws-flights-form__departure-input gws-flights-form__round-trip']");
            datePickerShow.Click();
            IWebElement datePickerPastDate = GetWebElement("//calendar-day[@data-day='2019-11-02']");
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                datePickerPastDate.Click();
            Assert.IsTrue(IsDisabledCalendarDate(datePickerPastDate));
        }
        [Test]
        public void TestObtainFutureDate()
        {
            int NumberSlideinDatePicker = 9;
            IWebElement datePickerShow = GetWebElement("//div[@class='flt-input gws-flights__flex-box gws-flights__flex-filler gws-flights-form__departure-input gws-flights-form__round-trip']");
            datePickerShow.Click();
            IWebElement nextButton = GetWebElement("//div[@class='gws-travel-calendar__flipper gws-travel-calendar__next']");
            for (int numberOfClick = NumberSlideinDatePicker; numberOfClick > 0; numberOfClick--)
                nextButton.Click();
            IWebElement datePickerFutureDate = GetWebElement("//calendar-day[@data-day='2020-10-20']");
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                datePickerFutureDate.Click();
            Assert.IsTrue(IsDisabledCalendarDate(datePickerFutureDate));
        }
        
        [Test]
        public void TestObtainMaxPassengerAdultTicket()
        {
            int MaxNumberPassengersAdultTicket = 10;
            IWebElement PassengerPickerShow = GetWebElement("//div[@id='flt-pax-button']");
            PassengerPickerShow.Click();
            IWebElement addPassengerAdult = GetWebElement("//div[@class='gws-flights-widgets-numberpicker__flipper']");
            for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
                addPassengerAdult.Click();
            Assert.IsTrue(IsDisabledAddPassengersAdult(addPassengerAdult));
        }
    }
}