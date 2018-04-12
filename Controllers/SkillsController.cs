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
    public class SkillsController : Controller
    {
        private readonly OrganizationContext db;

        public SkillsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Skills);
        }

        [HttpGet("{id}", Name="GetSkill")]
        public IActionResult GetById(int id)
        {
            var skill = db.Skills.Find(id);

            if(skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Skill skill)
        {
            if(skill == null)
            {
                return BadRequest();
            }

            this.db.Skills.Add(skill);
            this.db.SaveChanges();

            return CreatedAtRoute("GetSkill", new { id = skill.SkillId}, skill);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Skill newSkill)
        {
            if(newSkill == null || newSkill.SkillId != id)
            {
                return BadRequest();
            }
            var currentSkill = this.db.Skills.FirstOrDefault(x => x.SkillId == id);

            if(currentSkill == null)
            {
                return NotFound();
            }

            currentSkill.SkillId = newSkill.SkillId;
            // other changes here

            this.db.Skills.Update(currentSkill);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var skill = this.db.Skills.FirstOrDefault(x => x.SkillId == id);

            if(skill == null)
            {
                return NotFound();
            }

            this.db.Skills.Remove(skill);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
