using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Provider.Interfaces;
using Freelance.Provider.EntityModels;
using Freelance.Extensions;

namespace Freelance.Provider.Providers
{
    public class OfferProvider: FreelanceProvider<Offer>, IOfferProvider
    {
        public OfferProvider() : base() { }
        public override Extensions.Interfaces.IAppQuery<Offer> GetList()
        {
            return new AppQuery<Offer>(Context.Set<Offer>().Include("Profiles"));
        }
    }
}
