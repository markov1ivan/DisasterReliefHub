using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using DisasterReliefHub.Domain.Models;

namespace DisasterReliefHub.Domain.Mappers
{
    public class MissingPersonMap : EntityTypeConfiguration<MissingPerson>
    {
        public MissingPersonMap()
        {
            ToTable("MissingPerson");
            HasKey(p => p.Id).Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Email);
            Property(p => p.FirstName);
            Property(p => p.LastName);
            Property(p => p.Location);
            Property(p => p.Picture);
            ToTable("User");
            HasRequired(e => e.Relative).WithRequiredPrincipal();
            HasOptional(e => e.SafePerson).WithOptionalPrincipal();
        }
    }
}
