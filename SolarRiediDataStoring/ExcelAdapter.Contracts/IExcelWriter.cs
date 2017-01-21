using Linus.SolarRiedi.Common;
using System.Collections.Generic;

namespace Linus.SolarRiedi.ExcelAdapter.Contracts
{
    public interface IExcelWriter
    {
        void WriteDayReport(IEnumerable<IEnumerable<string>> mesurements, string path, ReportDate date);
    }
}
