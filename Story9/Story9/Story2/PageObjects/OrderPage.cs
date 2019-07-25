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
    public class OrderPage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/form/div[2]/button")]
        private IWebElement searchButton;
        [FindsBy(How = How.Id, Using = "startDate")]
        private IWebElement startDate;

        public void GoCourseOrderPage()
        {   
            //load course order page
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/");
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/ul[1]/li[4]/a")));
           
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/course/order/manage");
            WebDriverWait wait2 = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[1]/div/a[1]")));
        }

        public void GoClassOrderPage()
        {
            //load class order page
            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/");
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div[2]/ul[1]/li[4]/a")));

            BrowserFactory.Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/admin/classroom/order");
            WebDriverWait wait2 = new WebDriverWait(BrowserFactory.Driver, new TimeSpan(0, 0, 5));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/form/div[2]/button")));
        }

        public void GoSearch()
        {
            //click search button
            searchButton.Click();
        }

        public void DoCourseSearch()
        {
            SelectElement status = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("status")));
            SelectElement payment = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("payment")));
            SelectElement keyword = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("keywordType")));

            //date
            startDate.SendKeys("2017-12-14 22:51");
            startDate.Click();

            //statue           
            status.SelectByValue("paid");

            //payment method         
            payment.SelectByValue("alipay");

            //keyword type
            keyword.SelectByValue("courseSetTitle");
        }

        public void DoClassSearch()
        {
            SelectElement status = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("status")));
            SelectElement payment = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("payment")));
            SelectElement keyword = new SelectElement(BrowserFactory.Driver.FindElement(By.Name("keywordType")));

            //date
            startDate.SendKeys("2017-12-14 22:51");
            startDate.Click();

            //statue           
            status.SelectByValue("paid");

            //payment method         
            payment.SelectByValue("alipay");

            //keyword type
            keyword.SelectByValue("targetId");
        }

        public void AssertDefaultSearch()
        {
            Assert.IsTrue(BrowserFactory.Driver.FindElement(By.Id("order-table")).Displayed);
        }

        public void AssertSearch()
        {
            String actualResult = BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/table/tbody/tr/td/div")).Text;
            String expectResult = "暂无订单记录";
            Assert.AreEqual(actualResult, expectResult);
        }

    }
}
