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
    internal class ContactLensTest : CoreCodes
    {
        [Test]

        public void BuyContactLens()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            LenskartHomePage lhp = new(driver);
            try 
            {
                var selectlenspage = lhp?.ClickSearchContactLenses();
                var buyclpage = selectlenspage?.ContactLensSelect();
                List<string> str = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(str[1]);
                buyclpage?.ContactLensAddToCart();
                TakeScreenShot();
                Assert.That(driver.Url, Does.Contain("cart"));
                LogTestResult("Contact lens Test", "Contact lens Test Passed");
                test = extent.CreateTest("Contact lens Test Passed");
                test.Pass("Contact lens test Passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Contact lens Test", "Contact lens Test failed", ex.Message);
                test.Fail("Contact lens test failed");
            }

        }
        


    }
}
