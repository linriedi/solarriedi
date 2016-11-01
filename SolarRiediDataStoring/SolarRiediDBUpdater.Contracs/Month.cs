namespace Linus.SolarRiedi.SolarRiediDBUpdater.Contracs
{
    public class Month
    {
        public int Datum { get; private set; }
        public int Psum_0 { get; private set; }
        public int Psum_1 { get; private set; }
        public int Psum_2 { get; private set; }
        public int Psum_3 { get; private set; }
        public int Psum_4 { get; private set; }
        public int Psum_5 { get; private set; }
        public int Psum_6 { get; private set; }

        public Month(
            int datum,
            int psum_0,
            int psum_1,
            int psum_2,
            int psum_3,
            int psum_4,
            int psum_5,
            int psum_6)
        {
            this.Datum = datum;
            this.Psum_0 = psum_0;
            this.Psum_1 = psum_1;
            this.Psum_2 = psum_2;
            this.Psum_3 = psum_3;
            this.Psum_4 = psum_4;
            this.Psum_5 = psum_5;
            this.Psum_6 = psum_6;
        }
    }
}
