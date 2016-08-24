using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class TestFunctions
    {
        static RemoteWebDriver driver;

        public static RemoteWebDriver Driver
        {
            get
            {
                if (driver == null)
                    driver = new ChromeDriver(@"C:\Users\Vsevolod\Documents\TestSelenium\Test");
                return driver;
            }
        }

        public static void OpenURL(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public static void WaitReady()
        {
            Func<bool> ready = () => (bool)Driver.ExecuteScript("return document.readyState == 'complete'");
            while (!ready())
            {
                Thread.Sleep(100);
            }
        }

        public static IWebElement FindItem(Item item)
        {
            if (item.ID != "")
                return Driver.FindElementById(item.ID);

            if (item.name != "")
                return Driver.FindElementByClassName(item.name);

            return null;
        }
    }
}
