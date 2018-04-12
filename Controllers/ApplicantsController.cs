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
    public class ApplicantsController : Controller
    {
        private readonly OrganizationContext db;

        public ApplicantsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Applicants);
        }

        [HttpGet("{id}", Name="GetApplicant")]
        public IActionResult GetById(int id)
        {
            var applicant = db.Applicants.Find(id);

            if(applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Applicant applicant)
        {
            if(applicant == null)
            {
                return BadRequest();
            }

            this.db.Applicants.Add(applicant);
            this.db.SaveChanges();

            return CreatedAtRoute("GetApplicant", new { id = applicant.ApplicantId}, applicant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Applicant newApplicant)
        {
            if(newApplicant == null || newApplicant.ApplicantId != id)
            {
                return BadRequest();
            }
            var currentApplicant = this.db.Applicants.FirstOrDefault(x => x.ApplicantId == id);

            if(currentApplicant == null)
            {
                return NotFound();
            }

            currentApplicant.ApplicantId = newApplicant.ApplicantId;
            // other changes here

            this.db.Applicants.Update(currentApplicant);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicant = this.db.Applicants.FirstOrDefault(x => x.ApplicantId == id);

            if(applicant == null)
            {
                return NotFound();
            }

            this.db.Applicants.Remove(applicant);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
