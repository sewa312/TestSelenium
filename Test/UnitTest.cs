using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;
using Test;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            TestFunctions.WaitReady(10000);
            // Go to appulabeta and initialized driver
            TestFunctions.OpenURL("https://appulatebeta.com");
            TestFunctions.WaitReady(10000);
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
            TestFunctions.WaitReady(10000);

            // Log on under the insured’s account
            TestFunctions.FindItem(loginField).Clear();
            TestFunctions.FindItem(loginField).SendKeys("david.smith.appulatetest@appulatemail.com");
            Thread.Sleep(1000);
            TestFunctions.FindItem(passwordField).Clear();
            TestFunctions.FindItem(passwordField).SendKeys("123321");
            Thread.Sleep(1000);
            TestFunctions.FindItem(signButton).Click();
            TestFunctions.WaitReady(10000);
            // Expand the list of applications and policies provided by the company 
            // “Krol Appulate Testing Agency”
            TestFunctions.FindItem(hiddenList).Click();
            // Click the application “Workers’ Compensation” to open its fill-out form
            TestFunctions.FindItem(fullForm).Click();
            Thread.Sleep(3000);
            // On the open Additional Information page
            while (!TestFunctions.FindItem(generalInfo).Text.StartsWith("Additional Information"))
            {
                TestFunctions.FindItem(next).Click();
                Thread.Sleep(1000);
            }

            // upload image file  using the Choose Files button
            string selector = ".upload-container input[type=\"file\"]";
            // Make hidden element visible
            // To be able to select the file in Selenium
            TestFunctions.Driver.ExecuteScript(string.Format(
                "document.querySelector({0}).style.display = 'inline'", TestFunctions.EscapeJsLiteral(selector)));
            TestFunctions.Driver.FindElementsByCssSelector(".upload-container input[type=\"file\"]").Single()
                .SendKeys(Path.GetFullPath("so_slow.jpg"));
            Thread.Sleep(5000);
        }
        
        [TestCleanup]
        public void TearDown()
        {
            // Close the browser
            TestFunctions.Driver.Quit();
        }
    }
}
