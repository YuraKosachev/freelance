using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Provider.EntityModels
{
    public class ProfileAugmentedModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string DescriptionProfile { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}
