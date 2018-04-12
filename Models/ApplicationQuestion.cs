using System;

namespace Shortlist.Api.Models
{
    public class ApplicationQuestion
    {
        public int ApplicationQuestionId{ get; set; }
        public string ApplicationQuestionName{ get; set; }
        public Opening RelatedOpening{ get; set; } // This relates to the Job Opening/Application
    }
}