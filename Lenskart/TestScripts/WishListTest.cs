using Lenskart.PageObjects;
using Lenskart.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.TestScripts
{
    [TestFixture]
    internal class WishListTest : CoreCodes
    {
        [Test]
        public void AddToWishList()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            LenskartHomePage lhp = new(driver);
            try
            {
                var searchPage = lhp?.ClickSearchProduct();
                Thread.Sleep(1000);
                var productPage = searchPage?.SelectEyewear();

                List<string> str = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(str[1]);

                productPage?.AddToWishList();
                TakeScreenShot();
                IWebElement element = driver.FindElement(By.Id("wishlistView"));
                var wishListClass=element.GetAttribute("class");
                Assert.That(wishListClass.Contains("hYsszL") == true);
                LogTestResult("WishList Test", "WishList Test Passed");
                test = extent.CreateTest("WishList Test Passed");
                test.Pass("WishList test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("WishList Test", "WishList Test failed", ex.Message);
                test.Fail("WishList test failed");
            }

        }

    }
}

