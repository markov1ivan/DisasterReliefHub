using System;
using System.Collections.Generic;
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
          return DataContext.Entities<T>().FirstOrDefault(entity => entity.Id == id);
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
        using (TransactionScope scope = new TransactionScope())
        {
            if (entity.Id <= 0)
            {
                entity = DataContext.Entities<T>().Add(entity);
            }
            DataContext.SaveChanges();
            scope.Complete();
        }
        return entity;
      }

      public void Dispose()
      {
          DataContext.Dispose();
          DataContext = null;
      }
    }
}
