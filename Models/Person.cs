using System;
using System.Collections.Generic;

namespace Shortlist.Api.Models
{
    public class Person
    {
        public int PersonId{ get; set; }
        public string Ssn{ get; set; }
        public string FName{ get; set; }
        public string LName{ get; set; }
        public string MidIn{ get; set; }
        public string Gender{ get; set; }
        public string PhoneNumber{ get; set; }
        public string Email{ get; set; }
        public string Address{ get; set; }
        public string AdditionalDetails{ get; set; }
        public string BDate{ get; set; }
        public Company RelatedCompany{ get; set; }
    }
}