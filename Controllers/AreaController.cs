using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class AreaController : ControllerBase
    {
        private readonly ResocashContext _context;
        public AreaController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllArea")]
        public ActionResult<IEnumerable<Area>> GetAllCasher()
        {
            return Ok(_context.Areas.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDArea/{id}")]
        public Area GetById(String id)
        {
            var areas = _context.Areas.ToList();
            var area = areas.FirstOrDefault(x => x.Id == id);
            if (area == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return area;
        }
    }
}
