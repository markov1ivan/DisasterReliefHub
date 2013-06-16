using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using DisasterReliefHub.Domain.Models;

namespace DisasterReliefHub.Domain.Mappers
{
    public class SafePersonMap : EntityTypeConfiguration<SafePerson>
    {
        public SafePersonMap()
        {
            ToTable("SafePerson");
            HasKey(p => p.Id).Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Email);
            Property(p => p.FirstName);
            Property(p => p.LastName);
            Property(p => p.Longitude);
            Property(p => p.Latitude);
            Property(p => p.Picture);
            HasOptional(e => e.MissingPerson).WithRequired().Map(x=>x.MapKey("MissingPersonFk"));
        }
    }
}
