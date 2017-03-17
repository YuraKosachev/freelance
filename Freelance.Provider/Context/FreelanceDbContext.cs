using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Freelance.Provider.EntityModels;
using System.Data.Entity;

namespace Freelance.Provider.Context
{
    public class FreelanceDbContext : IdentityDbContext<User>
    {
        public FreelanceDbContext()
            : base("FreelanceConnection", throwIfV1Schema: false)
        { }
        

        public static FreelanceDbContext Create()
        {
            return new FreelanceDbContext();
        }
    }
}
