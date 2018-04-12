using System;
using System.Collections.Generic;

namespace Shortlist.Api.Models
{
    public class Role
    {
        public int RoleId{ get; set; }
        public string RoleName{ get; set; }
        public List<Skill> ImportantSkills{ get; set; }
        public Department RelatedDepartment{ get; set; }
    }
}