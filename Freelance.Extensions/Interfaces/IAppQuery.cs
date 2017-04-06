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
        IAppQuery<TModel> SetFilterOptions(IFilteringOptions<TModel> filteringOptions);
        int CountItem();
    }
}
