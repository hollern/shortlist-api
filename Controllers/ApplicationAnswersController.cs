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
    public class ApplicationAnswersController : Controller
    {
        private readonly OrganizationContext db;

        public ApplicationAnswersController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.ApplicationAnswers);
        }

        [HttpGet("{id}", Name="GetApplicationAnswer")]
        public IActionResult GetById(int id)
        {
            var applicationAnswer = db.ApplicationAnswers.Find(id);

            if(applicationAnswer == null)
            {
                return NotFound();
            }

            return Ok(applicationAnswer);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ApplicationAnswer applicationAnswer)
        {
            if(applicationAnswer == null)
            {
                return BadRequest();
            }

            this.db.ApplicationAnswers.Add(applicationAnswer);
            this.db.SaveChanges();

            return CreatedAtRoute("GetApplicationAnswer", new { id = applicationAnswer.ApplicationAnswerId}, applicationAnswer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ApplicationAnswer newApplicationAnswer)
        {
            if(newApplicationAnswer == null || newApplicationAnswer.ApplicationAnswerId != id)
            {
                return BadRequest();
            }
            var currentApplicationAnswer = this.db.ApplicationAnswers.FirstOrDefault(x => x.ApplicationAnswerId == id);

            if(currentApplicationAnswer == null)
            {
                return NotFound();
            }

            currentApplicationAnswer.ApplicationAnswerId = newApplicationAnswer.ApplicationAnswerId;
            // other changes here

            this.db.ApplicationAnswers.Update(currentApplicationAnswer);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicationAnswer = this.db.ApplicationAnswers.FirstOrDefault(x => x.ApplicationAnswerId == id);

            if(applicationAnswer == null)
            {
                return NotFound();
            }

            this.db.ApplicationAnswers.Remove(applicationAnswer);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
