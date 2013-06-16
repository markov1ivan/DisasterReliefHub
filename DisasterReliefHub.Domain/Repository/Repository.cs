using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DisasterReliefHub.Domain.Repository
{
    public class Repository: IRepository
    {
        public Repository(DataContext context)
        {
            DataContext = context;
        }

        public DataContext DataContext { get; internal set; }

        IEnumerable<T> IRepository.Get<T>()
        {
          return DataContext.Entities<T>().AsQueryable();
        }

        T IRepository.Get<T>(int id)
        {
            return DataContext.Entities<T>().Find(id);
        }

        IQueryable<T> IRepository.Query<T>()
        {
            return DataContext.Entities<T>().AsQueryable();
        }

        T IRepository.Save<T>(T entity) 
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity being saved is null");
            }
            var entities = DataContext.Entities<T>();
            if (entity.Id <= 0)
            {
                entity = entities.Add(entity);
            }
            else
            {
                var existing = entities.Find(entity.Id);
                existing = (T)entity.Clone();
                DataContext.ChangeTracker.DetectChanges();
            }

            DataContext.SaveChanges();

            return entity;
        }

        public void Dispose()
      {
          DataContext.Dispose();
          DataContext = null;
      }
    }
}
