using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Story2.WrapperFactory;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Story2.PageObjects
{
    public class InfoMgtPage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/form/button")]
        private IWebElement searchButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div/div/a")]
        private IWebElement creatButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[6]/span")]
        private IWebElement originalStatus;

        public void GoInfoMgtPage()
        {
            //load info management page
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/");
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/ul[1]/li[4]/a")));

            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/article");
            WebDriverWait wait2 = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/form/button")));
        }

        public void DoFilterSearch()
        {
            //Category
            BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/form/div[1]/div/a/span[1]")).Click();
            BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[7]/div/input")).SendKeys("EduSoho");
            BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[7]/div/input")).SendKeys(OpenQA.Selenium.Keys.Enter);

            //Keyword
            BrowserFactory.Driver.FindElement(By.Name("keywords")).SendKeys("世界");

            //Property
            var property = BrowserFactory.Driver.FindElement(By.Name("property"));
            var selectProperty = new SelectElement(property);
            selectProperty.SelectByValue("sticky");

            //Status
            SelectElement status = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("status")));
            status.SelectByValue("unpublished");

            //go search
            searchButton.Click();

            Thread.Sleep(3000);
        }

        public void AssertFilterResult()
        {
            //assert filter result is right 
            String text1 = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[2]/span/a")).Text;
            Assert.IsTrue(text1.Contains("世界"));

            String text2 = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[3]/span/a")).Text;
            Assert.AreEqual(text2, "EduSoho");

            String text3 = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[6]/span")).Text;
            Assert.AreEqual(text3, "未发布");
        }

        public void DoStatusChange()
        {
            //click edit button
            BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[7]/div/a[2]")).Click();
            Thread.Sleep(3000);
        
            //choose publish or unpublish           
            BrowserFactory.Driver.FindElement(By.CssSelector(".open > ul:nth-child(3) > li:nth-child(1)")).Click();
            Thread.Sleep(3000);
        }

        public void AssertStatusUpdate()
        {
            //assert updated status
            String newStatus = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[6]/span")).Text;
            Assert.AreNotEqual(newStatus, originalStatus);
        }

        public void GoArticlePage()
        {
            //load page
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/article/category");
        }

        public void DoAddCategory()
        {
            //click add button
            creatButton.Click();
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));

            //add name
            BrowserFactory.Driver.FindElement(By.Id("category-name-field")).SendKeys("newtest");

            //add text
            BrowserFactory.Driver.FindElement(By.Id("category-code-field")).SendKeys("testing");

            //save 
            BrowserFactory.Driver.FindElement(By.Id("category-save-btn")).Click();
            Thread.Sleep(3000);
        }

        public void AssertAddedCategory()
        {         
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[3]/div/div[3]")));

            //assert new category is added   
            String addItem = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[3]/div/div[3]")).Text;
            Assert.AreEqual(addItem,"testing");
        }

        public void DoEditCategory()
        {
            //click edit button
            BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[3]/div/div[4]/a[1]")).Click();
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));

            //change category name 
            BrowserFactory.Driver.FindElement(By.Id("category-name-field")).Clear();
            BrowserFactory.Driver.FindElement(By.Id("category-name-field")).SendKeys("new name");

            //save 
            BrowserFactory.Driver.FindElement(By.Id("category-save-btn")).Click();
            Thread.Sleep(3000);
        }

        public void AssertChangedName()
        {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[3]/div/div[1]")));

            //category name is changed    
            String changeItem = BrowserFactory.Driver.FindElement(By.XPath("html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[3]/div/div[1]")).Text;
            Assert.AreEqual(changeItem, "new name");
        }

        public void DoDeleteAdd()
        {   
            //click edit button
            BrowserFactory.Driver.FindElement(By.XPath("html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[3]/div/div[4]/a[1]")).Click();

            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));

            //delete the new add category
            BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/button[1]")).Click();
            IAlert alert = BrowserFactory.Driver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(3000);
        }

    }
}
