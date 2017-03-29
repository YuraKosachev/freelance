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
        //auth
        IUserManageProvider UserManageProvider { get; }
        ISignInManageProvider SignInManageProvider { get; }


        ICategoryProvider CategoryProvider { get; }
        IProfileProvider ProfileProvider { get; }
        IOfferProvider OfferProvider { get; }
    }
}
