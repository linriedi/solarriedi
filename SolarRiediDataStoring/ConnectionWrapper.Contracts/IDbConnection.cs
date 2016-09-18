using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.ConnectionWrapper.Contracts
{
    public interface IDbConnection
    {
        void Insert(string insertString, string connectionString);
        void DeleteItemsInTable(string connectionString);
    }
}
