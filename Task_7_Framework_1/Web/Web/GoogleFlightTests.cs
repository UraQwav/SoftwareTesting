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
        public void TestObtainPastDate()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                    .ClickDatePickerPastDate();
                Assert.IsTrue(homePage.IsDisabledCalendarDate(homePage.DatePickerPastDate));
            });
        }
        [Test]
        public void TestObtainFutureDate()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                    .ClickDatePickerFutureDate();
                Assert.IsTrue(homePage.IsDisabledCalendarDate(homePage.DatePickerFutureDate));
            });
        }
    }
}