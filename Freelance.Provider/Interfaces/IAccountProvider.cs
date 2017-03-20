using System;
using System.Collections.Generic;
using System.Linq;
using Freelance.Provider.EntityModels;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;

namespace Freelance.Provider.Interfaces
{
    public interface IAccountProvider:IDisposable
    {
        Task<SignInStatus> PassSignInAsync(LoginProviderModel model,bool shouldLockout);
        Task<bool> HasBeenVerifiedAsync();
        Task<SignInStatus> TwoFactorSignInAsync(VerifyCodeProviderModel model);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task SignInAsync(User user, bool isPersistent, bool rememberBrowser);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string code);
        Task<User> FindByNameAsync(string name);
        Task<bool> IsEmailConfirmedAsync(string userId);
        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);
        Task<string> GetVerifiedUserIdAsync();
        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);
        Task<bool> SendTwoFactorCodeAsync(string provider);
        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo loginInfo);
        Task<IdentityResult> CreateAsync(User user);
        IOwinContext Context { get; set; }
    }
}
