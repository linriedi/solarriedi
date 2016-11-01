namespace Linus.SolarRiedi.ConnectionWrapper.Contracts
{
    public interface IDbConnection
    {
        void RunSqlCommand(string sqlCommand, string connectionString);
    }
}
