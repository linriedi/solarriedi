namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public class Day
    {
        public int Datum { get; private set; }
        public int Psum_0 { get; private set; }
        public int Pmax_0 { get; private set; }
        public int Psum_1 { get; private set; }
        public int Pmax_1 { get; private set; }
        public int Psum_2 { get; private set; }
        public int Pmax_2 { get; private set; }
        public int Psum_3 { get; private set; }
        public int Pmax_3 { get; private set; }
        public int Psum_4 { get; private set; }
        public int Pmax_4 { get; private set; }
        public int Psum_5 { get; private set; }
        public int Pmax_5 { get; private set; }
        public int Psum_6 { get; private set; }
        public int Pmax_6 { get; private set; }

        public Day(
            int datum,
            int psum_0,
            int pmax_0,
            int psum_1,
            int pmax_1,
            int psum_2,
            int pmax_2,
            int psum_3,
            int pmax_3,
            int psum_4,
            int pmax_4,
            int psum_5,
            int pmax_5,
            int psum_6,
            int pmax_6)
        {
            this.Datum = datum;
            this.Psum_0 = psum_0;
            this.Pmax_0 = pmax_0;
            this.Psum_1 = psum_1;
            this.Pmax_1 = pmax_1;
            this.Psum_2 = psum_2;
            this.Pmax_2 = pmax_2;
            this.Psum_3 = psum_3;
            this.Pmax_3 = pmax_3;
            this.Psum_4 = psum_4;
            this.Pmax_4 = pmax_4;
            this.Psum_5 = psum_5;
            this.Pmax_5 = pmax_5;
            this.Psum_6 = psum_6;
            this.Pmax_6 = pmax_6;
        }
    }
}
