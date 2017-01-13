using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAdapter.Contracts
{
    public interface IExcelWriter
    {
        void Write(IEnumerable<IEnumerable<string>> mesurements);
    }
}
