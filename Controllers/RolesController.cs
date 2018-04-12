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
    public class RolesController : Controller
    {
        private readonly OrganizationContext db;

        public RolesController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Roles);
        }

        [HttpGet("{id}", Name="GetRole")]
        public IActionResult GetById(int id)
        {
            var role = db.Roles.Find(id);

            if(role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Role role)
        {
            if(role == null)
            {
                return BadRequest();
            }

            this.db.Roles.Add(role);
            this.db.SaveChanges();

            return CreatedAtRoute("GetRole", new { id = role.RoleId}, role);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Role newRole)
        {
            if(newRole == null || newRole.RoleId != id)
            {
                return BadRequest();
            }
            var currentRole = this.db.Roles.FirstOrDefault(x => x.RoleId == id);

            if(currentRole == null)
            {
                return NotFound();
            }

            currentRole.RoleId = newRole.RoleId;
            // other changes here

            this.db.Roles.Update(currentRole);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var role = this.db.Roles.FirstOrDefault(x => x.RoleId == id);

            if(role == null)
            {
                return NotFound();
            }

            this.db.Roles.Remove(role);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
