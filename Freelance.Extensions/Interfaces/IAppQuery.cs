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
        IAppQuery<TModel> SetFilterOptions<TType>(string property,TType value);
        IAppQuery<TModel> FilterXor<TType>(string property, TType value);
        IAppQuery<TModel> FilterAndXor<TType>(string property, TType value);
        IAppQuery<TModel> FilterOrXor<TType>(string property, TType value);
        IAppQuery<TModel> FilterAnd<TType>(string property, TType value);
        IAppQuery<TModel> FilterOr<TType>(string property, TType value);
        IAppQuery<TModel> FilterString(string query);//delete
        int CountItem();
    }
}
