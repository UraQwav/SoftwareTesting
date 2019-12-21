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
    public class FlightOfferPage
    {
        #region OfferResult
        
        [FindsBy(How = How.XPath, Using = "//div[@style='z-index: 3; position: absolute; height: 100%; width: 100%; padding: 0px; border-width: 0px; margin: 0px; left: 0px; top: 0px; touch-action: pan-x pan-y;']")]
        private IWebElement OfferSearchResultElement;
        #endregion
        public FlightOfferPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public bool IsDisplayOfferResult(IWebDriver driver)
        {
           
            return OfferSearchResultElement.Displayed;
        }
    }
}
