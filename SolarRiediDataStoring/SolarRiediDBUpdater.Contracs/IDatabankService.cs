namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public interface IDatabankService
    {
        void FullUpdateOnTable(string tableName, string filePrefix);

        void UpdateDatabankOfLastFourDays(string tableName, string filePrefix);

        void UpdateDays(string tableName, string filePrefix);

        void UpdateMonth(string tableName, string filePrefix);

        void UpdateYear(string tableName, string filePrefix);
    }
}
