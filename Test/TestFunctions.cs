using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    driver = new ChromeDriver(".");
                return driver;
            }
        }

        /// <summary>
        /// Opens the webpage
        /// </summary>
        /// <param name="URL">web page URL</param>
        public static void OpenURL(string URL)
        {
            Driver.ExecuteScript(string.Format("document.location = {0}", EscapeJsLiteral(URL)));
        }

        /// <summary>
        /// Expects the page to load
        /// </summary>
        /// <param name="timeout">completion waiting time</param>
        public static void WaitReady(int timeout)
        {
            Stopwatch stopwatch = new Stopwatch();
            Func<bool> ready = () => (bool)Driver.ExecuteScript("return document.readyState == 'complete'");
            stopwatch.Start();
            while (!ready() && stopwatch.ElapsedMilliseconds < timeout)
            {
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Searches for an web item on ID or classname
        /// </summary>
        /// <param name="item">web item</param>
        /// <returns></returns>
        public static IWebElement FindItem(Item item)
        {
            if (item.ID != "")
                return Driver.FindElementById(item.ID);

            if (item.name != "")
                return Driver.FindElementByClassName(item.name);

            return null;
        }

        /// <summary>
        /// Creates a string literal for Js
        /// </summary>
        /// <param name="literal">string to JS</param>
        /// <returns></returns>
        public static string EscapeJsLiteral(string literal)
        {
            return string.Format("'{0}'", literal.Replace("\\", "\\\\").Replace("'", "\\'"));
        }
    }
}
