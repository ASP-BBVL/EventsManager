using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ZenithDataLib;
using ZenithSociety.Models;

namespace ZenithSociety.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		public ActionResult Index()
		{http://localhost:60461/Properties/
			var dates = new Dictionary<DateTime, List<Event>>();
			//TODO get current date => Week
			var today = DateTime.Now;
			if (today.DayOfWeek != DayOfWeek.Monday)
			{
                int delta = 0;
                if(today.DayOfWeek == DayOfWeek.Sunday)
                {
                    delta = -6; 
                } else
                {
                    delta = DayOfWeek.Monday - today.DayOfWeek;
                }
				today = today.AddDays(delta);
			}
			System.Diagnostics.Debug.WriteLine(today.ToShortDateString());
			while (today.DayOfWeek != DayOfWeek.Sunday)
			{
				var events = db.Events.Include(e => e.Activity).Where(e => e.StartDate.Day == today.Day && e.StartDate.Month == today.Month && e.StartDate.Year == today.Year && e.IsActive).ToList();
				dates.Add(today, events);
				today = today.AddDays(1);
			}
			return View(dates);
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