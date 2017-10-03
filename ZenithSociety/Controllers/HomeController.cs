using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZenithSociety.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var dates = new List<DateTime>();

			//TODO get current date => Week
			var today = DateTime.Now; 
			if(today.DayOfWeek != DayOfWeek.Monday)
			{
				int delta = DayOfWeek.Monday - today.DayOfWeek;
				DateTime monday = today.AddDays(delta);
			}
			//TODO collect events within current week

			ViewBag.WeekDates = dates;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}