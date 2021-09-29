using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class PreferController : ControllerBase
    {
        private readonly ResocashContext _context;
        public PreferController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllPrefer")]
        public ActionResult<IEnumerable<Prefer>> GetAllCasher()
        {
            return Ok(_context.Prefers.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDPrefer/{id}")]
        public Prefer GetById(String id)
        {
            var Prefers = _context.Prefers.ToList();
            var Prefer = Prefers.FirstOrDefault(x => x.Id == id);
            if (Prefer == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return Prefer;
        }
    }
}
