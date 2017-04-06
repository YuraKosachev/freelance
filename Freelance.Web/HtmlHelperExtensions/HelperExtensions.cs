using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Freelance.Web.Models;

namespace Freelance.Web.HtmlHelperExtensions
{
    public static class HelperExtensions
    {
        public static string SortLink(this UrlHelper helper, string action, IndexState indexState, string sortProperty)
        {
            var indexStateRoutes = new RouteValueDictionary(new
            {
                indexState.SearchString,
                SortProperty = sortProperty,
                SortAscending = !(indexState.SortAscending && indexState.SortProperty == sortProperty)
            });

            //indexState.GetFilters().ForEach(r => indexStateRoutes.Add(r.Key, r.Value));

            return helper.Action(action, indexStateRoutes);
        }
    }
}