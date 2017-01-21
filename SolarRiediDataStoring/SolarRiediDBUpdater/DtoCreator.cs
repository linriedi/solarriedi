using System;
using System.Collections.Generic;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Linus.SolarRiedi.Common;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DtoCreator
    {
        internal IEnumerable<FiveMinutes> Create(List<List<string>> matrix)
        {
            var fiveMinutes = new List<FiveMinutes>();
            foreach (var row in matrix)
            {
                var datum = Time.CreateDateTimeAsIntFromString(row[0], row[1]);

                var fiveMinute = new DtoBuilder()
                    .WithDatum(datum)
                    .WithRow(row)
                    .Build();

                fiveMinutes.Add(fiveMinute);
            }

            return fiveMinutes;
        }

        internal IEnumerable<Day> CreateForDays(List<Block> blocks)
        {
            var days = new List<Day>();
            foreach(var block in blocks)
            {
                var day = new DayDtoCreator().CreateForDays(block);
                days.Add(day);
            }
            return days;
        }
              
        internal IEnumerable<Month> CreateForMonth(List<Block> blocks)
        {
            var months = new List<Month>();
            foreach (var block in blocks)
            {
                var month = new DayDtoCreator().CreateForMonth(block);
                months.Add(month);
            }
            return months;
        }

        internal IEnumerable<Year> CreateForYear(List<Block> blocks)
        {
            var years = new List<Year>();
            foreach (var block in blocks)
            {
                var year = new DayDtoCreator().CreateForYear(block);
                years.Add(year);
            }
            return years;
        }
    }
}
