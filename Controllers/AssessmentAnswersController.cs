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
    public class AssessmentAnswersController : Controller
    {
        private readonly OrganizationContext db;

        public AssessmentAnswersController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.AssessmentAnswers);
        }

        [HttpGet("{id}", Name="GetAssessmentAnswer")]
        public IActionResult GetById(int id)
        {
            var assessmentAnswer = db.AssessmentAnswers.Find(id);

            if(assessmentAnswer == null)
            {
                return NotFound();
            }

            return Ok(assessmentAnswer);
        }

        [HttpPost]
        public IActionResult Post([FromBody]AssessmentAnswer assessmentAnswer)
        {
            if(assessmentAnswer == null)
            {
                return BadRequest();
            }

            this.db.AssessmentAnswers.Add(assessmentAnswer);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAssessmentAnswer", new { id = assessmentAnswer.AssessmentAnswerId}, assessmentAnswer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AssessmentAnswer newAssessmentAnswer)
        {
            if(newAssessmentAnswer == null || newAssessmentAnswer.AssessmentAnswerId != id)
            {
                return BadRequest();
            }
            var currentAssessmentAnswer = this.db.AssessmentAnswers.FirstOrDefault(x => x.AssessmentAnswerId == id);

            if(currentAssessmentAnswer == null)
            {
                return NotFound();
            }

            currentAssessmentAnswer.AssessmentAnswerId = newAssessmentAnswer.AssessmentAnswerId;
            // other changes here

            this.db.AssessmentAnswers.Update(currentAssessmentAnswer);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assessmentAnswer = this.db.AssessmentAnswers.FirstOrDefault(x => x.AssessmentAnswerId == id);

            if(assessmentAnswer == null)
            {
                return NotFound();
            }

            this.db.AssessmentAnswers.Remove(assessmentAnswer);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
