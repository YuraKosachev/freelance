using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces.AuthServices;
using Freelance.Service.Services;
namespace Freelance.Service
{
    public interface IServiceFactory
    {
        ISignInManageService SignInManageProvider { get; }
        IUserManageService UserManageProvider { get; }
    }
}
