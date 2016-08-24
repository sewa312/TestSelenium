using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;
using Test;
using System.Threading;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCase()
        {
            TestFunctions.WaitReady();
            TestFunctions.OpenURL("http//www.yandex.ru");
            //TestFunctions.Driver.ExecuteScript("document.location = 'http://yandex.ru/'");
            TestFunctions.WaitReady();
            //            driver.Navigate().GoToUrl("https//www.google.com/doodles/");
            Test.TestFunctions.Driver.FindElementByClassName(("input__box"));
            //     driver.FindElement(By.Id("gbqfq")).SendKeys(Keys.Enter);
        }

        [TestCleanup]
        public void TearDown()
        {
            TestFunctions.Driver.Quit();
        }
    }
}
