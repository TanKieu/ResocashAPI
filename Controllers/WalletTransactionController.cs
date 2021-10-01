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
    public class WalletTransactionController : ControllerBase
    {
        private readonly ResocashContext _context;
        public WalletTransactionController(ResocashContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public ActionResult<IEnumerable<WalletTransaction>> GetList()
        {
            return Ok(_context.WalletTransactions.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WalletTransaction>> GetById(String id)
        {
            var element = await _context.WalletTransactions.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            return element;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<WalletTransaction>> Post(WalletTransaction element)
        {
            _context.WalletTransactions.Add(element);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetList), new { id = element.Id }, element);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, WalletTransaction element)
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
            return _context.WalletTransactions.Any(e => e.Id == id);
        }
    }
}
