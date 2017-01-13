using ExcelAdapter.Contracts;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelAdapter
{
    public class ExcelWriter : IExcelWriter
    {
        public void Write(IEnumerable<IEnumerable<string>> mesurementsInput)
        {
            var measurements = mesurementsInput.ToList();
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);

            var excel_app = new Application();
            var workbook = excel_app.Workbooks.Open(string.Format("{0}\\Template\\DayTemplate.xlsx", directory));
            var sheet = workbook.Worksheets["rawData"];

            var values = new string[mesurementsInput.Count(), mesurementsInput.First().Count()];
            for(int i = 0; i < mesurementsInput.Count(); i++)
            {
                var row = measurements[i].ToArray();
                for(int j = 0; j < mesurementsInput.First().Count(); j++)
                {
                    values[i, j] = row[j];
                }
            }
            
            Range value_range = sheet.Range("A1", "H288");
            value_range.Value2 = values;

            workbook.Close(true, Type.Missing, Type.Missing);
            excel_app.Quit();
        }
    }
}
