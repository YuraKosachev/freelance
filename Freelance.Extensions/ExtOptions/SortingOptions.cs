﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Freelance.Extensions
{
    public class SortingOptions
    {
        public string Property { get; set; }
        public bool Ascending { get; set; }
        public SortingOptions(string property, bool ascending)
        {
            Property = property;
            Ascending = ascending;

        }
        public IQueryable<TModel> Sort<TModel>(IQueryable<TModel> source)
        {
            return source.OrderBy(Property);
        }

    }
}
