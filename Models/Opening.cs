using System;
using System.Collections.Generic;

namespace Shortlist.Api.Models
{
    public class Opening
    {
        public int OpeningId{ get; set; }
        public Role OpeningFor{ get; set; }
        public List<Applicant> Applicants{ get; set; }
        public string JobDescription{ get; set; }
        public List<string> Responsibilities{ get; set; }
        public List<Skill> JobSkills{ get; set; }
        public List<int> SkillLevel{ get; set; } // Each skill level relates to the Skill of the same index
        public Company RelatedCompany{ get; set; }
    }
}