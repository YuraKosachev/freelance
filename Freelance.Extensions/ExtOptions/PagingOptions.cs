﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Freelance.Extensions
{
    public class PagingOptions
    {
        internal PagingOptions(int current, int size)
        {
            Current = current;
            Size = size;
        }

        public int Current { get; private set; }
        public int Size { get; private set; }
        public int Total { get; private set; }

        public IQueryable<TEntity> TakePage<TEntity>(IQueryable<TEntity> source)
        {
            Total = source.Count();
            return source.Skip((Current - 1) * Size).Take(Size);
        }
    }
}
