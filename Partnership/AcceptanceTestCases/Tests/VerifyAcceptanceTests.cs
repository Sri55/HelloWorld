using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Features;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;

namespace AcceptanceTestCases
{
    [TestClass]
    public class VerifyAcceptanceTests
    {
        public IWebDriver driver;
      

        [SetUp]
        public void SetUp()
        {
            driver = new InternetExplorerDriver();
        }

        [TestMethod]
       public void One()
        {
            FreeCycle _cycles = new FreeCycle(driver);
        
            _cycles.GotoWebsite();
            SearchResults _search = _cycles.SearchForGroup();
            _search.VerifySearchResultsAreAsExpected();


        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}

