using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces.AuthServices;
using Freelance.Service.Services;

namespace Freelance.Service
{
    public class ServiceFactory : IServiceFactory
    {
        public IUserManageService UserManageProvider
        {
            get { return new UserManageService(); }
        }

        public ISignInManageService SignInManageProvider
        {
            get { return new SignInManageService(); }
        }
    }
}
