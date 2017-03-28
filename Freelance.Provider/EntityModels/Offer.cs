using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Provider.EntityModels
{
    public class Offer:IModel
    {
        [Key]
        public Guid Id { get; set; }
        //[ForeignKey("Profile")]
        //public Guid ProfileId { get; set; } 
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //navi setting

        public ICollection<Profile> Profiles { get; set; }
    }
}
