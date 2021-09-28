using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResocashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ResocashContext _context;
        public StoreController(ResocashContext context)
        {
            _context = context;
        }

        // GET: api/<StoreController>
        [HttpGet]
        public ActionResult<IEnumerable<Store>> GetAllStore()
        {
            return Ok(_context.Stores.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
