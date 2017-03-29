using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Provider.Interfaces;
using Freelance.Provider.Providers;

namespace Freelance.Provider
{
    public class ProviderFactory : IProviderFactory
    {
        public ICategoryProvider CategoryProvider
        {
            get { return new CategoryProvider(); }
        }

        public IProfileProvider ProfileProvider
        {
            get { return new ProfileProvider(); }
        }
        public IOfferProvider OfferProvider 
        {
            get { return new OfferProvider(); }
        }

        public IUserManageProvider UserManageProvider
        {
            get { return new UserManageProvider(); }
        }

        public ISignInManageProvider SignInManageProvider
        {
            get { return new SignInManageProvider(); }
        }

       
    }
}
