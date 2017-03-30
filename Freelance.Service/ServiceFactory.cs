using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces.AuthServices;
using Freelance.Service.Services.AuthService;
using Freelance.Service.Interfaces;
using Freelance.Service.Services;

namespace Freelance.Service
{
    public class ServiceFactory : IServiceFactory
    {
        public IUserManageService UserManageService
        {
            get { return new UserManageService(); }
        }

        public ISignInManageService SignInManageService
        {
            get { return new SignInManageService(); }
        }
        public ICategoryService CategoryService
        {
            get { return new CategoryService(); }
        }
        public IProfileService ProfileService
        {
            get { return new ProfileService(); }
        }

        public IAuthCfgService AuthCfgService
        {
            get
            {
                return new AuthCfgService();
            }
        }
    }
}
