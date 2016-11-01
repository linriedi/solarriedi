using Common;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System.Collections.Generic;
using System.Linq;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    class DayDtoCreator
    {
        internal Day CreateForDays(Block block)
        {
            var datumString = block.Lines.First().First();

            int datum = Time.CreateDateTimeAsIntFromString(datumString);
            int psum_0 = GetValue(block.Lines[0], 0);
            int pmax_0 = GetValue(block.Lines[0], 1);
            int psum_1 = GetValue(block.Lines[1], 0);
            int pmax_1 = GetValue(block.Lines[1], 1);
            int psum_2 = GetValue(block.Lines[2], 0);
            int pmax_2 = GetValue(block.Lines[2], 1);
            int psum_3 = GetValue(block.Lines[3], 0);
            int pmax_3 = GetValue(block.Lines[3], 1);
            int psum_4 = GetValue(block.Lines[4], 0);
            int pmax_4 = GetValue(block.Lines[4], 1);
            int psum_5 = GetValue(block.Lines[5], 0);
            int pmax_5 = GetValue(block.Lines[5], 1);
            int psum_6 = GetValue(block.Lines[6], 0);
            int pmax_6 = GetValue(block.Lines[6], 1);

            return new Day(
                datum,
                psum_0,
                pmax_0,
                psum_1,
                pmax_1,
                psum_2,
                pmax_2,
                psum_3,
                pmax_3,
                psum_4,
                pmax_4,
                psum_5,
                pmax_5,
                psum_6,
                pmax_6);
        }

        internal Month CreateForMonth(Block block)
        {
            var datumString = block.Lines.First().First();

            int datum = Time.CreateMonthDateAsIntFromString(datumString);

            int psum_0 = GetValue(block.Lines[0], 0);
            int psum_1 = GetValue(block.Lines[1], 0);
            int psum_2 = GetValue(block.Lines[2], 0);
            int psum_3 = GetValue(block.Lines[3], 0);
            int psum_4 = GetValue(block.Lines[4], 0);
            int psum_5 = GetValue(block.Lines[5], 0);
            int psum_6 = GetValue(block.Lines[6], 0);

            return new Month(
                datum,
                psum_0,
                psum_1,
                psum_2,
                psum_3,
                psum_4,
                psum_5,
                psum_6);
        }

        private int GetValue(List<string> list, int index)
        {
            return int.Parse(list[index + 2]);
        }
    }
}
