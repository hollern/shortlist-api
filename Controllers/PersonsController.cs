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
    public class PersonsController : Controller
    {
        private readonly OrganizationContext db;

        public PersonsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Persons);
        }

        [HttpGet("{id}", Name="GetPerson")]
        public IActionResult GetById(int id)
        {
            var person = db.Persons.Find(id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }

            this.db.Persons.Add(person);
            this.db.SaveChanges();

            return CreatedAtRoute("GetPerson", new { id = person.PersonId}, person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person newPerson)
        {
            if(newPerson == null || newPerson.PersonId != id)
            {
                return BadRequest();
            }
            var currentPerson = this.db.Persons.FirstOrDefault(x => x.PersonId == id);

            if(currentPerson == null)
            {
                return NotFound();
            }

            currentPerson.PersonId = newPerson.PersonId;
            // other changes here

            this.db.Persons.Update(currentPerson);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = this.db.Persons.FirstOrDefault(x => x.PersonId == id);

            if(person == null)
            {
                return NotFound();
            }

            this.db.Persons.Remove(person);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
