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
    internal class SignUpTest : CoreCodes
    {
        [Test, Order(1)]
        public void CreateAccountTest()
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
                    string? firstname = excelData?.FirstName;
                    string? lastname = excelData?.LastName;
                    string? mobno = excelData?.MobileNo;
                    string? emailId = excelData?.EmailId;
                    string? password = excelData?.Password;

                    lhp?.SignUp(firstname, lastname, mobno, emailId, password);
                    TakeScreenShot();
                    Assert.That(driver.Url, Does.Contain("lenskart.com"));
                    LogTestResult("Sign Out Test", "Sign Out Test Passed");
                    test = extent.CreateTest("Sign Out Test Passed");
                    test.Pass("Sign Out test Passed");
                }
                catch (AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("Sign Out Test", "Sign Out Test failed", ex.Message);
                    test.Fail("Sign Out test failed");
                }

            }
        }
        
    }
}
