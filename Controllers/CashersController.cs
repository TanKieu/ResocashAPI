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
    public class CashersController : ControllerBase
    {
        private readonly ResocashContext _context;
        public CashersController(ResocashContext context)
        {
            _context = context;
        }
        // GET: Cashers/<CashersController>
        [HttpGet("")]
        public ActionResult<IEnumerable<Casher>> GetAllCasher()
        {
            return Ok(_context.Cashers.ToList());
        }

        // GET Cashers/<CashersController>/5
        [HttpGet("id/{id}")]
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

        [HttpGet("phone/{phone}")]
        public IEnumerable<Casher> GetByPhone(String phone)
        {
            var cashers = _context.Cashers.ToList();
            List<Casher> list = new List<Casher>();
            foreach (var casher in cashers)
            {
                //if (casher.CasherName.Contains(phone))
                //{
                //    list.Add(casher);
                //}
            }
            if (list == null)
            {
                return null;
            }
            return list;
        }


        [HttpGet("name/{name}")]
        public IEnumerable<Casher> GetByName(String name)
        {
            var cashers = _context.Cashers.ToList();
            List<Casher> list = new List<Casher>();
            foreach (var casher in cashers)
            {
                if (casher.CasherName.Contains(name))
                {
                    list.Add(casher);
                }
            }
            if (list == null)
            {
                return null;
            }
            return list;
        }

        [HttpGet("IdentityNumber/{name}")]
        public IEnumerable<Casher> GetByIdentityNumber(String number)
        {
            var cashers = _context.Cashers.ToList();
            List<Casher> list = new List<Casher>();
            foreach (var casher in cashers)
            {
                if (casher.IdentityNumber.Contains(number))
                {
                    list.Add(casher);
                }
            }
            if (list == null)
            {
                return null;
            }
            return list;
        }



        // POST Cashers/<CasherController>/5
        [HttpPost("")]
        public void Post([FromBody] Models.Casher casher)
        {
            if (casher == null)
            {
                throw new ArgumentNullException();
            }
            _context.Cashers.Add(casher);
            _context.SaveChanges();
        }

        // DELETE Cashers/<CasherController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var cashers = _context.Cashers.ToList();
            //foreach (var area in areas)
            //{
            //    if (area.Id == id)
            //    {
            //        area.StoreStatus = false;
            //        _context.SaveChanges();
            //    }
            //}
        }


        // PUT Cashsers/<CasherController>/5
        [HttpPut("")]
        public void Put([FromBody] Models.Casher casher)
        {
            if (casher == null)
            {
                throw new ArgumentNullException();
            }
            _context.Cashers.Update(casher);
            _context.SaveChanges();
        }


    }
}
