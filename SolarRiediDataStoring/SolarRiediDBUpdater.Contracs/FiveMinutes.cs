namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public class FiveMinutes
    {
        private static int count = 1;
        
        //TODO Remove
        public static FiveMinutes Create()
        {
            return new FiveMinutes(
                count++, 
                Consum.Create(), 
                Production.Create(),
                Production.Create(),
                Production.Create(),
                Production.Create(),
                Production.Create(),
                Production.Create());
        }

        public int Datum { get; private set; }
        public Consum Consum { get; private set; }
        public Production Production1 { get; private set; }
        public Production Production2 { get; private set; }
        public Production Production3 { get; private set; }
        public Production Production4 { get; private set; }
        public Production Production5 { get; private set; }
        public Production Production6 { get; private set; }

        public FiveMinutes(
            int datum, 
            Consum consum,
            Production production1,
            Production production2,
            Production production3,
            Production production4,
            Production production5,
            Production production6)
        {
            this.Datum = datum;
            this.Consum = consum;

            this.Production1 = production1;
            this.Production2 = production2;
            this.Production3 = production3;
            this.Production4 = production4;
            this.Production5 = production5;
            this.Production6 = production6;
        }
    }
}
