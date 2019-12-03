using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Web.SetUp;
using Web.Pages;
using System;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using Web.Test;
namespace Web
{
    public class Tests : TestConfig
    {
       
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        #region Page
        #endregion
       

        [Test]
        public void TestObtainPastDate()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver);
                homePage.DatePickerShow.Click();
                Thread.Sleep(1000);
                for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                {
                    Thread.Sleep(5000);
                    homePage.DatePickerPastDate.Click();
                }
                Assert.IsTrue(homePage.IsDisabledCalendarDate(homePage.DatePickerPastDate));
            });
        }
        [Test]
        public void TestObtainFutureDate()
        {
            HomePage homePage = new HomePage(Driver);
            int NumberNextMonthDatePicker = 9;
            homePage.DatePickerShow.Click();
            for (int numberOfClick = NumberNextMonthDatePicker; numberOfClick > 0; numberOfClick--)
                homePage.NextButton.Click();
            for (int numberOfClick = 2; numberOfClick > 0; numberOfClick--)
                homePage.DatePickerFutureDate.Click();
            Assert.IsTrue(homePage.IsDisabledCalendarDate(homePage.DatePickerFutureDate));
        }

        //[Test]
        //public void TestObtainMaxPassengerAdultTicket()
        //{
        //    PageFactory.InitElements(webDriver, homePage);
        //    int MaxNumberPassengersAdultTicket = 10;
        //    homePage.PassengerPickerShow.Click();

        //    for (int numberOfClick = MaxNumberPassengersAdultTicket; numberOfClick > 0; numberOfClick--)
        //    {
        //        if (homePage.AddPassengerAdult.FindElement(By.XPath("./label[contains(text(), 'Adult')]")).Text=="Adult")
        //        homePage.AddPassengerAdult.FindElement(By.XPath("./div/div[@class='gws-flights-widgets-numberpicker__flipper'][@aria-label='Increase']")).Click();
        //    }
        //    Assert.IsTrue(IsDisabledAddPassengersAdult(homePage.AddPassengerAdult.FindElement(By.XPath("./div/div[@class='gws-flights-widgets-numberpicker__flipper'][@aria-label='Increase']"))));
        //}
    }
}