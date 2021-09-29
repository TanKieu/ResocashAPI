using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class WalletController : ControllerBase
    {
        private readonly ResocashContext _context;
        public WalletController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllWallet")]
        public ActionResult<IEnumerable<Wallet>> GetAllCasher()
        {
            return Ok(_context.Wallets.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDWallet/{id}")]
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
