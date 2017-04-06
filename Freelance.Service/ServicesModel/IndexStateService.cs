
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Service.ServicesModel
{
    public class IndexStateService
    {
        public int Page { get; set; }
        public string SearchString { get; set; }
        public bool SortAscending { get; set; }
        public string SortProperty { get; set; }
        public int CountItemInPage { get; set; }
    }
}
