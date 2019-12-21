using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Web.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Web.SetUp
{
    class SetUpWebDriver
    {
        static IWebDriver driver;
        private SetUpWebDriver() { }
        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "FireFox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
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
 