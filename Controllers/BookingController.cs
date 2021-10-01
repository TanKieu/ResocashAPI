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
    public class BookingController : ControllerBase
    {
        private readonly ResocashContext _context;
        public BookingController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("")]
        public ActionResult<IEnumerable<Booking>> GetList()
        {
            return Ok(_context.Bookings.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetById(String id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            //var booking = await _context.Bookings.FindAsync(id);
            //if (booking == null)
            //{
            //    return NotFound();
            //}
            //_context.Bookings.Remove(booking);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<Booking>> Post(Booking area)
        {
            _context.Bookings.Add(area);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetList), new { id = area.Id }, area);
            //if (area == null)
            //{
            //    throw new ArgumentNullException();
            //}
            //_context.Areas.Add(area);
            //_context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Booking booking)
        {
            if (!id.Equals(booking.Id))
            {
                return BadRequest();
            }
            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //if (area == null)
            //{
            //    throw new ArgumentNullException();
            //}
            //_context.Areas.Update(area);
            //_context.SaveChanges();
        }

        private bool BookingExist(string id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }

    }
}
