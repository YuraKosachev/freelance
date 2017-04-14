using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Extensions.Interfaces
{
    public interface IAppQuery<TModel>:IEnumerable<TModel>
    {
        IAppQuery<TModel> SetPageOptions(int current,int size);
        IAppQuery<TModel> SetSortOptions(string property, bool ascending);
        IAppQuery<TModel> SetFilterOptions(string predicate,params object[] values);
        //IAppQuery<TModel> FilterXor<TType>(string property, TType value);
        //IAppQuery<TModel> FilterAndXor<TType>(string property, TType value);
        //IAppQuery<TModel> FilterOrXor<TType>(string property, TType value);
        IAppQuery<TModel> FilterAnd(string predicate, params object[] values);
        IAppQuery<TModel> FilterOr(string predicate, params object[] values);
        
        int CountItem();
    }
}
