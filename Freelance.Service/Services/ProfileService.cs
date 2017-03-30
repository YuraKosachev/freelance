﻿using System;
using Freelance.Service.ServicesModel;
using Freelance.Provider.EntityModels;
using Freelance.Service.Interfaces;
using Freelance.Provider;
using mapper =  AutoMapper;

namespace Freelance.Service.Services
{
    public class ProfileServiceMapperProfile : mapper.Profile
    {
        public ProfileServiceMapperProfile()
        {
            CreateMap<ProfileServiceModel,Profile>().ReverseMap()
                .ForMember(item => item.CategoryName, exp => exp.MapFrom(src => src.Category.NameCategory))
                .ForMember(item => item.FreelancerName, exp => exp.MapFrom(src => String.Format("{0} {1}", src.User.UserFirstName, src.User.UserSurname)))
                .ForMember(item => item.PhoneNumber, exp => exp.MapFrom(src => src.User.PhoneNumber));
           

        }

    }


    public class ProfileService : FreelanceService<ProfileServiceModel, Profile>, IProfileService
    {
        public ProfileService()
        {
            Provider = new ProviderFactory().ProfileProvider;

        }
    }
}
