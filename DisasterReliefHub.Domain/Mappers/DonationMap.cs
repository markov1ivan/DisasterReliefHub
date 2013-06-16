using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using DisasterReliefHub.Domain.Models;

namespace DisasterReliefHub.Domain.Mappers
{
    public class DonationMap:EntityTypeConfiguration<Donation>
    {
        public DonationMap()
        {
            ToTable("Donation");
            HasKey(p => p.Id).Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Email).IsOptional();
            Property(p => p.FirstName);
            Property(p => p.LastName);
            Property(p => p.IsAnonymously);
            Property(p => p.Notes);
            Property(p => p.RoutingNumber);
            Property(p => p.BankAccount);
            Property(p => p.Transaction);
            Property(p => p.AccountTypeValue);
            Property(p => p.Amount);
        }
    }
}
