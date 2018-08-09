using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace AcceptanceTestCases.Tests
{
    [TestClass]
    public class TJGWithoutPOM
    {
        private IWebDriver driver;
        private readonly By _jobtypeLocator = By.Id("JobType");

        public  TJGWithoutPOM()
        {
           
        }

        [TestInitialize]
        public void Setup()
        {
                      
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("https://www.cwjobs.co.uk/");
       }

        [TestMethod]
        public void CwJobs()
        {

          var x=  driver.FindElement(By.Id("more-options-toggle"));
            x.Click();//Click on More Options button

            var dropdown = driver.FindElement(By.XPath("//select[@id='JobType']"));
            SelectElement selectjobtype = new SelectElement(dropdown);//Select Job type dropdown
            selectjobtype.SelectByValue("10");
            IList<IWebElement> options = selectjobtype.Options;
            IWebElement firstOption = options[1];
            NUnit.Framework.Assert.AreEqual(firstOption.Text, "Permanent");
            Console.WriteLine("JobType contains: " + firstOption.Text);

            //Taking a full-screen screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\srilatha.devireddy\Desktop\i.jpeg", ScreenshotImageFormat.Jpeg);

        }

        [TestMethod]
        public void CompaniesListed()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@class='counter']/h2/span[2]"));
            Console.WriteLine("Companies listed total : " + element.Text);

        }

         


      
        [TestCleanup]
        public void Teardown()
        {
            driver.Close();

        }


    }
}