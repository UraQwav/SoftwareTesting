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
using Web.Services;
using AShotNet;
using System.Threading.Tasks;
using System.Drawing;
using AShotNet.Cropper.Indent;
using AShotNet.Util;
using AShotNet.Coordinates;

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
        
        [Test]
        public void TestToVerifyTheIssuanceOfSearchResult()
        {
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                    .InputValueInTheSearchBar(RouteCreator.WithAllProperties(), Driver);
                Assert.IsTrue(new SearchResultPage(Driver).IsDisplaySearchResult());
            });
        }
        [Test]
        public void TestObtainMaxPassengerAdultTicket()
        {
            HomePage homePage = new HomePage(Driver)
                                    .AddAdultPassenger();
            Assert.IsTrue(homePage.IsDisabledAddPassengersAdult(homePage.AddPassenger[homePage.selectAdultPassenger]));
        }
        [Test]
        public void TestObtainMaxPassengerAdultTicketWithInfantsOnSlap()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                     .AddAdultAndInfantsOnSlapPassenger();
                Assert.IsTrue(homePage.ErrorMessage.Displayed);
            });
        }
        [Test]
        public void TestToVerifyTheIssuanceOfOfferResult()
        {
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                    .InputValueInTheSearchBarWithoutArrivalCity(Driver);
                Assert.IsTrue(new FlightOfferPage(Driver).IsDisplayOfferResult(Driver));
            });
        }
        [Test]
        public void TestToOpenSuggestedTripsFromDepartureCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                       .OpenSuggestedTripsFromDepartureCity(Driver);
                Assert.IsTrue(new SearchResultPage(Driver).IsDisplaySearchResult());
            });
        }
        [Test]
        public void TestToSignInUser()
        {
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                        .OpenSignInPage(Driver);
                
                new SignInPage(Driver)
                        .InputValueOfSignInPage(Driver);
                Assert.IsTrue(new HomePage(Driver).IsSignInComplite());
            });
        }
        [Test]
        public void TestObtainMaxPassengerAdultTicketWithInfants()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                     .AddAdultAndInfantsPassenger();
                Assert.IsTrue(homePage.ErrorMessage.Displayed);
            });
        }
        [Test]
        public void TestObtainMaxPassengerAdultTicketWithInfantsAndChildrens()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                     .AddAdultAndInfantsAndChildrenPassenger();
                Assert.IsTrue(homePage.ErrorMessage.Displayed);
            });
        }
    }
}