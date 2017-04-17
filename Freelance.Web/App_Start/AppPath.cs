using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Freelance.Web
{
    public class AppPath
    {
        public static  string GetAppPath()
        {
            return HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["ImageStoreFolder"]);
        } 
    }
}