using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Models
{
    public class MissingPerson : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Location { get; set; }
        public bool IsFound { get; set; }

        public User Relative { get; set; }

     
    }
}
