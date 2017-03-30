using System;
using System.Collections.Generic;
using Freelance.Service.ServicesModel;
using Freelance.Provider.EntityModels;
using Freelance.Provider.Interfaces;
using Freelance.Service.Interfaces;
using Freelance.Provider;
using mapper =  AutoMapper;

namespace Freelance.Service.Services
{
    public class CategoryServiceMapperProfile : mapper.Profile
    {
        public CategoryServiceMapperProfile()
        {
            CreateMap<CategoryServiceModel, Category>().ReverseMap();
               

        }

    }

    public class CategoryService : FreelanceService<CategoryServiceModel, Category>, ICategoryService
    {
        public CategoryService()
        {
            Provider = new ProviderFactory().CategoryProvider;
           
        }
        public IDictionary<Guid, string> Lookup()
        {
            return (Provider as ICategoryProvider).Lookup();
        }
    }
}
