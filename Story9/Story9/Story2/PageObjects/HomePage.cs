using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Story2.WrapperFactory;
using System;


namespace Story2.PageObjects
{
    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/nav/div/ul/li[2]/a")]
        private IWebElement loginLink;

        public void SelectLogin()
       {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/header/nav/div/ul/li[2]/a")));

            loginLink.Click();         
        }
    }
}
