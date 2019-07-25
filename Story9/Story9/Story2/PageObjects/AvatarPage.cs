using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Story2.WrapperFactory;
using System;
using System.Threading;


namespace Story2.PageObjects
{
    public class AvatarPage
    {
        public void AssertAvatarImage()
        {
            //waiting for loading 
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/a/img")));

            //assert avatar image is presented
            Assert.IsTrue(BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/a/img")).Displayed);
        }

        public void LogoutAvatar()
        {
            //logout through URL
            BrowserFactory.Driver.Url= "http://lyratesting2.co.nz/logout";       
        }

        public void AssertLoginScreen()
        {
            Thread.Sleep(3000);

            //Assert current screen in login screen
            String currentUrl = BrowserFactory.Driver.Url;
            Assert.AreEqual(currentUrl, "http://lyratesting2.co.nz/login");        
        }

        public void ClickSetting()
        {
            //click avatar personal setting
            BrowserFactory.Driver.Url = "http://lyratesting2.co.nz/settings/";
        }

    }
}
