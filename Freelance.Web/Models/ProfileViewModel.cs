﻿using System;
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
        [Display(Name = "Имя фрилансера")]
        public string FreelancerName { get; set; }
        [Display(Name ="Вид работ")]
        public string CategoryName { get; set; }
        [Display(Name = "Описание профиля")]
        public string DescriptionProfile { get; set; }
        [Display(Name = "Время доступности")]
        public string TimeAvailability { get; set; }
        [Display(Name ="Номер телефона")]
        public string PhoneNumber { get; set; }

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
        public IDictionary<Guid, string> Categories { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}