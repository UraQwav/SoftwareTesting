using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Web.SetUp;
using Web.Services;

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
                Logger.Log.Error(new Exception()+$"\n");
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile($@"{AppDomain.CurrentDomain.BaseDirectory}\screens\screen_{ DateTime.Now.ToString("yy-MM-dd_hh-mm-ss")}.png");
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
