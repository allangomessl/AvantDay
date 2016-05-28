using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class CategoryService : CrudService<Category>
    {
        public CategoryService(ICrudRepository<Category> dataDepository) : base(dataDepository)
        {
        }
    }
}
