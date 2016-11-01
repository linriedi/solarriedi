namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public class Consum
    {
        public Consum(int pac, int daySum, int status)
        {
            this.Pac = pac;
            this.DaySum = daySum;
            this.Status = status;
        }

        public int Pac { get; private set; }
	    public int DaySum { get; private set; }
	    public int Status { get; private set; }
    }
}
