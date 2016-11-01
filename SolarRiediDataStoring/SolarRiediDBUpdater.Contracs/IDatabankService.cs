namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public interface IDatabankService
    {
        void FullUpdateOnTable(string tableName, string filePrefix);

        void UpdateDatabankOfLastFourDays(string tableName, string filePrefix);
    }
}
