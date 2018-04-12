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
    public class ApplicationQuestionsController : Controller
    {
        private readonly OrganizationContext db;

        public ApplicationQuestionsController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.ApplicationQuestions);
        }

        [HttpGet("{id}", Name="GetApplicationQuestion")]
        public IActionResult GetById(int id)
        {
            var applicationQuestion = db.ApplicationQuestions.Find(id);

            if(applicationQuestion == null)
            {
                return NotFound();
            }

            return Ok(applicationQuestion);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ApplicationQuestion applicationQuestion)
        {
            if(applicationQuestion == null)
            {
                return BadRequest();
            }

            this.db.ApplicationQuestions.Add(applicationQuestion);
            this.db.SaveChanges();

            return CreatedAtRoute("GetApplicationQuestion", new { id = applicationQuestion.ApplicationQuestionId}, applicationQuestion);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ApplicationQuestion newApplicationQuestion)
        {
            if(newApplicationQuestion == null || newApplicationQuestion.ApplicationQuestionId != id)
            {
                return BadRequest();
            }
            var currentApplicationQuestion = this.db.ApplicationQuestions.FirstOrDefault(x => x.ApplicationQuestionId == id);

            if(currentApplicationQuestion == null)
            {
                return NotFound();
            }

            currentApplicationQuestion.ApplicationQuestionId = newApplicationQuestion.ApplicationQuestionId;
            // other changes here

            this.db.ApplicationQuestions.Update(currentApplicationQuestion);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicationQuestion = this.db.ApplicationQuestions.FirstOrDefault(x => x.ApplicationQuestionId == id);

            if(applicationQuestion == null)
            {
                return NotFound();
            }

            this.db.ApplicationQuestions.Remove(applicationQuestion);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
