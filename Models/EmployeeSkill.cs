using System;

namespace Shortlist.Api.Models
{
    public class EmployeeSkill
    {
        public int EmployeeSkillId{ get; set; }
        public int SkillLevel{ get; set; }
        public Skill RelatedSkill{ get; set; }
    }
}