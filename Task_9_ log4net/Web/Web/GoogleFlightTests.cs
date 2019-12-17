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
        [Category("DateTest")]
        public void TestObtainPastDate()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ObtainPastDate unit test.");
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                    .ClickDatePickerPastDate();
                Assert.IsTrue(homePage.IsDisabledCalendarDate(homePage.DatePickerPastDate));
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("DateTest")]
        public void TestObtainFutureDate()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ObtainFutureDate unit test.");
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                    .ClickDatePickerFutureDate();
                Assert.IsTrue(homePage.IsDisabledCalendarDate(homePage.DatePickerFutureDate));
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        
        [Test]
        [Category("SearchTest")]
        public void TestToVerifyTheIssuanceOfSearchResult()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ToVerifyTheIssuanceOfSearchResult unit test.");
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                    .InputValueInTheSearchBar(RouteCreator.WithAllProperties(), Driver);
                Assert.IsTrue(new SearchResultPage(Driver).IsDisplaySearchResult());
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("Passenger")]
        public void TestObtainMaxPassengerAdultTicket()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ObtainMaxPassengerAdultTicket unit test.");
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                    .AddAdultPassenger();
            Assert.IsTrue(homePage.IsDisabledAddPassengersAdult(homePage.AddPassenger[homePage.selectAdultPassenger]));
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("Passenger")]
        public void TestObtainMaxPassengerAdultTicketWithInfantsOnSlap()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ObtainMaxPassengerAdultTicketWithInfantsOnSlap unit test.");
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                     .AddAdultAndInfantsOnSlapPassenger();
                Assert.IsTrue(homePage.ErrorMessage.Displayed);
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("SearchTest")]
        public void TestToVerifyTheIssuanceOfOfferResult()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ToVerifyTheIssuanceOfOfferResult unit test.");
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                    .InputValueInTheSearchBarWithoutArrivalCity(Driver);
                Assert.IsTrue(new FlightOfferPage(Driver).IsDisplayOfferResult(Driver));
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("SearchTest")]
        public void TestToOpenSuggestedTripsFromDepartureCity()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ToOpenSuggestedTripsFromDepartureCity unit test.");
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                       .OpenSuggestedTripsFromDepartureCity(Driver);
                Assert.IsTrue(new SearchResultPage(Driver).IsDisplaySearchResult());
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("UserTest")]
        public void TestToSignInUser()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ToSignInUser unit test.");
            MakeScreenshotWhenFail(() =>
            {
                new HomePage(Driver)
                        .OpenSignInPage(Driver);
                
                new SignInPage(Driver)
                        .InputValueOfSignInPage(Driver);
                Assert.IsTrue(new HomePage(Driver).IsSignInComplite());
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("Passenger")]
        public void TestObtainMaxPassengerAdultTicketWithInfants()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ObtainMaxPassengerAdultTicketWithInfants unit test.");
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                     .AddAdultAndInfantsPassenger();
                Assert.IsTrue(homePage.ErrorMessage.Displayed);
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
        [Test]
        [Category("Passenger")]
        public void TestObtainMaxPassengerAdultTicketWithInfantsAndChildrens()
        {
            Logger.InitLogger();
            Logger.Log.Info("Start ObtainMaxPassengerAdultTicketWithInfantsAndChildrens unit test.");
            MakeScreenshotWhenFail(() =>
            {
                HomePage homePage = new HomePage(Driver)
                                     .AddAdultAndInfantsAndChildrenPassenger();
                Assert.IsTrue(homePage.ErrorMessage.Displayed);
            });
            Logger.Log.Info($"Test complete successfully\n");
        }
    }
}
