using Freelance.Provider.Interfaces;
using Freelance.Provider.EntityModels;

namespace Freelance.Provider.Providers
{
    public class ProfileProvider:FreelanceProvider<Profile>,IProfileProvider
    {
        public ProfileProvider() : base() { }
        //public virtual Extensions.Interfaces.IAppQuery<> GetList()
        //{
        //    return new AppQuery<>(Context.Set<TModel>());
        //}
    }
}
