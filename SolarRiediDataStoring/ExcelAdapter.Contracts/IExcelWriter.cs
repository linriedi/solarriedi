using Linus.SolarRiedi.Common;
using System.Collections.Generic;

namespace Linus.SolarRiedi.ExcelAdapter.Contracts
{
    public interface IExcelWriter
    {
        void WriteFullReport(IEnumerable<IEnumerable<string>> measurements, string path, ReportDate date);

        void WriteDayReport(IEnumerable<IEnumerable<string>> mesurements, string path, ReportDate date);
    }
}
