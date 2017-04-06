using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Extensions.Interfaces;

namespace Freelance.Extensions
{
    public static class QueryProvider
    {
        public static IQueryable<TModel> Filter<TModel>(this IQueryable<TModel> source, FilteringOptions filter)
        {
            return filter != null ? filter.Filter(source) : source;
        }

        public static IQueryable<TModel> Sort<TModel>(this IQueryable<TModel> source, SortingOptions sorting)
        {
            return sorting != null ? sorting.Sort<TModel>(source) : source;
        }

        public static IQueryable<TModel> TakePage<TModel>(this IQueryable<TModel> source, PagingOptions paging)
        {
            return paging != null ? paging.TakePage(source) : source;
        }
      
    }
}
