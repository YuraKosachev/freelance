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
        public FilteringOptions<TModel> Filtering { get; set; }
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

        public IAppQuery<TModel> SetFilterOptions(string predicate,params object[] values )
        {
            
                Filtering = new FilteringOptions<TModel>(predicate, values);
            
            return this;
        }
        public IAppQuery<TModel> FilterAnd(string predicate, params object[] values)
        {
            if (Filtering != null)
            {
                var key = Filtering.NextKey();
                Filtering.Queries.Add(key, FilterPredicate<TModel>.GetExpression(predicate, values));
                Filtering.Predicate = String.Format("{0} AND @{1}(it)", Filtering.Predicate, key);
            }
            else
            {
                SetFilterOptions(predicate, values);
            } 
            return this;
        }
        public IAppQuery<TModel> FilterOr(string predicate, params object[] values)
        {
            if (Filtering != null)
            {
                var key = Filtering.NextKey();
                Filtering.Queries.Add(key, FilterPredicate<TModel>.GetExpression(predicate, values));
                Filtering.Predicate = String.Format("{0} OR @{1}(it)", Filtering.Predicate, key);
            }
            else
            {
                SetFilterOptions(predicate, values);
            }
            return this;
        }

        // public IAppQuery<TModel> FilterXor<TType>(string property, TType value)
        // {
        //     Filtering = new FilteringOptions(String.Format("{0} != {1}", property, value));
        //     return this;
        // }
        // public IAppQuery<TModel> FilterAndXor<TType>(string property, TType value)
        // {
        //     if (Filtering != null)
        //         Filtering.Query += String.Format(" AND {0} != {1}", property, value);
        //     return this;
        // }
        // public IAppQuery<TModel> FilterOrXor<TType>(string property, TType value)
        // {
        //     if (Filtering != null)
        //         Filtering.Query += String.Format(" OR {0} != {1}", property, value);
        //     return this;
        // }
        // public IAppQuery<TModel> FilterAnd<TType>(string property, TType value)
        //{
        //     if (Filtering != null)
        //         Filtering.Query += String.Format(" AND {0} == {1}", property, value);
        //     return this;
        //}
        // public IAppQuery<TModel> FilterOr<TType>(string property, TType value)
        // {
        //     if (Filtering != null)
        //         Filtering.Query += String.Format(" OR {0} == {1}", property, value);
        //     return this;
        // }

        public IEnumerator<TModel> GetEnumerator()
        {
            return Query.Filter(Filtering).Sort(Sorting).TakePage(Paging).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //delete
        //public IAppQuery<TModel> FilterString(string query)
        //{
        //    Filtering = new FilteringOptions(query);
        //    return this;
        //}
    }
}
