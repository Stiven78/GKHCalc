using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Service
{
    public static class Generic
    {
        public static string AggregateString<TSource>(this IEnumerable<TSource> values, string separator)
        {
            return String.Join(separator, values);
            //return values.Aggregate(new StringBuilder(), (curr, val) => curr.Append(val.ToString()).Append(separator), curr => curr.ToString().TrimEnd(separator.ToCharArray()));
        }
    }
}
