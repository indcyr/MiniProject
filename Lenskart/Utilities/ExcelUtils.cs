using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenskart.Utilities
{
    internal class ExcelUtils
    {
        public static List<SearchData> ReadSearchDataExcelData(string excelFilePath, string sheetName)
        {
            List<SearchData> excelDataList = new List<SearchData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            SearchData excelData = new SearchData
                            {
                                
                                Product = GetValueOrDefault(row, "product"),
                                FirstName = GetValueOrDefault(row,"firstname"),
                                LastName = GetValueOrDefault(row,"lastname"),
                                MobileNo = GetValueOrDefault(row,"mobileNo"),
                                EmailId = GetValueOrDefault(row,"emailId"),
                                Password = GetValueOrDefault(row,"password"),
                                City = GetValueOrDefault(row,"city")

                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
