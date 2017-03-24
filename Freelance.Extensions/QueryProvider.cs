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
        public static IQueryable<TModel> Filter<TModel>(this IQueryable<TModel> source, IFilteringOptions<TModel> filter)
        {
            return filter != null ? filter.Filter(source) : source;
        }

        public static IQueryable<TModel> Sort<TModel>(this IQueryable<TModel> source, ISortingOptions<TModel> sorting)
        {
            return sorting != null ? sorting.Sort(source) : source;
        }

        public static IQueryable<TModel> TakePage<TModel>(this IQueryable<TModel> source, IPagingOptions<TModel> paging)
        {
            return paging != null ? paging.TakePage(source) : source;
        }
    }
}
