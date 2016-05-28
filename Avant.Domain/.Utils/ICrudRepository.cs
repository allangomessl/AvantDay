using System.Collections.Generic;

namespace Avant.Domain.Utils
{
    public interface ICrudRepository<T> where T : Entity
    {
        IList<T> Get();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
