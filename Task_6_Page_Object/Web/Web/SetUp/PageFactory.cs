using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI; 

namespace Web.SetUp
{
    [Obsolete]
    public class PageFactory
    {
        public extern static T InitElements<T>(IWebDriver driver);
        public extern static T InitElements<T>(IElementLocator locator);
        public extern static void InitElements(ISearchContext driver, object page);
        public extern static void InitElements(ISearchContext driver, object page, IPageObjectMemberDecorator decorator);
        public extern static void InitElements(object page, IElementLocator locator);
        public extern static void InitElements(object page, IElementLocator locator, IPageObjectMemberDecorator decorator);
    }
}
