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
    internal class SignInTest : CoreCodes
    {
        [Test, Order(1)]
        public void LoginTest()
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
                    string? mobno = excelData?.MobileNo;

                    lhp?.SignIn(mobno);
                    TakeScreenShot();
                    Assert.That(driver.Url, Does.Contain("lenskart.com"));
                    LogTestResult("Sign In Test", "Sign In Test Passed");
                    test = extent.CreateTest("Sign In Test Passed");
                    test.Pass("Sign In test Passed");
                }
                catch (AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("Sign In Test", "Sign In Test failed", ex.Message);
                    test.Fail("Sign In test failed");
                }
            }
        }
    }
}
