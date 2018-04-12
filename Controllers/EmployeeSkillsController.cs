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
    public class EmployeeSkillsController : Controller
    {
        private readonly OrganizationContext db;

        public EmployeeSkillsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.EmployeeSkills);
        }

        [HttpGet("{id}", Name="GetEmployeeSkill")]
        public IActionResult GetById(int id)
        {
            var employeeSkill = db.EmployeeSkills.Find(id);

            if(employeeSkill == null)
            {
                return NotFound();
            }

            return Ok(employeeSkill);
        }

        [HttpPost]
        public IActionResult Post([FromBody]EmployeeSkill employeeSkill)
        {
            if(employeeSkill == null)
            {
                return BadRequest();
            }

            this.db.EmployeeSkills.Add(employeeSkill);
            this.db.SaveChanges();

            return CreatedAtRoute("GetEmployeeSkill", new { id = employeeSkill.EmployeeSkillId}, employeeSkill);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EmployeeSkill newEmployeeSkill)
        {
            if(newEmployeeSkill == null || newEmployeeSkill.EmployeeSkillId != id)
            {
                return BadRequest();
            }
            var currentEmployeeSkill = this.db.EmployeeSkills.FirstOrDefault(x => x.EmployeeSkillId == id);

            if(currentEmployeeSkill == null)
            {
                return NotFound();
            }

            currentEmployeeSkill.EmployeeSkillId = newEmployeeSkill.EmployeeSkillId;
            // other changes here

            this.db.EmployeeSkills.Update(currentEmployeeSkill);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employeeSkill = this.db.EmployeeSkills.FirstOrDefault(x => x.EmployeeSkillId == id);

            if(employeeSkill == null)
            {
                return NotFound();
            }

            this.db.EmployeeSkills.Remove(employeeSkill);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
