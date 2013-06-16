using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using DisasterReliefHub.Domain.Enumerations;

namespace DisasterReliefHub.Domain.Models
{
    public class Donation : Entity
    {

        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Amount { get; set; }
        public string BankAccount { get; set; }
        public string RoutingNumber { get; set; }

        public int AccountTypeValue { get; set; }

        public DwollaAccountType AccountType

        {
            get
            {
                return (DwollaAccountType)AccountTypeValue;
            }
            set
            {
                AccountTypeValue = (int)value;
            }
        }
        public string Transaction { get; set; }
        public string Notes { get; set; }
        public bool IsAnonymously { get; set; }
    }
}
