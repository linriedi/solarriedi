using Linus.SolarRiedi.Common;
using Linus.SolarRiedi.ExcelAdapter.Contracts;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Linus.SolarRiedi.ExcelAdapter.Service
{
    public class ExcelWriter : IExcelWriter
    {
        public void WriteDayReport(IEnumerable<IEnumerable<string>> mesurementsInput, string path, ReportDate date)
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

        public void WriteFullReport(IEnumerable<IEnumerable<string>> measurements, string path, ReportDate date)
        {
            Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Student1";
            xlWorkSheet.Cells[1, 3] = "Student2";
            xlWorkSheet.Cells[1, 4] = "Student3";

            xlWorkSheet.Cells[2, 1] = "Term1";
            xlWorkSheet.Cells[2, 2] = "80";
            xlWorkSheet.Cells[2, 3] = "65";
            xlWorkSheet.Cells[2, 4] = "45";

            xlWorkSheet.Cells[3, 1] = "Term2";
            xlWorkSheet.Cells[3, 2] = "78";
            xlWorkSheet.Cells[3, 3] = "72";
            xlWorkSheet.Cells[3, 4] = "60";

            xlWorkSheet.Cells[4, 1] = "Term3";
            xlWorkSheet.Cells[4, 2] = "82";
            xlWorkSheet.Cells[4, 3] = "80";
            xlWorkSheet.Cells[4, 4] = "65";

            xlWorkSheet.Cells[5, 1] = "Term4";
            xlWorkSheet.Cells[5, 2] = "75";
            xlWorkSheet.Cells[5, 3] = "82";
            xlWorkSheet.Cells[5, 4] = "68";

            Range chartRange;

            ChartObjects xlCharts = (ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            ChartObject myChart = (ChartObject)xlCharts.Add(10, 80, 300, 250);
            Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d5");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = XlChartType.xlColumnClustered;

            xlWorkBook.SaveAs(string.Format("{0}\\test.xlsx", path));
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
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
