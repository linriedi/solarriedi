using Microsoft.Office.Interop.Excel;

namespace Linus.SolarRiedi.ExcelAdapter.Service
{
    public static class ChartSettings
    {
        internal static void Configure(Chart chart)
        {
            chart.ChartType = XlChartType.xlLine;
        }
    }
}
