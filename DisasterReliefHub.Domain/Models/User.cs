using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Models
{
    [Table("User")]
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool IsAdministrator { get; set; }

        public bool SendEmailNotification { get; set; }
        public bool SendPhoneNotification { get; set; }
    }
}
