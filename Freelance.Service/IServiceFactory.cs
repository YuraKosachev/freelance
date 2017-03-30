using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces.AuthServices;
using Freelance.Service.Services;
using Freelance.Service.Interfaces;
namespace Freelance.Service
{
    public interface IServiceFactory
    {
        ISignInManageService SignInManageService { get; }
        IUserManageService UserManageService { get; }
        ICategoryService CategoryService { get; }
    }
}
