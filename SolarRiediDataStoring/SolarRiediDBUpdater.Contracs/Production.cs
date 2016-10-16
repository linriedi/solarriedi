namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public class Production
    {
        public static Production Create()
        {
            return new Production();
        }

        public Production()
        {
        }

        public int Pac { get; private set; }
        public int DaySum { get; private set; }
        public int Status { get; private set; }
        public int Error { get; private set; }
        public int Pdc1 { get; private set; }
        public int Pdc2 { get; private set; }
        public int Pdc3 { get; private set; }
        public int Udc1 { get; private set; }
        public int Udc2 { get; private set; }
        public int Udc3 { get; private set; }
        public int Uac { get; private set; }

        public Production(
            int pac,
            int daySum,
            int status,
            int error,
            int pdc1,
            int pdc2,
            int pdc3,
            int udc1,
            int udc2,
            int udc3,
            int uac)
        {
            this.Pac = pac;
            this.DaySum = daySum;
            this.Status = status;
            this.Error = error;
            this.Pdc1 = pdc1;
            this.Pdc2 = pdc2;
            this.Pdc3 = pdc3;
            this.Udc1 = udc1;
            this.Udc2 = udc2;
            this.Udc3 = udc2;
            this.Uac = uac;
        }
    }
}
