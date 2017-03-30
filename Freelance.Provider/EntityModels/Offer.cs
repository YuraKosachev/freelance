using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;


namespace Freelance.Provider.EntityModels
{
    public class Offer:IModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool FreelancerConfirm { get; set; }

        //navi setting

        public ICollection<Profile> Profiles { get; set; }
    }
}
