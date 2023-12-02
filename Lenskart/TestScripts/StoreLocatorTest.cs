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
    internal class StoreLocatorTest : CoreCodes
    {
        [Test]
        public void LocateStore()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            LenskartHomePage lhp = new(driver);
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Lenskart";

            List<SearchData> excelDataList = ExcelUtils.ReadSearchDataExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                try
                {
                    string? city = excelData?.City;
                    var searchcity = lhp?.ClickOnStoreLocator();
                    searchcity.StoreSearch(city);

                    TakeScreenShot();
                    Assert.That(driver.Url, Does.Contain("stores"));
                    LogTestResult("Store Locator Test", "Store Locator Test Passed");
                    test = extent.CreateTest("Store Locator Test Passed");
                    test.Pass("Store Locator test Passed");
                }
                catch (AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("Store Locator Test", "Store Locator Test failed", ex.Message);
                    test.Fail("Store Locator test failed");
                }
            }
        }
    }
}
