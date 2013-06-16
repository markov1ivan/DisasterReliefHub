using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisasterReliefHub.Models
{
    public class AreTheSafeModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool SendEmailNotification { get; set; }

        public bool SendSmsNotification { get; set; }

        public String Phone { get; set; } 
    }
}
