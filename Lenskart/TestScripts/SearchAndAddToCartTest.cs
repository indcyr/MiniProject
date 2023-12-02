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
    internal class SearchAndAddToCartTest : CoreCodes
    {
        [Test]

        public void SearchProductAndAddToCart()
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


                    string? product = excelData?.Product;
                    var searchPage = lhp?.TypeSearchInput(product);
                    Thread.Sleep(1000);
                    var productPage = searchPage?.ClickProduct();
                    Log.Information("clicked product");

                    List<string> str = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(str[1]);

                    Thread.Sleep(6000);
                    productPage?.SelectLensButtonClick();
                    productPage?.LensTypeSelection();

                    productPage?.AddToCart();
                    TakeScreenShot();
                    Assert.That(driver.Url, Does.Contain("checkout"));
                    LogTestResult("Search and Add To Cart Test", "Search and Add To Cart Test Passed");
                    test = extent.CreateTest("Search and Add To Cart Test Passed");
                    test.Pass("Search and Add To Cart test Passed");
                }
                catch(AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("Search and Add To Cart Test", "Search and Add To Cart Test failed", ex.Message);
                    test.Fail("Search and Add To Cart test failed");
                }
            }
                /* LenskartHomePage lhp = new(driver);
                 var searchPage = lhp?.TypeSearchInput(searchText);
                 Thread.Sleep(1000);
                 var productPage = searchPage?.ClickProduct();

                 List<string> str = driver.WindowHandles.ToList();
                 driver.SwitchTo().Window(str[1]);

                 Thread.Sleep(6000);
                 productPage?.SelectLensButtonClick();
                 productPage?.LensTypeSelection();

                 productPage?.AddToCart();*/
        }
        
    }
}
