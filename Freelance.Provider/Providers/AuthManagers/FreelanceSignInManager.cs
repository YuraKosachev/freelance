using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Freelance.Provider.EntityModels;


namespace Freelance.Provider.Providers
{
    public class FreelanceSignInManager: SignInManager<User, string>
    {
        public FreelanceSignInManager(FreelanceUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((FreelanceUserManager)UserManager);
        }

        public static FreelanceSignInManager Create(IdentityFactoryOptions<FreelanceSignInManager> options, IOwinContext context)
        {
            return new FreelanceSignInManager(context.GetUserManager<FreelanceUserManager>(), context.Authentication);
        }
    }
}
