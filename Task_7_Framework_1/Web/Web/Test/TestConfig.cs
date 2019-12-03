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
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
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
