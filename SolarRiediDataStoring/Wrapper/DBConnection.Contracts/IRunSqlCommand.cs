using System.Collections.Generic;

namespace Linus.SolarRiedi.DBConnection.Contracts
{
    public interface IRunSqlCommand
    {
        IEnumerable<IEnumerable<string>> Select(string sqlCommand, string connectionString);
    }
}
