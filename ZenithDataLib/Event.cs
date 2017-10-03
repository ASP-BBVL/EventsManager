using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib
{
	public class Event
	{
		[Key]
		public int EventId { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
		[Required(ErrorMessage = "Start date is required!")]
		public DateTime StartDate { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
		[Required(ErrorMessage = "End date is required!")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Created By")]
		public string EnteredByUsername { get; set; }

		[ForeignKey("Activity")]
		[Display(Name = "Activity Type")]
		[Required(ErrorMessage = "Activity type is required!")]
		public int ActivityCategory { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date Created")]
		public DateTime CreationDate { get; set; }

		public Activity Activity { get; set; }

		[Display(Name = "Active")]
		[Required(ErrorMessage = "Must be set active or inactive")]
		public Boolean IsActive { get; set; }
	}
}
