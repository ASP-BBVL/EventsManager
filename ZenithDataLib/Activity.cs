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

		public string ActivityDescription { get; set; }

		public DateTime CreationDate { get; set; }
	}
}
