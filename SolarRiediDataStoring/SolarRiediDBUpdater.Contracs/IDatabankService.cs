namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public interface IDatabankService
    {
        void UpdateDatabank();
        
        void UpdateDatabankOfLastFourDays(string tableName, string filePrefix);
    }
}
