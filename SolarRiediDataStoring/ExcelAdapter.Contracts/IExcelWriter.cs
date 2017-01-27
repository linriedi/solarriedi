using Linus.SolarRiedi.Common;
using System.Collections.Generic;

namespace Linus.SolarRiedi.ExcelAdapter.Contracts
{
    public interface IExcelWriter
    {
        void WriteFullReport(IEnumerable<MeasurementsYear> measurements, string path);
        void WriteDayReport(IEnumerable<IEnumerable<string>> mesurements, string path, ReportDate date);
        void WriteMonthReport(IEnumerable<IEnumerable<string>> mesurements, string path, ReportDate date);
    }
}
