using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Service.ServicesModel
{
    public class ProfileServiceModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string DescriptionProfile { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}
