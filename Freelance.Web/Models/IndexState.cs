using System;
using System.Web.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.Web.Models
{
    public class IndexState
    {
        public int? Page { get; set; }
        public string SearchString { get; set; }
        public bool SortAscending { get; set; }
        public string SortProperty { get; set; }
        public int CountItemInPage { get; set; }
        public Guid? CategoryId { get; set; }
        public TimeSpan? TimeAvailabilityFilter { get; set; }
        public virtual RouteValueDictionary GetFilters()
        {
            return new RouteValueDictionary();
        }
    }
}