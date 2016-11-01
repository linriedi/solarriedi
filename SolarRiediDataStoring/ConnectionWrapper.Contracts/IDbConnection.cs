namespace Linus.SolarRiedi.ConnectionWrapper.Contracts
{
    public interface IDbConnection
    {
        void Insert(string insertString, string connectionString);
        void DeleteItemsInTable(string connectionString);
    }
}
