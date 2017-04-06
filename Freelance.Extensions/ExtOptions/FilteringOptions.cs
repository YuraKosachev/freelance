using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Freelance.Extensions
{
    public class FilteringOptions
    {
        public string Query { get; set; }
        public FilteringOptions(string query)
        {
            Query = query;
        }

        public IQueryable<TModel> Filter<TModel>(IQueryable<TModel> context)
        {
            return context.Where(Query);
        }
    }
}
