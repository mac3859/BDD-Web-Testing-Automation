using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using Story2.WrapperFactory;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Story2.PageObjects
{
    public class SettingPage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[1]/div/ul/li[3]/a")]
        private IWebElement picSetting;
        [FindsBy(How = How.Name, Using = "file")]
        private IWebElement clickButton;
        [FindsBy(How = How.Id, Using = "upload-avatar-btn")]
        private IWebElement saveButton;

        public void GoPicUpload()
        {       
            picSetting.Click();
            clickButton.SendKeys(@"C:\Users\cxh\source\repos\Story2\Story2\youtube.PNG");

            //SendKeys.SendWait(@"C:\Users\cxh\source\repos\Story2\Story2\youtube.PNG");
            //SendKeys.SendWait(@"{Enter}");

            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("upload-avatar-btn")));

            saveButton.Click();

            Thread.Sleep(4000);
        }

    }

}  
