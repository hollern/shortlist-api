using System;
using System.Collections.Generic;

namespace Shortlist.Api.Models
{
    public class Applicant
    {
        public int ApplicantId{ get; set; }
        public Person RelatedPerson{ get; set; }
        public string DateApplied{ get; set; }
        public string AdditionalDetails{ get; set; }
        public List<string> Attachments{ get; set; }
        public string LinkedinLink{ get; set; }
        public string GithubLink{ get; set; }
        public string PortfolioLink{ get; set; }
        public string OtherLink{ get; set; }
    }
}