using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Extensions.Interfaces
{
    public interface IPagingOptions<TModel>
    {
        IQueryable<TModel> TakePage(IQueryable<TModel> model);
    }
}
