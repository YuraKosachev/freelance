using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Provider.EntityModels
{
    public class Profile:IModel
    {
        [Key]
        [ForeignKey("Category")]
        public Guid Id { get; set; }
        //[ForeignKey("User")]
        public string UserId { get; set; }
        //[ForeignKey("Category")]
        //public Guid CategoryId { get; set; }
        [Required]
        public string DescriptionProfile { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        //navi setting
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
