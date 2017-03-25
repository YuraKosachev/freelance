using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Provider.Interfaces;
using Freelance.Provider.EntityModels;

namespace Freelance.Provider.Providers
{
    public class CategoryProvider:FreelanceProvider<Category>,ICategoryProvider
    {
        public CategoryProvider():base() { }

        public IDictionary<Guid, string> Lookup()
        {
            return Context.Set<Category>().ToDictionary<Category, Guid, string>(key => key.Id, value => value.NameCategory);
        }
    }
}
