using System;

namespace Shortlist.Api.Models
{
    public class AssessmentAnswer
    {
        public int AssessmentAnswerId{ get; set; }
        public string AssessmentAnswerText{ get; set; }
        public Employee RelatedEmployee{ get; set; }
        public AssessmentQuestion RelatedAssessmentQuestion{ get; set; }
    }
}