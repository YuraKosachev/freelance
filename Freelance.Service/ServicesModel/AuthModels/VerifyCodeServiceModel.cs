using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Service.ServicesModel
{
    public class VerifyCodeServiceModel
    {
        public string Provider { get; set; }
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberBrowser { get; set; }
        public bool RememberMe { get; set; }
    }
}
