using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Story2.WrapperFactory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Story2.PageObjects
{
    public class ResetPasswordPage
    {
        [FindsBy(How = How.Id, Using = "form_email")]
        private IWebElement inputFiled;

        [FindsBy(How = How.Id, Using = "form_email-error")]
        private IWebElement invalidEmailError;

        [FindsBy(How = How.Id, Using = "alertxx")]
        private IWebElement noUserError;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div/form[1]/div[2]/div/button")]
        private IWebElement resetButton;

        public void GoResetError(string wrongEmails) 
        {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div/div/form[1]/div[2]/div/button")));
  
            inputFiled.SendKeys(wrongEmails);
            resetButton.Click();
            Thread.Sleep(3000);
        }

        public void GoResetAssert(string errorMessage)
        {
            String existedInput = inputFiled.Text;

            if (existedInput == "e")
            {
                String actualError1 = invalidEmailError.Text;
                String expectedError1 = errorMessage;
                Assert.AreEqual(actualError1, expectedError1);
            } 
            else if (existedInput == "e@outlook.com")
            {
                String actualError2 = noUserError.Text;
                String expectedError2 = errorMessage;
                Assert.AreEqual(actualError2, expectedError2);
            }

            BrowserFactory.CloseAllDriver();      
        }
    }
}
