using System.Collections.Generic;

namespace Avant.Domain.Utils
{
    public enum ActionState
    {
        Insert,
        Update,
        Delete
    }

    public class CrudService<T> where T : Entity
    {
        private readonly ICrudRepository<T> _dataRepository;

        public CrudService(ICrudRepository<T> dataDepository)
        {
            _dataRepository = dataDepository;
        }

        public virtual IList<T> Get()
        {
            return _dataRepository.Get();
        }

        public virtual void Validate(T entity, ActionState state)
        {
        }

        public virtual T Get(int id)
        {
            return _dataRepository.Get(id);
        }

        public virtual void Insert(T entity)
        {
            Validate(entity, ActionState.Insert);
            _dataRepository.Insert(entity);
        }

        public void Update(T entity)
        {
            Validate(entity, ActionState.Update);
            _dataRepository.Update(entity);
        }

        public void Delete(T entity)
        {
            _dataRepository.Delete(entity);
        }
    }
}
