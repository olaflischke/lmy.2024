using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingDayDal.Extensions
{
    public static class Extensions
    {
        public static bool IsNumeric(this string text)
        {
            return double.TryParse(text, out _);
        }


        public static void AddIfNew<T>(this List<T> list, T item)
        {
            if (list == null) return;

            if (!list.Contains(item)) 
                list.Add(item);
        }
    }
}
