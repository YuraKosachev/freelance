using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Freelance.Extensions
{
    public class FilteringOptions<TModel>
        
    {
        public IDictionary<int, Expression<Func<TModel, bool>>> Queries { get; set; }
        public string Predicate { get; set; }
        public FilteringOptions(string predicate,params object[] values)
        {
            Queries = new Dictionary<int, Expression<Func<TModel, bool>>>();
            Queries.Add(0, FilterPredicate<TModel>.GetExpression(predicate, values));
            Predicate = String.Format("@{0}(it)",0);
           
        }
        public int NextKey()
        {
            var key = Queries.Keys.Last();
            return ++key;
        }
        public IQueryable<TModel> Filter(IQueryable<TModel> context)
        {
            var exp = System.Linq.Dynamic.DynamicExpression.ParseLambda<TModel, bool>(Predicate, Queries.Values.ToArray());
            return context.Where(exp);//Predicate, Queries.Values.ToArray());
        }
    }
}
