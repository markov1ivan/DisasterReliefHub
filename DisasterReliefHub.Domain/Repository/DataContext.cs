using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DisasterReliefHub.Domain.Repository
{
    public class DataContext: DbContext
    {
        public DataContext(string configuration)
            : base(configuration)
        {
            
        }

        public void InitializeDatabase()
        {
            this.Database.CreateIfNotExists();
        }

        public IDbSet<T> Entities<T>() where T : class, IEntity 
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetAssembly(typeof(DataContext)).GetTypes().ToList();
            typesToRegister = typesToRegister
        .Where(type => !String.IsNullOrEmpty(type.Namespace))
        .Where(type => type.BaseType != null && type.BaseType.IsGenericType && 
           type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)).ToList();;
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
