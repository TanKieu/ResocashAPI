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
    public class AreasController : ControllerBase
    {

        private readonly ResocashContext _context;
        public AreasController(ResocashContext context)
        {
            _context = context;
        }
        // GET: areas/<AreaController>
        [HttpGet("")]
        public ActionResult<IEnumerable<Area>> GetAllCasher()
        {
            return Ok(_context.Areas.ToList());
        }

        // GET areas/<AreaController>/5
        [HttpGet("id/{id}")]
        public Area GetById(String id)
        {
            var areas = _context.Areas.ToList();
            var area = areas.FirstOrDefault(x => x.Id == id);
            if (area == null)
            {

                return null;
            }
            return area;
        }


        [HttpGet("Location/{Location}")]
        public IEnumerable<Area> GetByLocation(String AreaLocation)
        {
            List<Area> list = new List<Area>();
            var areas = _context.Areas.ToList();
            foreach (var area in areas)
            {
                if (area.AreaLocation.Contains(AreaLocation))
                {
                    list.Add(area);
                }
            }
            if (list == null)
            {
                return null;
            }
            return list;
        }


        // POST areas/<AreaController>/5
        [HttpPost("")]
        public void Post([FromBody] Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException();
            }
            _context.Areas.Add(area);
            _context.SaveChanges();
        }

        // DELETE areas/<AreaController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var areas = _context.Areas.ToList();
            //foreach (var area in areas)
            //{
            //    if (area.Id == id)
            //    {
            //        area.StoreStatus = false;
            //        _context.SaveChanges();
            //    }
            //}
        }

        // PUT areas/<AreaController>/5
        [HttpPut("")]
        public void Put([FromBody] Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException();
            }
            _context.Areas.Update(area);
            _context.SaveChanges();
        }


    }
}
