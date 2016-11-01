namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public class Consum
    {
        public static Consum Create()
        {
            return new Consum(0,0,0);
        }
        
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
