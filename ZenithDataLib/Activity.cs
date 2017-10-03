using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib
{
	public class Activity
	{
		[Key]
		public int ActivityCategoryId { get; set; }

		[Display(Name = "Activity Name")]
		[Required(ErrorMessage = "A name is required!")]
		public string ActivityDescription { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date Created")]
		public DateTime CreationDate { get; set; }
	}
}
