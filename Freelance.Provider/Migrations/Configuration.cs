
namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
  
    internal sealed class Configuration : DbMigrationsConfiguration<Freelance.Provider.Context.FreelanceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Freelance.Provider.Context.FreelanceDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //create roles
            var clientRole = new IdentityRole { Name = "client" };
            var freelancerRole = new IdentityRole { Name = "freelancer" };
            //add to database
            roleManager.Create(clientRole);
            roleManager.Create(freelancerRole);
        }
    }
}
