using NUnit.Framework;
using OpenQA.Selenium;
using Story2.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story2.PageObjects
{
    public class InfoSetPage
    {
        public void ProfileUpdate()
        {
            BrowserFactory.Driver.FindElement(By.Id("profile-save-btn")).Click();
        }

        public void UpdateAssert()
        {
            String alertSuccess = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]")).Text;
            Assert.IsTrue(alertSuccess.Equals("基础信息保存成功。"));          
        }
        
        public void ErrorInput()
        {
            //profile_truename 
            BrowserFactory.Driver.FindElement(By.Id("profile_truename")).SendKeys("eeeeeeeeeeeeeeeeeeeeeeeeee");
            BrowserFactory.Driver.FindElement(By.Id("profile_truename")).SendKeys(Keys.Return);

            //profile_idcard
            BrowserFactory.Driver.FindElement(By.Id("profile_idcard")).SendKeys("e");
            BrowserFactory.Driver.FindElement(By.Id("profile_idcard")).SendKeys(Keys.Return);

            //profile_mobile
            BrowserFactory.Driver.FindElement(By.Id("profile_mobile")).SendKeys("e");
            BrowserFactory.Driver.FindElement(By.Id("profile_idcard")).SendKeys(Keys.Return);

            //profile_title
            BrowserFactory.Driver.FindElement(By.Id("profile_title")).SendKeys("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            BrowserFactory.Driver.FindElement(By.Id("profile_title")).SendKeys(Keys.Return);

            //profile_site
            BrowserFactory.Driver.FindElement(By.Id("profile_site")).SendKeys("e");
            BrowserFactory.Driver.FindElement(By.Id("profile_site")).SendKeys(Keys.Return);

            //weibo
            BrowserFactory.Driver.FindElement(By.Id("weibo")).SendKeys("e");
            BrowserFactory.Driver.FindElement(By.Id("weibo")).SendKeys(Keys.Return);

            //profile_qq
            BrowserFactory.Driver.FindElement(By.Id("profile_qq")).SendKeys("e");
            BrowserFactory.Driver.FindElement(By.Id("profile_qq")).SendKeys(Keys.Return);

        }
        public void ErrorMsgAssert()
        {
            //profile_truename 
            String truenameError = BrowserFactory.Driver.FindElement(By.Id("profile_truename-error")).Text;
            Assert.AreEqual(truenameError, "最多只能输入 18 个字符");

            //profile_idcard
            String idcardError = BrowserFactory.Driver.FindElement(By.Id("profile_idcard-error")).Text;
            Assert.AreEqual(idcardError, "请正确输入您的身份证号码");

            //profile_mobile
            String mobileError = BrowserFactory.Driver.FindElement(By.Id("profile_mobile-error")).Text;
            Assert.AreEqual(mobileError, "请输入正确的手机号");

            //profile_title
            String titleError = BrowserFactory.Driver.FindElement(By.Id("profile_title-error")).Text;
            Assert.AreEqual(titleError, "最多只能输入 24 个字符");

            //profile_site
            String siteError = BrowserFactory.Driver.FindElement(By.Id("profile_site-error")).Text;
            Assert.AreEqual(siteError, "地址不正确，须以http://或者https://开头。");

            //weibo
            String weiboError = BrowserFactory.Driver.FindElement(By.Id("weibo-error")).Text;
            Assert.AreEqual(weiboError, "地址不正确，须以http://或者https://开头。");

            //profile_qq
            String qqError = BrowserFactory.Driver.FindElement(By.Id("profile_qq-error")).Text;
            Assert.AreEqual(qqError, "请输入正确的QQ号");
        }
    }
}
