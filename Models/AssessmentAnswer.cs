using System;

namespace Shortlist.Api.Models
{
    public class AssessmentAnswer
    {
        public int AssessmentAnswerId{ get; set; }
        public string AssessmentAnswerText{ get; set; }
        public Applicant RelatedEmployee{ get; set; }
        public ApplicationQuestion RelatedAssessmentQuestion{ get; set; }
    }
}