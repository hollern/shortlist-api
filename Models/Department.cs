using System;

namespace Shortlist.Api.Models
{
    public class Department
    {
        public int DepartmentId{ get; set; }
        public string DepartmentName{ get; set; }
        public Employee DepartmentManager{ get; set; }
        public Department ParentDepartment{ get; set; }
        public Company RelatedCompany{ get; set; }
    }
}