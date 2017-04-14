using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Freelance.Extensions
{
    public class FilterPredicate<TModel>
    {
        private Expression<Func<TModel, bool>> Query { get;  set; }
        public FilterPredicate(string predicate, object[] values)
        {
            Query = System.Linq.Dynamic.DynamicExpression.ParseLambda<TModel, bool>(predicate, values);
        }
        public static Expression<Func<TModel, bool>> GetExpression(string predicate,object[] values)
        {
            return new FilterPredicate<TModel>(predicate, values).Query;
        }
    }
}
