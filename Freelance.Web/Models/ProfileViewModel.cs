using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.Web.Models
{
    public class ProfileListViewModel
    {
       
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FreelancerName { get; set; } 
        public string CategoryName { get; set; }
        public string DescriptionProfile { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
       
    }
    public class ProfileCreateEditViewModel
    {
        
        public Guid Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public Guid CategoryId { get; set; }
        [Required]
        [Display(Name ="Описание")]
        [DataType(DataType.MultilineText)]
        public string DescriptionProfile { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}