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
    public class DepartmentsController : Controller
    {
        private readonly OrganizationContext db;

        public DepartmentsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Departments);
        }

        [HttpGet("{id}", Name="GetDepartment")]
        public IActionResult GetById(int id)
        {
            var department = db.Departments.Find(id);

            if(department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Department department)
        {
            if(department == null)
            {
                return BadRequest();
            }

            this.db.Departments.Add(department);
            this.db.SaveChanges();

            return CreatedAtRoute("GetDepartment", new { id = department.DepartmentId}, department);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Department newDepartment)
        {
            if(newDepartment == null || newDepartment.DepartmentId != id)
            {
                return BadRequest();
            }
            var currentDepartment = this.db.Departments.FirstOrDefault(x => x.DepartmentId == id);

            if(currentDepartment == null)
            {
                return NotFound();
            }

            currentDepartment.DepartmentId = newDepartment.DepartmentId;
            // other changes here

            this.db.Departments.Update(currentDepartment);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = this.db.Departments.FirstOrDefault(x => x.DepartmentId == id);

            if(department == null)
            {
                return NotFound();
            }

            this.db.Departments.Remove(department);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
