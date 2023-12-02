using Lenskart.PageObjects;
using Lenskart.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.TestScripts
{
    [TestFixture]
    internal class FlterTest : CoreCodes
    {
        [Test]
        public void FilterSearchTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            LenskartHomePage lhp = new(driver);

            try
            {
                var filterresult = lhp?.filterSearch();
                var filteraddtocart = filterresult?.FilterGlasses();

                List<string> str = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(str[1]);

                filteraddtocart?.FilteredSearchAndaddToCart();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("cart"));
                LogTestResult("Filter Test", "Filter Test Passed");
                test = extent.CreateTest("Filter Test Passed");
                test.Pass("Filter test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Filter", "Filter Test failed", ex.Message);
                test.Fail("Filter test failed");
            }

        }
    }
}
