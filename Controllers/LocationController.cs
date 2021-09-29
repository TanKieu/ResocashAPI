using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class LocationController : ControllerBase
    {
        private readonly ResocashContext _context;
        public LocationController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllLocation")]
        public ActionResult<IEnumerable<Location>> GetAllCasher()
        {
            return Ok(_context.Locations.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDLocation/{id}")]
        public Location GetById(String id)
        {
            var Locations = _context.Locations.ToList();
            var Location = Locations.FirstOrDefault(x => x.Id == id);
            if (Location == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return Location;
        }
    }
}
