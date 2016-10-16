using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> LastFour<T>(this IEnumerable<T> list)
        {
            var reversed = list.Reverse();
            return reversed.Take(4).Reverse();
        }
    }
}
