using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Extensions.Interfaces
{
    public interface ISortingOptions<TModel>
    {
        IQueryable<TModel> Sort(IQueryable<TModel> model);
    }
}
