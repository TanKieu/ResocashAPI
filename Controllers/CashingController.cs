using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class CashingController : ControllerBase
    {
        private readonly ResocashContext _context;
        public CashingController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllCashingRequest")]
        public ActionResult<IEnumerable<CashingRequest>> GetAllCasher()
        {
            return Ok(_context.CashingRequests.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDCashingRequest/{id}")]
        public CashingRequest GetById(String id)
        {
            var CashingRequests = _context.CashingRequests.ToList();
            var CashingRequest = CashingRequests.FirstOrDefault(x => x.Id == id);
            if (CashingRequest == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return CashingRequest;
        }
    }
}
