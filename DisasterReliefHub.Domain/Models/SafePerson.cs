using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Models
{
    public class SafePerson : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Message { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public MissingPerson MissingPerson { get; set; }
    }
}
