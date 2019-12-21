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
    public class SignInPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        public IWebElement Login;
        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement Password;
        [FindsBy(How = How.XPath, Using = "//div[@id='identifierNext']")]
        public IWebElement NextButton;
        public SignInPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public HomePage InputValueOfSignInPage(IWebDriver Driver)
        {
            Login.SendKeys(UserSignIn.WithAllProperties().Login);
            NextButton.Click();
            WebDriverWait wait=new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='password']")));
            Password.SendKeys(UserSignIn.WithAllProperties().Password);
            Password.SendKeys(Keys.Enter);
            return new HomePage(Driver);
        }
    }
}
