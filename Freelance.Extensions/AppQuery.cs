﻿using System;
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
        public FilteringOptions Filtering { get; set; }
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

        public IAppQuery<TModel> SetFilterOptions<TType>(string property,TType value )
        {
            Filtering = new FilteringOptions(String.Format("{0} == \"{1}\"",property,value));
            return this;
        }
        public IAppQuery<TModel> FilterXor<TType>(string property, TType value)
        {
            Filtering = new FilteringOptions(String.Format("{0} != {1}", property, value));
            return this;
        }
        public IAppQuery<TModel> FilterAndXor<TType>(string property, TType value)
        {
            if (Filtering != null)
                Filtering.Query += String.Format(" AND {0} != {1}", property, value);
            return this;
        }
        public IAppQuery<TModel> FilterOrXor<TType>(string property, TType value)
        {
            if (Filtering != null)
                Filtering.Query += String.Format(" OR {0} != {1}", property, value);
            return this;
        }
        public IAppQuery<TModel> FilterAnd<TType>(string property, TType value)
       {
            if (Filtering != null)
                Filtering.Query += String.Format(" AND {0} == {1}", property, value);
            return this;
       }
        public IAppQuery<TModel> FilterOr<TType>(string property, TType value)
        {
            if (Filtering != null)
                Filtering.Query += String.Format(" OR {0} == {1}", property, value);
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
