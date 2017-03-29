using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Freelance.Web.Models;
using Freelance.Service;
using Freelance.Service.Interfaces.AuthServices;

using Freelance.Service.ServicesModel;


//using Freelance.Provider;
//using Freelance.Provider.Providers;
//using Freelance.Provider.EntityModels;
//using Freelance.Provider.Interfaces;

namespace Freelance.Web.Controllers
{
    public class AuthControllerMapperProfile : AutoMapper.Profile
    {
        public AuthControllerMapperProfile()
        {
            CreateMap<VerifyCodeViewModel, VerifyCodeServiceModel>();
            CreateMap<LoginViewModel,LoginServiceModel>();
            CreateMap<RegisterViewModel, UserServiceModel>()
                .ForMember(item => item.UserName, exp => exp.MapFrom(src => src.Email))
                .ForMember(item => item.UserSurname, exp => exp.MapFrom(src => src.Surname))
                .ForMember(item => item.UserFirstName, exp => exp.MapFrom(src => src.Name));
            CreateMap<ExternalLoginConfirmationViewModel, UserServiceModel>()
                .ForMember(item => item.UserName, exp => exp.MapFrom(src => src.Email))
                .ForMember(item => item.Email, exp => exp.MapFrom(src => src.Email));
        }

    }
   
    public abstract class AuthController:Controller
    {
        protected IUserManageService _userManageService;
        protected ISignInManageService _signInManageService;

        public IUserManageService UserManageService
        {
            get
            {
                _userManageService.Context = HttpContext.GetOwinContext();
                return _userManageService;
            }
            protected set
            {
                _userManageService = value;
            }
        }
        public ISignInManageService SignInManageService
        {
            get
            {
                _signInManageService.Context = HttpContext.GetOwinContext();
                return _signInManageService;
            }
            protected set
            {
                _signInManageService = value;
            }
        }

        public AuthController()
        {
            var accountService = new ServiceFactory();
            UserManageService = accountService.UserManageProvider;
            SignInManageService = accountService.SignInManageProvider;
        }
        
        // Используется для защиты от XSRF-атак при добавлении внешних имен входа
        protected const string XsrfKey = "XsrfId";

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}