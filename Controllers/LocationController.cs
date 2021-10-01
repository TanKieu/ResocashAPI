using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ResocashContext _context;
        public LocationController(ResocashContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public ActionResult<IEnumerable<Location>> GetList()
        {
            return Ok(_context.Bookings.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(String id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return location;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<Location>> Post(Location element)
        {
            _context.Locations.Add(element);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetList), new { id = element.Id }, element);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Location element)
        {
            if (!id.Equals(element.Id))
            {
                return BadRequest();
            }
            _context.Entry(element).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementExist(id))
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

        private bool ElementExist(string id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}
