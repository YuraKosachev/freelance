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
        public PagingOptions Paging { get; set; }
        public SortingOptions Sorting { get; set; }
        public IFilteringOptions<TModel> Filtering { get; set; }
        public AppQuery(IQueryable<TModel> query)
        {
            Query = query;
        }
        public int CountItem()
        {
            return Paging.Total;
        }
        public IAppQuery<TModel> SetPageOptions(int current, int size)
        {
            Paging = new PagingOptions(current, size);
            return this;
        }

        public IAppQuery<TModel> SetSortOptions(string property, bool ascending)
        {
            Sorting = new SortingOptions(property, ascending);
            return this;
        }

        public IAppQuery<TModel> SetFilterOptions(IFilteringOptions<TModel> filteringOptions)
        {
            Filtering = filteringOptions;
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
