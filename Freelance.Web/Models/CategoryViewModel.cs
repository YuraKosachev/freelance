﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.Web.Models
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        [Required]
        [RegularExpression(@"^[A-zА-яЁё]+$", ErrorMessage = "Значение должно содержать только буквы")]
        [Display(Name = "Название категории")]
        public string NameCategory { get; set; }
        [Required]
        [Display(Name = "Описание категории")]
        public string DescriptionCategory { get; set; }
    }
}