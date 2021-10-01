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
    public class CashingController : ControllerBase
    {
        private readonly ResocashContext _context;
        public CashingController(ResocashContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public ActionResult<IEnumerable<Booking>> GetList()
        {
            return Ok(_context.Bookings.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CashingRequest>> GetById(String id)
        {
            var cashingRequest = await _context.CashingRequests.FindAsync(id);

            if (cashingRequest == null)
            {
                return NotFound();
            }

            return cashingRequest;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<CashingRequest>> Post(CashingRequest element)
        {
            _context.CashingRequests.Add(element);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetList), new { id = element.Id }, element);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CashingRequest element)
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
            return _context.CashingRequests.Any(e => e.Id == id);
        }
    }
}
