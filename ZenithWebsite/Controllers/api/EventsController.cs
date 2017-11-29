using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithWebsite.Data;
using ZenithWebsite.Models;

namespace ZenithWebsite.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // api.events.ByWeek
        [HttpGet("ByWeek")]
        public async Task<IActionResult> GetByWeek(string d) {
            DateTime date;
            var dates = new Dictionary<DateTime, List<Event>>();
            if (d != null)
            {
                date = DateTime.Parse(d.ToString());
            }
            else
            {
                date = DateTime.Now;
            }
            //string d = HttpContext.Request.Query["data"].ToString()
            //TODO get current date => Week
            //var today = DateTime.Now;
            if (date.DayOfWeek != DayOfWeek.Monday)
            {
                int delta = 0;
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    delta = -6;
                }
                else
                {
                    delta = DayOfWeek.Monday - date.DayOfWeek;
                }
                date = date.AddDays(delta);
            }
            System.Diagnostics.Debug.WriteLine(date.ToShortDateString());
            var counter = 0; 
            while (counter < 7)
            {
                var events = await _context.Events
                    .Include(e => e.Activity)
                    .Where(e => e.StartDate.Day == date.Day && e.StartDate.Month == date.Month && e.StartDate.Year == date.Year && e.IsActive)
                    .OrderBy(e => e.StartDate.TimeOfDay)
                    .ToListAsync();
                dates.Add(date, events);
                date = date.AddDays(1);
                counter++;
            }
            return Ok(dates);
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return _context.Events;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}