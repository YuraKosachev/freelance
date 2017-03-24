using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Extensions.Interfaces;

namespace Freelance.Extensions
{
    public class AppQuery<TModel> : IAppQuery<TModel>
    {
        private IQueryable<TModel> Query { get; set; }
        private IPagingOptions<TModel> Paging { get; set; }
        private ISortingOptions<TModel> Sorting { get; set; }
        private IFilteringOptions<TModel> Filtering { get; set; }
        public AppQuery(IQueryable<TModel> query)
        {
            Query = query;
        }
        public IAppQuery<TModel> SetPageOptions()
        {
            //Paging =
            return this;
        }

        public IAppQuery<TModel> SetSortOptions()
        {
            //Sorting =
            return this;
        }

        public IAppQuery<TModel> SetFilterOptions()
        {
            //Filtering = 
            return this;
        }
        public IEnumerator<TModel> GetEnumerator()
        {
            return Query.Filter(Filtering).Sort(Sorting).TakePage(Paging).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }
}
