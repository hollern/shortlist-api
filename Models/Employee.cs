using System;
using System.Collections.Generic;

namespace Shortlist.Api.Models
{
    public class Employee
    {
        public int EmployeeId{ get; set; }
        public Person RelatedPerson{ get; set; }
        public Role EmployeeRole{ get; set; }
        public string DateJoined{ get; set; }
        public string DateLeft{ get; set; }
    }
}