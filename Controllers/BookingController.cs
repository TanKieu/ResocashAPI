using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class BookingController : ControllerBase
    {
        private readonly ResocashContext _context;
        public BookingController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllBooking")]
        public ActionResult<IEnumerable<Booking>> GetAllCasher()
        {
            return Ok(_context.Bookings.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDBooking/{id}")]
        public Booking GetById(String id)
        {
            var Books = _context.Bookings.ToList();
            var Book = Books.FirstOrDefault(x => x.Id == id);
            if (Book == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return Book;
        }
    }
}
