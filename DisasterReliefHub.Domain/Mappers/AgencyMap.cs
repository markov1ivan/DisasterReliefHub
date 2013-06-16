using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using DisasterReliefHub.Domain.Models;

namespace DisasterReliefHub.Domain.Mappers
{
    public class AgencyMap : EntityTypeConfiguration<Agency>
    {
        public AgencyMap()
        {
            ToTable("Agency");
            HasKey(p => p.Id).Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Description);
            Property(p => p.Name);
            Property(p => p.FirstName);
            Property(p => p.LastName);
            Property(p => p.Email);
        }
    }
}

