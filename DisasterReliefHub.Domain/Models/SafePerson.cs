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
        public string Location { get; set; }

        public MissingPerson MissingPerson { get; set; }
    }
}
