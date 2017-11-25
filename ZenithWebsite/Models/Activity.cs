using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class Activity
    {
        [Key]
        public int ActivityCategoryId { get; set; }

        [Display(Name = "Activity Name")]
        [Required(ErrorMessage = "A name is required!")]
        public string ActivityDescription { get; set; }

        private DateTime _CreationDate = DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        [HiddenInput(DisplayValue = true)]
        public DateTime CreationDate { get { return _CreationDate; } set { _CreationDate = value; } }
    }
}
