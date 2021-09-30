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
    public class EmployeeController : ControllerBase
    {
        private readonly ResocashContext _context;
        public EmployeeController(ResocashContext context)
        {
            _context = context;
        }
        // GET: Employee/<EmployeeController>
        [HttpGet("getAllEmployee")]
        public ActionResult<IEnumerable<Employee>> GetAllCasher()
        {
            return Ok(_context.Employees.ToList());
        }

        // GET Employee/<EmployeeController>/5
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
