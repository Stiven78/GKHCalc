using System;
using System.Collections.Generic;

namespace GKHCalc.Service
{
    public static class Generic
    {
        public static string AggregateString<TSource>(this IEnumerable<TSource> values, string separator)
        {
            return String.Join(separator, values);
        }
    }
}
