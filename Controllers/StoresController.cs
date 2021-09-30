using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResocashAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ResocashContext _context;
        public StoresController(ResocashContext context)
        {
            _context = context;
        }

        // GET: stores/<StoreController>
        [HttpGet("")]
        public ActionResult<IEnumerable<Store>> GetAllStore()
        {
            return Ok(_context.Stores.ToList());
        }

        // GET stores/<StoreController>/5
        [HttpGet("{id}")]
        public Store GetById(String id)
        {
            var stores = _context.Stores.ToList();
            var store = stores.FirstOrDefault(x => x.Id == id);
            if (store == null)
            {
                return null;
            }
            if(store.StoreStatus == false)
            {
                return null;
            }
            return store;
        }
        [HttpGet("phone/{storePhone}")]
        public IEnumerable<Store> GetByStorePhone(String storePhone)
        {
            List<Store> list = new List<Store>();
            var stores = _context.Stores.ToList();
            foreach (var store in stores)
            {
                if (store.StorePhone.Contains(storePhone))
                {
                    list.Add(store);
                }
            }
            if (list == null)
            {
                return null;
            }
            return list;
        }

        [HttpGet("status/{storeStatus}")]
        public IEnumerable<Store> GetByStoreStatus(String storeStatus)
        {
            bool Status = System.Convert.ToBoolean(storeStatus);
            List<Store> list = new List<Store>();
            var stores = _context.Stores.ToList();
            foreach (var store in stores)
            {
                if (store.StoreStatus == Status)
                {
                    list.Add(store);
                }
            }
            if (list == null)
            {
                return null;
            }
            return list;
        }

        [HttpGet("brandid/{brandid}")]
        public IEnumerable<Store> GetByBrand(String brandid)
        {
            List<Store> listByBrand = new List<Store>();
            var stores = _context.Stores.ToList();
            foreach (var store in stores)
            {
                if (store.BrandId == brandid)
                {
                    listByBrand.Add(store);
                }
            }
            if(listByBrand == null)
            {
                return null;
            }
            return listByBrand;
        }

        // POST stores/<StoreController>
        [HttpPost("")]
        public void Post([FromBody] Models.Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException();
            }
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        // PUT stores/<StoreController>/5
        [HttpPut("")]
        public void Put([FromBody] Models.Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException();
            }
            _context.Stores.Update(store);
            _context.SaveChanges();
        }

        // DELETE stores/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var stores = _context.Stores.ToList();
            foreach (var store in stores)
            {
                if(store.Id == id)
                {
                    store.StoreStatus = false;
                    _context.SaveChanges();
                }
            }
        }

    }
}
