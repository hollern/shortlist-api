using System;

namespace Shortlist.Api.Models
{
    public class ApplicationAnswer
    {
        public int ApplicationAnswerId{ get; set; }
        public string ApplicationAnswerText{ get; set; }
        public Applicant RelatedApplicant{ get; set; }
        public Opening RelatedOpening{ get; set; }
    }
}