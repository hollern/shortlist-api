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
    public class OpeningsController : Controller
    {
        private readonly OrganizationContext db;

        public OpeningsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Openings);
        }

        [HttpGet("{id}", Name="GetOpening")]
        public IActionResult GetById(int id)
        {
            var opening = db.Openings.Find(id);

            if(opening == null)
            {
                return NotFound();
            }

            return Ok(opening);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Opening opening)
        {
            if(opening == null)
            {
                return BadRequest();
            }

            this.db.Openings.Add(opening);
            this.db.SaveChanges();

            return CreatedAtRoute("GetOpening", new { id = opening.OpeningId}, opening);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Opening newOpening)
        {
            if(newOpening == null || newOpening.OpeningId != id)
            {
                return BadRequest();
            }
            var currentOpening = this.db.Openings.FirstOrDefault(x => x.OpeningId == id);

            if(currentOpening == null)
            {
                return NotFound();
            }

            currentOpening.OpeningId = newOpening.OpeningId;
            // other changes here

            this.db.Openings.Update(currentOpening);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var opening = this.db.Openings.FirstOrDefault(x => x.OpeningId == id);

            if(opening == null)
            {
                return NotFound();
            }

            this.db.Openings.Remove(opening);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
