using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using Freelance.Provider.Providers;


namespace Freelance.Web
{
    public static class IdentityExtensions
    {
        private static string _firstName;
        public static string GetUserFirstName(this IIdentity identity)
        {
            return _firstName;
        }
        public static void SetUserFirstName(this IIdentity identity,string name)
        {
            _firstName = name;
        }
    }
}