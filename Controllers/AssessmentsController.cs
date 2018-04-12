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
    public class AssessmentsController : Controller
    {
        private readonly OrganizationContext db;

        public AssessmentsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Assessments);
        }

        [HttpGet("{id}", Name="GetAssessment")]
        public IActionResult GetById(int id)
        {
            var assessment = db.Assessments.Find(id);

            if(assessment == null)
            {
                return NotFound();
            }

            return Ok(assessment);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Assessment assessment)
        {
            if(assessment == null)
            {
                return BadRequest();
            }

            this.db.Assessments.Add(assessment);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAssessment", new { id = assessment.AssessmentId}, assessment);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Assessment newAssessment)
        {
            if(newAssessment == null || newAssessment.AssessmentId != id)
            {
                return BadRequest();
            }
            var currentAssessment = this.db.Assessments.FirstOrDefault(x => x.AssessmentId == id);

            if(currentAssessment == null)
            {
                return NotFound();
            }

            currentAssessment.AssessmentId = newAssessment.AssessmentId;
            // other changes here

            this.db.Assessments.Update(currentAssessment);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assessment = this.db.Assessments.FirstOrDefault(x => x.AssessmentId == id);

            if(assessment == null)
            {
                return NotFound();
            }

            this.db.Assessments.Remove(assessment);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
