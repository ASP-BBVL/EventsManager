using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Models;
using ZenithWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dates = new Dictionary<DateTime, List<Event>>();
            //TODO get current date => Week
            var today = DateTime.Now;
            if (today.DayOfWeek != DayOfWeek.Monday)
            {
                int delta = 0;
                if (today.DayOfWeek == DayOfWeek.Sunday)
                {
                    delta = -6;
                }
                else
                {
                    delta = DayOfWeek.Monday - today.DayOfWeek;
                }
                today = today.AddDays(delta);
            }
            System.Diagnostics.Debug.WriteLine(today.ToShortDateString());
            while (today.DayOfWeek != DayOfWeek.Sunday)
            {
                var events = _context.Events.Include(e => e.Activity).Where(e => e.StartDate.Day == today.Day && e.StartDate.Month == today.Month && e.StartDate.Year == today.Year && e.IsActive).ToList();
                dates.Add(today, events);
                today = today.AddDays(1);
            }
            return View(dates);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
