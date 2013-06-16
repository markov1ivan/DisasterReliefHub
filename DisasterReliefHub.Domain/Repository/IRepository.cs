using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<T> Get<T>() where T : class, IEntity;
        T Get<T>(int id) where T : class, IEntity;
        IQueryable<T> Query<T>() where T : class, IEntity;

        T Save<T>(T entity) where T : class, IEntity;
    }
}
