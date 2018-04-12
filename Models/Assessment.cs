using System;

namespace Shortlist.Api.Models
{
    public class Assessment
    {
        public int AssessmentId{ get; set; }
        public string AssessmentName{ get; set; }
        public Company RelatedCompany{ get; set; }
    }
}