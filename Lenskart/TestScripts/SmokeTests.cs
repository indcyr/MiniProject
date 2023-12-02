using Lenskart.PageObjects;
using Lenskart.Utilities;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.TestScripts
{
    [TestFixture]
    internal class SmokeTest : CoreCodes
    {
        //[Test]
        //public void FossilSelectTest()
        //{
        //    LenskartHomePage lhp = new(driver);
        //    lhp?.FossilGlassesSelect();

        //}
        [Test, Order(1)]
        public void ClickOnGoldTest()
        {
            if (!driver.Url.Equals("https://www.lenskart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.lenskart.com/");

            }
            
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            SmokeHomePage shp = new(driver);
            try
            {
                shp?.ClickOnGold();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("loyalty"));
                LogTestResult("Gold Test", "Gold Test Passed");
                test = extent.CreateTest("Gold Test Passed");
                test.Pass("Gold test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Gold Test", "Gold Test failed", ex.Message);
                test.Fail("Gold test failed");
            }

        }
        [Test, Order(2)]
        public void ClickOnTryOnTest()
        {
            if (!driver.Url.Equals("https://www.lenskart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.lenskart.com/");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            SmokeHomePage shp = new(driver);
            try
            {
                shp?.ClickOnTryOn();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("compare-looks"));
                LogTestResult("3D Try On Test", "3D Try On Test Passed");
                test = extent.CreateTest("3D Try On Test Passed");
                test.Pass("3D Try On test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("3D Try On Test", "3D Try On Test failed", ex.Message);
                test.Fail("3D Try On test failed");
            }
        }
        [Test, Order(3)]
        public void ExploreTypesTest()
        {
            if (!driver.Url.Equals("https://www.lenskart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.lenskart.com/");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            SmokeHomePage shp = new(driver);
            try 
            {
                shp?.ExploreTypes();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("air-clip-on"));
                LogTestResult("Explore Types Test", "Explore Types Test Passed");
                test = extent.CreateTest("Explore Types Test Passed");
                test.Pass("Explore Types test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Explore Types Test", "Explore Types Test failed", ex.Message);
                test.Fail("Explore Types test failed");
            }

        }
        [Test]
        public void CelebStylesTest()
        {
            if (!driver.Url.Equals("https://www.lenskart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.lenskart.com/");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            SmokeHomePage shp = new(driver);
            
            try
            {
                shp?.CelebrityStyles();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("karan-johar-favorites"));
                LogTestResult("Celebrity styles Test", "Celebrity styles Test Passed");
                test = extent.CreateTest("Celebrity styles Test Passed");
                test.Pass("Celebrity styles test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Celebrity styles Test", "Celebrity styles Test failed", ex.Message);
                test.Fail("Celebrity styles test failed");
            }

        }
        [Test]
        public void MouseOverAndViewAllTest()
        {
            if (!driver.Url.Equals("https://www.lenskart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.lenskart.com/");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
           
            SmokeHomePage shp = new(driver);
            try
            {
                shp?.MouseOverCheck();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("eyeglasses"));
                LogTestResult("Celebrity styles Test", "Celebrity styles Test Passed");
                test = extent.CreateTest("Celebrity styles Test Passed");
                test.Pass("Celebrity styles test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Celebrity styles Test", "Celebrity styles Test failed", ex.Message);
                test.Fail("Celebrity styles test failed");
            }
        }
    }
}

