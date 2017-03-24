using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Provider.EntityModels
{
    public interface IModel
    {
        Guid Id { get; set; }
    }
}
