using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System.Collections.Generic;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DtoBuilder
    {
        private int datum;
        private Consum consum;

        private Production production1;
        private Production production2;
        private Production production3;
        private Production production4;
        private Production production5;
        private Production production6;

        internal FiveMinutes Build()
        {
            return new FiveMinutes(
                this.datum, 
                this.consum,
                this.production1,
                this.production2,
                this.production3,
                this.production4,
                this.production5,
                this.production6);
        }

        internal DtoBuilder WithRow(List<string> row)
        {
            this.consum = new Consum(
                Parse(row[3]),
                Parse(row[4]),
                Parse(row[5]));

            this.production1 = new Production(
                Parse(row[7]),
                Parse(row[8]),
                Parse(row[9]),
                Parse(row[10]),
                Parse(row[11]),
                Parse(row[12]),
                Parse(row[13]),
                Parse(row[14]),
                Parse(row[15]),
                Parse(row[16]),
                Parse(row[17]));

            this.production2 = new Production(
                Parse(row[19]),
                Parse(row[20]),
                Parse(row[21]),
                Parse(row[22]),
                Parse(row[23]),
                Parse(row[24]),
                Parse(row[25]),
                Parse(row[26]),
                Parse(row[27]),
                Parse(row[28]),
                Parse(row[29]));

            this.production3 = new Production(
                Parse(row[31]),
                Parse(row[32]),
                Parse(row[33]),
                Parse(row[34]),
                Parse(row[35]),
                Parse(row[36]),
                Parse(row[37]),
                Parse(row[38]),
                Parse(row[39]),
                Parse(row[40]),
                Parse(row[41]));

            this.production4 = new Production(
                Parse(row[43]),
                Parse(row[44]),
                Parse(row[45]),
                Parse(row[46]),
                Parse(row[47]),
                Parse(row[48]),
                Parse(row[49]),
                Parse(row[50]),
                Parse(row[51]),
                Parse(row[52]),
                Parse(row[53]));

            this.production5 = new Production(
                Parse(row[55]),
                Parse(row[56]),
                Parse(row[57]),
                Parse(row[58]),
                Parse(row[59]),
                Parse(row[60]),
                Parse(row[61]),
                Parse(row[62]),
                Parse(row[63]),
                Parse(row[64]),
                Parse(row[65]));

            this.production6 = new Production(
                Parse(row[67]),
                Parse(row[68]),
                Parse(row[69]),
                Parse(row[70]),
                Parse(row[71]),
                Parse(row[72]),
                Parse(row[73]),
                Parse(row[74]),
                Parse(row[75]),
                Parse(row[76]),
                Parse(row[77]));

            return this;
        }

        internal DtoBuilder WithDatum(int datum)
        {
            this.datum = datum;
            return this;
        }

        private static int Parse(string stringValue)
        {
            return int.Parse(stringValue);
        }
    }
}
