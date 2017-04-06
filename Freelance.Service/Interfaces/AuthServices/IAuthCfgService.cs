using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace Freelance.Service.Interfaces.AuthServices
{
   public interface IAuthCfgService
    {
        void Config(IAppBuilder app, string path);
        void ConfigureAuth();
    }
}
