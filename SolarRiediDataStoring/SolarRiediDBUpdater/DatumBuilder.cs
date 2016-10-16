using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DatumBuilder
    {
        private string date;
        private string minute;

        public DatumBuilder WithDateInfo(string date, string minute)
        {
            this.date = date;
            this.minute = minute;
            return this;
        }

        public int Build()
        {
            int datum = 0;

            var spited = this.date.Split('.');
            datum += int.Parse(spited[2]) * 100000000;
            datum += int.Parse(spited[1]) * 1000000;
            datum += int.Parse(spited[0]) * 10000;

            spited = this.minute.Split(':');
            datum += int.Parse(spited[0]) * 100;
            datum += int.Parse(spited[1]);
            //"2016 09 11" "2355"

            return datum;
        }
    }
}