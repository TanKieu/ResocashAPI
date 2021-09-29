using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CasherController : ControllerBase
    {
        private readonly ResocashContext _context;
        public CasherController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Casher>> GetAllCasher()
        {
            return Ok(_context.Cashers.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByID/{id}")]
        public Casher GetById(String id)
        {
            var cashers = _context.Cashers.ToList();
            var casher = cashers.FirstOrDefault(x => x.Id == id);
            if (casher == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return casher;
        }
    }
}
