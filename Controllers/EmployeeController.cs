using Microsoft.AspNetCore.Mvc;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResocashAPI.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly ResocashContext _context;
        public EmployeeController(ResocashContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet("getAllEmployee")]
        public ActionResult<IEnumerable<Employee>> GetAllCasher()
        {
            return Ok(_context.Employees.ToList());
        }

        // GET api/<StoreController>/5
        [HttpGet("getByIDEmployee/{id}")]
        public Employee GetById(String id)
        {
            var Employees = _context.Employees.ToList();
            var Employee = Employees.FirstOrDefault(x => x.Id == id);
            if (Employee == null)
            {
                return null;
            }
            //if (casher.Status == false)
            //{
            //    return null;
            //}
            return Employee;
        }
    }
}
