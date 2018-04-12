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
    public class AssessmentQuestionsController : Controller
    {
        private readonly OrganizationContext db;

        public AssessmentQuestionsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.AssessmentQuestions);
        }

        [HttpGet("{id}", Name="GetAssessmentQuestion")]
        public IActionResult GetById(int id)
        {
            var assessmentQuestion = db.AssessmentQuestions.Find(id);

            if(assessmentQuestion == null)
            {
                return NotFound();
            }

            return Ok(assessmentQuestion);
        }

        [HttpPost]
        public IActionResult Post([FromBody]AssessmentQuestion assessmentQuestion)
        {
            if(assessmentQuestion == null)
            {
                return BadRequest();
            }

            this.db.AssessmentQuestions.Add(assessmentQuestion);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAssessmentQuestion", new { id = assessmentQuestion.AssessmentQuestionId}, assessmentQuestion);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AssessmentQuestion newAssessmentQuestion)
        {
            if(newAssessmentQuestion == null || newAssessmentQuestion.AssessmentQuestionId != id)
            {
                return BadRequest();
            }
            var currentAssessmentQuestion = this.db.AssessmentQuestions.FirstOrDefault(x => x.AssessmentQuestionId == id);

            if(currentAssessmentQuestion == null)
            {
                return NotFound();
            }

            currentAssessmentQuestion.AssessmentQuestionId = newAssessmentQuestion.AssessmentQuestionId;
            // other changes here

            this.db.AssessmentQuestions.Update(currentAssessmentQuestion);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assessmentQuestion = this.db.AssessmentQuestions.FirstOrDefault(x => x.AssessmentQuestionId == id);

            if(assessmentQuestion == null)
            {
                return NotFound();
            }

            this.db.AssessmentQuestions.Remove(assessmentQuestion);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
