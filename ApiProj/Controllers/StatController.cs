using ApiProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly DatabaseContext context = new();

        [HttpGet("events/count")]
        public IActionResult Elso()
        { 
            return Ok(context.Events.Count());
        }

        [HttpGet("events/min_date")]
        public IActionResult Masodik()
        {
            return Ok(context.Events.OrderBy(e=>e.EventDateTime).First());
        }

        [HttpGet("events/future_conferences")]
        public IActionResult Harmadik()
        {
            return Ok(context.Events.Where(e => e.EventDateTime>new DateTime(2025,1,1)&& e.Title.Contains("konferencia")).First());
        }

        [HttpGet("events/titles_sorted")]
        public IActionResult Negyedik()
        {
            return Ok(context.Events.OrderBy(e => e.EventDateTime).Select(e => new { e.Title,e.EventDateTime}));
        }

        [HttpGet("authors/event_count")]
        public IActionResult Otodik()
        {
            return Ok(context.Events.GroupBy(e => e.AuthorId).Select(g => new { Szerzo = g.Key, Count = g.Count() }));
        }

        [HttpPut("events/update_title")]
        public IActionResult Hatodik(string id, string title)
        {
            var e = context.Events.Where(e => e.Id == id).First();
            if (e is null)
            {
                return NotFound();
            }

            e.Title = title;
            context.Update(e);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("events/delete/{id}")]
        public IActionResult Hetedik(string id)
        {
            Event e = context.Events.Where(e => e.Id == id).First();
            if (e is null)
            {
                return NotFound();
            }
            context.Events.Remove(e);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("events_with_authors")]
        public IActionResult Kilencedik()
        {
            return Ok(context.Events.Select(e => new { e.Title, e.EventDateTime, e.RegistrationDeadline, e.Id, Author = context.Authors.First(a => a.Id == e.AuthorId).Name }));
        }
    }
}
