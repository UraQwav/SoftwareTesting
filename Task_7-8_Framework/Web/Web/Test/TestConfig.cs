using AShotNet.Coordinates;
using AShotNet;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Web.SetUp;
namespace Web.Test
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Driver = SetUpWebDriver.GetDriver();
            Driver.Navigate().GoToUrl("https://www.google.com/flights/");
        }

        protected void MakeScreenshotWhenFail(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                new AShot()
                    .CoordsProvider(new WebDriverCoordsProvider()) 
                    .TakeScreenshot(Driver)
                    .getImage()
                    .Save($@"{AppDomain.CurrentDomain.BaseDirectory}\ScreenShot\screen_{ DateTime.Now.ToString("yy-MM-dd_hh-mm-ss")}.png");
                throw;
            }
        }

        [TearDown]
        public void ClearDriver()
        {
            SetUpWebDriver.CloseDriver();
        }
    }
}
