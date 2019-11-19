using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Web.SetUp
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
}
