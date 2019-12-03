using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Web.SetUp
{
    class SetUpWebDriver
    {
        //public  static IWebDriver webDriver;
        //[SetUp]
        //public void StartBrowser()
        //{
        //    webDriver = new ChromeDriver();
        //    webDriver.Navigate().GoToUrl("https://www.google.com/flights/");
        //}
        //[TearDown]
        //public void CloseBrowser()
        //{
        //    webDriver.Quit();
        //    webDriver.Dispose();
        //}
        //protected IWebElement GetWebElement(string xPath)
        //{
        //    return webDriver.FindElement(By.XPath(xPath));
        //}
        static IWebDriver driver;

        private SetUpWebDriver() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
 