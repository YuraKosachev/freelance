using System;
using System.ComponentModel.DataAnnotations;
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
        public string NameCategory { get; set; }
        public string DescriptionCategory { get; set; }

    }
}
