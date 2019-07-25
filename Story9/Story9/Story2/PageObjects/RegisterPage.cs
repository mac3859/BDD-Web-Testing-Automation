using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Story2.WrapperFactory;
using System;
using System.Threading;

namespace Story2.PageObjects
{
    public class RegisterPage
    {      
        [FindsBy(How = How.Id, Using = "register_email")]
        private IWebElement registerEmail;

        [FindsBy(How = How.Id, Using = "register_nickname")]
        private IWebElement registerNickname;

        [FindsBy(How = How.Id, Using = "register_password")]
        private IWebElement registerPassword;

        [FindsBy(How = How.Id, Using = "captcha_code")]
        private IWebElement registerCaptcha;

        [FindsBy(How = How.Id, Using = "register-btn")]
        private IWebElement registerButton;

        public void InputInvalidRegister()
        {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register-form")));

            registerEmail.SendKeys("e");
            registerNickname.SendKeys("eeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            registerPassword.SendKeys("e");
            registerCaptcha.SendKeys("e");
            
            registerButton.Click();

            Thread.Sleep(3000);          
        }

        public void AssertInvalidRegister()
        {
            //verify Email error text 
            String actualError1 = BrowserFactory.Driver.FindElement(By.Id("register_email-error")).Text;
            String expectError1 = "请输入有效的电子邮件地址";
            Assert.AreEqual(actualError1, expectError1);

            //verify Nickname error text
            String actualError2 = BrowserFactory.Driver.FindElement(By.Id("register_nickname-error")).Text;
            String expectError2 = "字符长度必须小于等于18，一个中文字算2个字符";
            Assert.AreEqual(actualError2, expectError2);

            //verify Password error text
            String actualError3 = BrowserFactory.Driver.FindElement(By.Id("register_password-error")).Text;
            String expectError3 = "最少需要输入 5 个字符";
            Assert.AreEqual(actualError3, expectError3);

            //verify Captcha error text
            String actualError4 = BrowserFactory.Driver.FindElement(By.Id("captcha_code-error")).Text;
            String expectError4 = "验证码错误";
            Assert.AreEqual(actualError4, expectError4);
        }
    }
}
