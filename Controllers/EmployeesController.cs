using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shortlist.Api.Models;
using Shortlist.Api.Data;

namespace Shortlist.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly OrganizationContext db;

        public EmployeesController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Employees);
        }

        [HttpGet("{id}", Name="GetEmployee")]
        public IActionResult GetById(int id)
        {
            var employee = db.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if(employee == null)
            {
                return BadRequest();
            }

            this.db.Employees.Add(employee);
            this.db.SaveChanges();

            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId}, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee newEmployee)
        {
            if(newEmployee == null || newEmployee.EmployeeId != id)
            {
                return BadRequest();
            }
            var currentEmployee = this.db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if(currentEmployee == null)
            {
                return NotFound();
            }

            currentEmployee.EmployeeId = newEmployee.EmployeeId;
            // other changes here

            this.db.Employees.Update(currentEmployee);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = this.db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if(employee == null)
            {
                return NotFound();
            }

            this.db.Employees.Remove(employee);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
