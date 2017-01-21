using Common;
using System.Collections.Generic;

namespace Linus.SolarRiedi.ExcelAdapter.Contracts
{
    public interface IExcelWriter
    {
        void Write(IEnumerable<IEnumerable<string>> mesurements, string path, ReportDate date);
    }
}
