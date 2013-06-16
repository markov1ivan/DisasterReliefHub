using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Libraries;

namespace DisasterReliefHub.Models
{
    public class DwollaDonation
    {
        public Agency Agency { get; set; }

        public Disaster Disaster { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [Display(Name = "Bank Account")]
        public string BankAccount { get; set; }
        [Required]
        [RegularExpression(@"\d{9}", ErrorMessage = "Routing number need to be exactly 9 digits")]
        [Display(Name = "Routing Number")]
        public string RoutingNumber { get; set; }
        [Required]
        [Display(Name = "Account Type")]
        public DwollaAccountType AccountType { get; set; }

        public string ResultMessage { get; set; }
        public string Transaction { get; set; }

        [Display(Name = "Message")]
        public string Notes { get; set; }

        public bool IsAnonymously { get; set; }
    }
}