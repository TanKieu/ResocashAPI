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
    public class WalletsController : ControllerBase
    {
        private readonly ResocashContext _context;
        public WalletsController(ResocashContext context)
        {
            _context = context;
        }
        // GET: Wallets/<WalletsController>
        [HttpGet("")]
        public ActionResult<IEnumerable<Wallet>> GetAllCasher()
        {
            return Ok(_context.Wallets.ToList());
        }

        // GET Wallets/<WalletsController>/5
        [HttpGet("id/{id}")]
        public Wallet GetById(String id)
        {
            var Wallets = _context.Wallets.ToList();
            var Wallet = Wallets.FirstOrDefault(x => x.Id == id);
            if (Wallet == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return Wallet;
        }




    }
}
