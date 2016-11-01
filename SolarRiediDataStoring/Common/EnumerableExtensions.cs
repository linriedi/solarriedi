using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> LastFour<T>(this IEnumerable<T> list)
        {
            var reversed = list.Reverse();
            return reversed.Take(4).Reverse();
        }

        public static IEnumerable<T> TakeFrom<T>(this IEnumerable<T> list, int index)
        {
            var reversed = list.Reverse();
            var taked = reversed.Take(list.Count() - index);
            return taked.Reverse();
        }

        public static IEnumerable<T> RemoveLast<T>(this IEnumerable<T> list)
        {
            return list.Take(list.Count() - 1);
        }
    }
}
