using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Extensions.Interfaces
{
    public interface IFilteringOptions<TModel>
    {
        IQueryable<TModel> Filter(IQueryable<TModel> context);
    }
}
