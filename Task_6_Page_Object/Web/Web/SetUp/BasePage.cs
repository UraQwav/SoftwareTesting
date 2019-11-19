using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Web.SetUp
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        [Obsolete]
        protected void InitPage<T>(IWebDriver driver, T page) where T : BasePage
        {
            PageFactory.InitElements(driver, page);
        }
    }
}
