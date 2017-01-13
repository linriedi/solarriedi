using Common;
using System.Collections.Generic;

namespace ExcelAdapter.Contracts
{
    public interface IExcelWriter
    {
        void Write(IEnumerable<IEnumerable<string>> mesurements, string path, ReportDate date);
    }
}
