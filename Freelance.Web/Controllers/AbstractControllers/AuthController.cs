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

using Freelance.Provider.Providers;
using Freelance.Provider.EntityModels;
using Freelance.Provider.Interfaces;

namespace Freelance.Web.Controllers
{
    public abstract class AuthController:Controller
    {
        protected IUserManageProvider _userManageService;
        protected ISignInManageProvider _signInManageService;

        public IUserManageProvider UserManageService
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
        public ISignInManageProvider SignInManageService
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
            UserManageService = new UserManageProvider();
            SignInManageService = new SignInManageProvider();
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