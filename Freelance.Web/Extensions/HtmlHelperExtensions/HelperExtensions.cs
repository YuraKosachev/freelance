using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Freelance.Web.Models;
using WebGrease.Css.Extensions;

namespace Freelance.Web.HtmlHelperExtensions
{
    public static class HelperExtensions
    {
        public static string Link(this UrlHelper helper, string action, IndexState indexState, string sortProperty)
        {
            var indexStateRoutes = new RouteValueDictionary(new
            {
                indexState.SearchString,
                SortProperty = sortProperty,
                SortAscending = !(indexState.SortAscending && indexState.SortProperty == sortProperty),
                CategoryId = indexState.CategoryId,
                TimeAvailability = indexState.TimeAvailability

            });

            indexState.GetFilters().ForEach(r => indexStateRoutes.Add(r.Key, r.Value));

            return helper.Action(action, indexStateRoutes);
        }

        public static string ActionToPage(this UrlHelper helper, string action, IndexState indexState, int page)
        {
            var indexStateRoutes = new RouteValueDictionary(new
            {
                page,
                indexState.SearchString,
                indexState.SortProperty,
                indexState.SortAscending,
                indexState.TimeAvailability,
                indexState.CategoryId
            });

            indexState.GetFilters().ForEach(r => indexStateRoutes.Add(r.Key, r.Value));

            return helper.Action(action, indexStateRoutes);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src = null, string dataSrc = null, object htmlAttributes = null) //string altText = null, string height = null)
        {
            var builder = new TagBuilder("img");

            if (src == null)
                builder.MergeAttribute("data-src", dataSrc);
            else
                builder.MergeAttribute("src", src);

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString Image(this HtmlHelper helper, Guid? imageId,string typeExtesion,string folder,int holderH,int holderW , object htmlAttributes = null)
        {
            if (imageId != null)
            {
                var path = String.Format(@"/upload/{0}/{1}.{2}", folder,imageId,typeExtesion);
                return helper.Image(path,htmlAttributes:htmlAttributes);
            }

            return helper.Image(dataSrc:String.Format("holder.js/{0}x{1}",holderH,holderW), htmlAttributes : htmlAttributes);
        }
        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string action, IndexState indexState)
        {
            return helper.ActionLink(linkText, action, indexState, new RouteValueDictionary(), new Dictionary<string, object>());
        }
        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string action, IndexState indexState, object routeValues)
        {
            return helper.ActionLink(linkText, action, indexState, new RouteValueDictionary(routeValues), new Dictionary<string, object>());
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string action, IndexState indexState, object routeValues, object htmlAttributes)
        {
            return helper.ActionLink(linkText, action, indexState, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string action, IndexState indexState, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            var indexStateRoutes = new RouteValueDictionary(new
            {
                indexState.Page,
                indexState.SearchString,
                indexState.SortProperty,
                indexState.SortAscending,
                indexState.TimeAvailability,
                indexState.CategoryId
            });

            indexState.GetFilters().ForEach(r => indexStateRoutes.Add(r.Key, r.Value));

            var routeCombined = new RouteValueDictionary(indexStateRoutes.Union(routeValues).ToDictionary(k => k.Key, k => k.Value));

            return helper.ActionLink(linkText, action, routeCombined, htmlAttributes);
        }

        public static string GetSortClass(this HtmlHelper helper, IndexState indexState, string sortProperty, string onAsc = "glyphicon glyphicon-chevron-up", string onDesc = "glyphicon glyphicon-chevron-down", string offDesc = "glyphicon glyphicon-certificate")
        {
            return indexState.SortProperty == sortProperty ? (indexState.SortAscending ? onAsc : onDesc) : offDesc;
        }
    }
}