using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Freelance.Service.FileManagerConfg;

namespace Freelance.Web
{
    public class AppPath
    {
        public static  void  SetAppPath()
        {
            FileProviderCfg.AppPath(HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["ImageStoreFolder"]));
        } 
    }
}