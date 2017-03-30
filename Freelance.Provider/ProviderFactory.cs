using Freelance.Provider.Interfaces;
using Freelance.Provider.Providers;
using Freelance.Provider.AuthConfg;

namespace Freelance.Provider
{
    public class ProviderFactory : IProviderFactory
    {
        public IAuthConfig AuthConfig
        {
            get { return new FreelanceAuthConfg(); }
        }
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
