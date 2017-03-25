using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Provider.EntityModels
{
    public class Category:IModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string NameCategory { get; set; }
        [Required]
        public string DescriptionCategory { get; set; }

        public virtual Profile Profile { get; set; }

    }
}
