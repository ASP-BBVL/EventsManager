using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib
{
	class Event
	{
		[Key]
		public int EventId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public string EnteredByUsername { get; set; }
		
		[ForeignKey]
		public int ActivityCategory { get; set; }

		public DateTime CreationDate { get; set; }

		public Activity Activity { get; set; }
	}
}
