using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Extensions.Interfaces
{
    public interface IAppQuery<TModel>:IEnumerable<TModel>
    {
        IAppQuery<TModel> SetPageOptions();
        IAppQuery<TModel> SetSortOptions();
        IAppQuery<TModel> SetFilterOptions();
    }
}
