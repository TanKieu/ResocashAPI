using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class BrandController : ControllerBase
    {
        private readonly ResocashContext _context;
        public BrandController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Brand>> GetAllCasher()
        {
            return Ok(_context.Brands.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByID/{id}")]
        public Brand GetById(String id)
        {
            var Brands = _context.Brands.ToList();
            var Brand = Brands.FirstOrDefault(x => x.Id == id);
            if (Brand == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return Brand;
        }
    }
}
