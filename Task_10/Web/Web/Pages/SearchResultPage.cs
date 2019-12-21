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
    public class SearchResultPage
    {
        #region SearchResult
        [FindsBy(How = How.XPath, Using = "//span[@id='gws-flights-results__best_flights_heading']")]
        private IWebElement bestSearchResultElement;
        #endregion

        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public bool IsDisplaySearchResult()
        {
            return bestSearchResultElement.Displayed;
        }
    }
}
