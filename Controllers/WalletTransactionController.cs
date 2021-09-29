using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class WalletTransactionController : ControllerBase
    {
        private readonly ResocashContext _context;
        public WalletTransactionController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllWalletTransaction")]
        public ActionResult<IEnumerable<WalletTransaction>> GetAllCasher()
        {
            return Ok(_context.WalletTransactions.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDWalletTransaction/{id}")]
        public WalletTransaction GetById(String id)
        {
            var WalletTransactions = _context.WalletTransactions.ToList();
            var WalletTransaction = WalletTransactions.FirstOrDefault(x => x.Id == id);
            if (WalletTransaction == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return WalletTransaction;
        }
    }
}
