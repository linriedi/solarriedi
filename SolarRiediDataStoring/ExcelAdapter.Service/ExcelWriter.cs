using Common;
using Linus.SolarRiedi.ExcelAdapter.Contracts;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ExcelAdapter
{
    public class ExcelWriter : IExcelWriter
    {
        public void Write(IEnumerable<IEnumerable<string>> mesurementsInput, string path, ReportDate date)
        {
            Application excel_app = null;
            Workbook workbook = null;
            dynamic sheet = null;
            Range value_range = null;

            try
            {
                var measurements = mesurementsInput.ToList();
                var excelFilePath = CopyTemplate(path, date);

                excel_app = new Application();
                workbook = excel_app.Workbooks.Open(excelFilePath);
                sheet = workbook.Worksheets["rawData"];

                var values = new string[mesurementsInput.Count(), mesurementsInput.First().Count()];
                for (int i = 0; i < mesurementsInput.Count(); i++)
                {
                    var row = measurements[i].ToArray();
                    for (int j = 0; j < mesurementsInput.First().Count(); j++)
                    {
                        values[i, j] = row[j];
                    }
                }

                value_range = sheet.Range("A1", "H288");
                value_range.Value2 = values;
            }
            finally
            {
                //TODO if failes not all resourcer are released
                if (workbook != null)
                {
                    workbook.Close(true, Type.Missing, Type.Missing);
                }

                if (excel_app != null)
                {
                    excel_app.Application.Quit();
                    excel_app.Quit();
                }

                Marshal.FinalReleaseComObject(sheet);
                Marshal.FinalReleaseComObject(workbook);
                Marshal.FinalReleaseComObject(excel_app);
                Marshal.FinalReleaseComObject(value_range);
            }
        }

        private static string CopyTemplate(string path, ReportDate date)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);

            var templatePath = string.Format("{0}\\Template\\DayTemplate.xlsx", directory);
            var targetPath = string.Format("{0}\\{1}{2}{3}_Gi.xlsx", path, date.YearAsString, date.MonthAsString, date.DayAsString);

            File.Copy(templatePath, targetPath, true);
            return targetPath;
        }
    }
}
