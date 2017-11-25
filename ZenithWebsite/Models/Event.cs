using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class Event
    {
            [Key]
            public int EventId { get; set; }

            [DataType(DataType.DateTime)]
            [Display(Name = "Start Date")]
            [Required(ErrorMessage = "Start date is required!")]
            public DateTime StartDate { get; set; }

            [DataType(DataType.DateTime)]
            [Display(Name = "End Date")]
            [Required(ErrorMessage = "End date is required!")]
            public DateTime EndDate { get; set; }

            private string _EnteredByUsername = "";
            [HiddenInput(DisplayValue = true)]
            [Display(Name = "Entered By")]
            public string EnteredByUsername { get { return _EnteredByUsername; } set { _EnteredByUsername = value; } }

            [ForeignKey("Activity")]
            [Display(Name = "Activity Name")]
            [Required(ErrorMessage = "Activity type is required!")]
            public int ActivityCategory { get; set; }

            private DateTime _CreationDate = DateTime.Now;
            [DataType(DataType.Date)]
            [HiddenInput(DisplayValue = true)]
            [Display(Name = "Creation Date")]
            public DateTime CreationDate { get { return _CreationDate; } set { _CreationDate = value; } }

            public Activity Activity { get; set; }

            [Display(Name = "Active")]
            public Boolean IsActive { get; set; }
    }
}
