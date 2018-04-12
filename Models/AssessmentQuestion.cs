using System;
using System.Collections.Generic;

namespace Shortlist.Api.Models
{
    public class AssessmentQuestion
    {
        public int AssessmentQuestionId{ get; set; }
        public string QuestionTitle{ get; set; }
        public int QuestionNumber{ get; set; }
        public List<string> PossibleAnswers{ get; set; }
        public Assessment RelatedAssessment{ get; set; }
    }
}