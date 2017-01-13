using ExcelAdapter.Contracts;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            // Add some data to a range of cells.
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

            // Save the changes and close the workbook.
            workbook.Close(true, Type.Missing, Type.Missing);

            // Close the Excel server.
            excel_app.Quit();
        }

        //public void Write(IEnumerable<IEnumerable<string>> mesurementsInput)
        //{
        //    var mesurements = mesurementsInput.ToList();

        //    Application oXL = null;
        //    Workbook oWB = null;
        //    Worksheet sheet = null;

        //    try
        //    {
        //        var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //        var directory = System.IO.Path.GetDirectoryName(path);

        //        oXL = new Application();
        //        oWB = oXL.Workbooks.Open(string.Format("{0}\\Template\\DayTemplate.xlsx", directory));

        //        sheet = oWB.Worksheets["rawData"];

        //        var colIndex = 1;

        //        var nofRow = mesurements.Count();
        //        var nofColumn = mesurements.First().Count();

        //        for(int rowIndex = 0; rowIndex < 5; rowIndex++)
        //        {
        //            var row = mesurements[rowIndex];
        //            colIndex = 1;
        //            foreach (var col in row)
        //            {
        //                sheet.Cells[rowIndex + 1, colIndex] = col;
        //                colIndex++;
        //            }
        //            Console.WriteLine(rowIndex);
        //        }
        //        oWB.Save();
        //    }
        //    finally
        //    {
        //        this.releaseObject(oXL);
        //        this.releaseObject(oWB);
        //        this.releaseObject(sheet);
        //    }
        //}

        //private void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}
    }
}
