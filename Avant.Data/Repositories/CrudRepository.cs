using System.Collections.Generic;
using System.Linq;
using Avant.Domain.Utils;
using Microsoft.Data.Entity;

namespace Avant.Data.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : Entity
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _set;

        public CrudRepository(IDataContext dataContext)
        {
            _dataContext = (DataContext) dataContext;
            _set = _dataContext.Set<T>();
        }

        public IList<T> Get()
        {
            return _set.ToList();
        }

        public T Get(int id)
        {
            return _set.First(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            _set.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
            _dataContext.SaveChanges();
        }
    }
}
