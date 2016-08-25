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
            Item generalInfo = new Item("", "section-item");

            Item inform = new Item("", "edit-policy");
            Item next = new Item("", "next");

            TestFunctions.FindItem(signIn).Click();
            TestFunctions.WaitReady();
            TestFunctions.FindItem(loginField).Clear();
            TestFunctions.FindItem(loginField).SendKeys("david.smith.appulatetest@appulatemail.com");
            Thread.Sleep(1000);
            TestFunctions.FindItem(passwordField).Clear();
            TestFunctions.FindItem(passwordField).SendKeys("123321");
            Thread.Sleep(1000);
            TestFunctions.FindItem(signButton).Click();
            TestFunctions.WaitReady();
            TestFunctions.FindItem(hiddenList).Click();
            TestFunctions.FindItem(fullForm).Click();
            Thread.Sleep(3000);
            while (!TestFunctions.FindItem(generalInfo).Text.StartsWith("Additional Information"))
            {
                TestFunctions.FindItem(next).Click();
                Thread.Sleep(3000);
            }


            //action.MoveToElement(TestFunctions.Driver.FindElementByXPath("//*[contains(text(), 'General Info')]")).Perform();
            Thread.Sleep(5000);
            //TestFunctions.Driver.FindElementByXPath("//*[contains(text(), 'Additional Information')]").Click();
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
