namespace Linus.SolarRiedi.DataStoringService.Contracts
{
    public class ReportDate
    {
        public ReportDate(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
    }
}
