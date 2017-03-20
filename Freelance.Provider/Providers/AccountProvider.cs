using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Provider.EntityModels;
using Freelance.Provider.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Freelance.Provider.Providers
{
    public class AccountProvider : IAccountProvider
    {
        private FreelanceSignInManager _signInManager;
        private FreelanceUserManager _userManager;

        public AccountProvider()
        {
            
        }

        public AccountProvider(IOwinContext context, FreelanceUserManager userManager, FreelanceSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = context;
        }
        public IOwinContext Context { get; set; }
        
        public FreelanceSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? Context.Get<FreelanceSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public FreelanceUserManager UserManager
        {
            get
            {
                return _userManager ?? Context.GetUserManager<FreelanceUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo loginInfo)
        {
            return AddLoginAsync(userId, loginInfo);
        }

        public Task<IdentityResult> ConfirmEmailAsync(string userId, string code)
        {
           return UserManager.ConfirmEmailAsync(userId, code);
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return UserManager.CreateAsync(user, password);
        }

        public Task<IdentityResult> CreateAsync(User user)
        {
            return UserManager.CreateAsync(user);
        }
        public Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent)
        {
            return SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
        }

        public Task<User> FindByNameAsync(string name)
        {
            return UserManager.FindByNameAsync(name);
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId)
        {
            return UserManager.GetValidTwoFactorProvidersAsync(userId);
        }

        public Task<string> GetVerifiedUserIdAsync()
        {
           return SignInManager.GetVerifiedUserIdAsync();
        }

        public Task<bool> HasBeenVerifiedAsync()
        {
            return SignInManager.HasBeenVerifiedAsync();
        }

        public Task<bool> IsEmailConfirmedAsync(string userId)
        {
            return UserManager.IsEmailConfirmedAsync(userId);
        }

        public Task<SignInStatus> PassSignInAsync(LoginProviderModel model,bool shouldLockout)
        {
            return SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        }

        public Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            return UserManager.ResetPasswordAsync(userId,token,newPassword);
        }

        public Task<bool> SendTwoFactorCodeAsync(string provider)
        {
            return SignInManager.SendTwoFactorCodeAsync(provider);
        }

        public Task SignInAsync(User user, bool isPersistent, bool rememberBrowser)
        {
            return SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        }

        public Task<SignInStatus> TwoFactorSignInAsync(VerifyCodeProviderModel model)
        {
            return SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
        }
        //ПРОСМОТРЕТЬ
        private bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
