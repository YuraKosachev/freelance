using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces.AuthServices;
using Freelance.Provider;
using Freelance.Provider.Interfaces;
using Owin;

namespace Freelance.Service.Services.AuthService
{
    public class AuthCfgService : IAuthCfgService
    {
        private IAuthConfig ProviderAuthConfig { get; set; }
        public AuthCfgService()
        {
            ProviderAuthConfig = new ProviderFactory().AuthConfig;
        }
        public void Config(IAppBuilder app, string path)
        {
            ProviderAuthConfig.Config(app,path);
        }

        public void ConfigureAuth()
        {
            ProviderAuthConfig.ConfigureAuth();
        }
    }
}
