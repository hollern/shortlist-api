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
    public class CompanysController : Controller
    {
        private readonly OrganizationContext db;

        public CompanysController(OrganizationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Companys);
        }

        [HttpGet("{id}", Name="GetCompany")]
        public IActionResult GetById(int id)
        {
            var company = db.Companys.Find(id);

            if(company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Company company)
        {
            if(company == null)
            {
                return BadRequest();
            }

            this.db.Companys.Add(company);
            this.db.SaveChanges();

            return CreatedAtRoute("GetCompany", new { id = company.CompanyId}, company);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Company newCompany)
        {
            if(newCompany == null || newCompany.CompanyId != id)
            {
                return BadRequest();
            }
            var currentCompany = this.db.Companys.FirstOrDefault(x => x.CompanyId == id);

            if(currentCompany == null)
            {
                return NotFound();
            }

            currentCompany.CompanyId = newCompany.CompanyId;
            // other changes here

            this.db.Companys.Update(currentCompany);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = this.db.Companys.FirstOrDefault(x => x.CompanyId == id);

            if(company == null)
            {
                return NotFound();
            }

            this.db.Companys.Remove(company);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
