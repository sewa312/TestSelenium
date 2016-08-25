using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;
using Test;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            TestFunctions.WaitReady();
            TestFunctions.OpenURL("https://appulatebeta.com");
            TestFunctions.WaitReady();
        }
        [TestMethod]
        public void TestCase()
        {
            Actions action = new Actions(TestFunctions.Driver);
            


            Item signIn = new Item("", "sign-in-button");
            Item loginField = new Item("email", "");
            Item passwordField = new Item("password", "");
            Item signButton = new Item("", "signin-button");
            Item hiddenList = new Item("", "customer-view-hide");
            Item fullForm = new Item("", "edit-policy");
            Item inform = new Item("", "edit-policy");
            Item generalInfo = new Item("", "section-item");
            TestFunctions.FindItem(signIn).Click();
            TestFunctions.WaitReady();
            TestFunctions.FindItem(loginField).SendKeys("david.smith.appulatetest@appulatemail.com");
            TestFunctions.FindItem(passwordField).SendKeys("123321");
            TestFunctions.FindItem(signButton).Click();
            TestFunctions.WaitReady();
            TestFunctions.FindItem(hiddenList).Click();
            TestFunctions.FindItem(fullForm).Click();
            action.MoveToElement(TestFunctions.FindItem(generalInfo)).Perform();
            TestFunctions.Driver.FindElementByXPath("//*[contains(text(), 'Additional Information')]").Click();
            Thread.Sleep(5000);
            //Test.TestFunctions.Driver.FindElementByClassName(("input__box"));
        }

        [TestCleanup]
        public void TearDown()
        {
            TestFunctions.Driver.Quit();
        }
    }
}
