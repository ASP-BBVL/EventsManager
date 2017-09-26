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
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public string EnteredByUsername { get; set; }
		
		[ForeignKey("Activity")]
		public int ActivityCategory { get; set; }

		public DateTime CreationDate { get; set; }

		public Activity Activity { get; set; }

		public Boolean IsActive { get; set; }
	}
}
