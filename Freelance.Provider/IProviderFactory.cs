using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Provider.Interfaces;
namespace Freelance.Provider
{
    public interface IProviderFactory
    {
        ICategoryProvider CategoryProvider { get; }
    }
}
