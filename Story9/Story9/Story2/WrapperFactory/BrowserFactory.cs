using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Story2.WrapperFactory
{
    class BrowserFactory
    {
        public static IWebDriver driver;

        public static IWebDriver Driver
        {
            get { return driver; }          
        }

        public static void InitBrowser()
        {
            driver = new FirefoxDriver();
        }

        public static void LoadApplication()
        {
            Driver.Navigate().GoToUrl("http://lyratesting2.co.nz/");
        }

        public static void CloseAllDriver()
        {
            Driver.Close();
        }
    }
}
