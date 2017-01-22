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
                var excelFilePath = CopyTemplate(path, date);

                excel_app = new Application();
                workbook = excel_app.Workbooks.Open(excelFilePath);
                sheet = workbook.Worksheets["rawData"];

                string[,] values = CreateValuesMatrix(mesurementsInput.ToList());

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
            dynamic xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 2] = "2015";
            xlWorkSheet.Cells[1, 3] = "2016";

            xlWorkSheet.Cells[2, 1] = "schaner";
            xlWorkSheet.Cells[3, 1] = "fevrer";
            xlWorkSheet.Cells[4, 1] = "mart";
            xlWorkSheet.Cells[5, 1] = "avrel";

            xlWorkSheet.Cells[6, 1] = "matg";
            xlWorkSheet.Cells[7, 1] = "zercladur";
            xlWorkSheet.Cells[8, 1] = "fenadur";
            xlWorkSheet.Cells[9, 1] = "uost";

            xlWorkSheet.Cells[10, 1] = "setember";
            xlWorkSheet.Cells[11, 1] = "october";
            xlWorkSheet.Cells[12, 1] = "november";
            xlWorkSheet.Cells[13, 1] = "december";

            Range chartRange;

            var writeRange = xlWorkSheet.Range("B2", "C13");
            writeRange.Value2 = CreateValuesMatrixAsNumber(measurements.ToList());

            ChartObjects xlCharts = (ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            ChartObject myChart = (ChartObject)xlCharts.Add(10, 80, 300, 250);
            Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.Range("A1", "C13");
            chartPage.SetSourceData(chartRange, misValue);
                        
            ChartSettings.Configure(chartPage);

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

        private static object[,] CreateValuesMatrixAsNumber(List<IEnumerable<string>> measurements)
        {
            var values = new object[measurements.Count(), measurements.First().Count()];
            for (int i = 0; i < measurements.Count(); i++)
            {
                var row = measurements[i].ToArray();
                for (int j = 0; j < measurements.First().Count(); j++)
                {
                    var value = double.Parse(row[j]);
                    if(value != 0)
                    {
                        values[i, j] = value;
                    }
                    else
                    {
                        values[i, j] = null;
                    }                    
                }
            }

            return values;
        }

        private static string[,] CreateValuesMatrix(List<IEnumerable<string>> measurements)
        {
            var values = new string[measurements.Count(), measurements.First().Count()];
            for (int i = 0; i < measurements.Count(); i++)
            {
                var row = measurements[i].ToArray();
                for (int j = 0; j < measurements.First().Count(); j++)
                {
                    values[i, j] = row[j];
                }
            }

            return values;
        }
    }
}
