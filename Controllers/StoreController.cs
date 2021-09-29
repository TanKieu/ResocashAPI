using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResocashAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ResocashContext _context;
        public StoreController(ResocashContext context)
        {
            _context = context;
        }

        // GET: api/<StoreController>
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Store>> GetAllStore()
        {
            return Ok(_context.Stores.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByID/{id}")]
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
        [HttpGet("getByPhone/{storePhone}")]
        public IEnumerable<Store> GetByStorePhone(String storePhone)
        {
            List<Store> list = new List<Store>();
            var stores = _context.Stores.ToList();
            foreach (var store in stores)
            {
                if (store.StorePhone == storePhone)
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

        [HttpGet("getByStatus/{storeStatus}")]
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

        [HttpGet("getByBrandID/{brandid}")]
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

        // POST api/<StoreController>
        [HttpPost("create")]
        public void Post([FromBody] Models.Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException();
            }
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        // PUT api/<StoreController>/5
        [HttpPut("update/")]
        public void Put([FromBody] Models.Store store)
        {
            if (store == null)
            {
                throw new ArgumentNullException();
            }
            _context.Stores.Update(store);
            _context.SaveChanges();
        }

        // DELETE api/<StoreController>/5
        [HttpPut("/deleteByID/{id}")]
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
