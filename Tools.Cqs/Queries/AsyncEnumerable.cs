using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Queries
{
    public static class AsyncEnumerable
    {
        public async static Task<IEnumerable<TSource>> ToList<TSource>(this IAsyncEnumerable<TSource> source)
        {
            List<TSource> list = new List<TSource>();
            
            await foreach (TSource item in source)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
