using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Story2.WrapperFactory;
using System;

namespace Story2.PageObjects
{
    public class LoginPage
    {     
        [FindsBy(How = How.Id, Using = "login_username")]
        private IWebElement userName;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement passWord;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/form/div[4]")]
        private IWebElement submitUser;

        [FindsBy(How = How.CssSelector, Using = "div.controls:nth-child(1) > input:nth-child(1)")]
        private IWebElement checkRememberMe;

        public void ValidLogin()
        {
            //wating for loading
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            //input the valid uername and password
            userName.SendKeys("test001");
            passWord.SendKeys("Test1234");

            //unselected the RememberMe checkbox
            if (checkRememberMe.Selected)
            {
                checkRememberMe.Click();
            }

            //login button
            submitUser.Click();
        }

        public void SelectRememberMe()
        {
            //waiting for loading
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            //input the valid uername and password
            userName.SendKeys("test001");
            passWord.SendKeys("Test1234");

            //select RememberMe checkbox
            if (!checkRememberMe.Selected)
            {
                checkRememberMe.Click();
            }

            //login button
            submitUser.Click();
        }

        public void InvaildLogin()
        {
            //waiting for loading
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            //input the invalid username and password
            userName.SendKeys("test002");
            passWord.SendKeys("Test4444");

            //unselected the RememberMe checkbox
            if (checkRememberMe.Selected)
            {
                checkRememberMe.Click();
            }

            //login button
            submitUser.Click();
        }

        public void AssertError()
        {
            //waiting for loading
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_password")));

            //asset error message of an invaid user
            var errorMessage = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/form/div[1]")).Text;
            Assert.AreEqual(errorMessage, "用户名或密码错误");
        }

        public void GoRegisterPage()
        {
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/register?goto=/");
        }

        public void GoFindPassword()
        {
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/password/reset");
        }

        public void GoAdminLogin()
        {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            userName.SendKeys("admin");
            passWord.SendKeys("5EstafeyEtre");

            if (checkRememberMe.Selected)
            {
                checkRememberMe.Click();
            }

            submitUser.Click();
        }
    }
}
