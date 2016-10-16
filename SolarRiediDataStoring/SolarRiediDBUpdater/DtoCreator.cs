using System;
using System.Collections.Generic;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DtoCreator
    {
        internal IEnumerable<FiveMinutes> Create(List<List<string>> matrix)
        {
            var fiveMinutes = new List<FiveMinutes>();
            foreach (var row in matrix)
            {
                var datum = new DatumBuilder()
                    .WithDateInfo(row[0], row[1])
                    .Build();

                var fiveMinute = new DtoBuilder()
                    .WithDatum(datum)
                    .WithRow(row)
                    .Build();

                fiveMinutes.Add(fiveMinute);
            }

            return fiveMinutes;
        }
    }
}
