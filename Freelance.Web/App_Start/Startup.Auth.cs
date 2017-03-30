using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Freelance.Web.Models;
using Freelance.Service;
namespace Freelance.Web
{
    public partial class Startup
    {
        // Дополнительные сведения о настройке проверки подлинности см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var config = new ServiceFactory().AuthCfgService;
            config.Config(app, "/Account/Login");
            config.ConfigureAuth();
            //FreelanceAuthConfg.Create(app, "/Account/Login").ConfigureAuth();
       
        }
    }
}