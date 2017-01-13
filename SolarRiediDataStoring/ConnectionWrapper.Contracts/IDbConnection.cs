using System.Collections.Generic;

namespace Linus.SolarRiedi.ConnectionWrapper.Contracts
{
    public interface IDbConnection
    {
        void RunSqlCommand(string sqlCommand, string connectionString);

        IEnumerable<IEnumerable<string>> Select(string sqlCommand, string connectionString);
    }
}
