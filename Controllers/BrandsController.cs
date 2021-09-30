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
    public class BrandsController : ControllerBase
    {
        
        private readonly ResocashContext _context;
        public BrandsController(ResocashContext context)
        {
            _context = context;
        }
        // GET: Brands/<BrandsController>
        [HttpGet("")]
        public ActionResult<IEnumerable<Brand>> GetAllCasher()
        {
            return Ok(_context.Brands.ToList());
        }

        // GET Brands/<BrandsController>/5
        [HttpGet("id/{id}")]
        public Brand GetById(String id)
        {
            var brands = _context.Brands.ToList();
            var brand = brands.FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return null;
            }
            //if(brand.BrandStatus = false)
            //{
            //    return null;
            //}
            return brand;
        }

        // PUT areas/<AreaController>/5
        [HttpPut("")]
        public void Put([FromBody] Models.Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException();
            }
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }
    }
}
