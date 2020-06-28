using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public static class Extensions
    {
        public static T Pop<T>(this T list) where T : IEnumerable<T>
        {
            return list.Last();
        }
    }
}