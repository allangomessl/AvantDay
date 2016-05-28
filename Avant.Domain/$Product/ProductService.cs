using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class ProductService : CrudService<Product>
    {
        public ProductService(ICrudRepository<Product> dataDepository) : base(dataDepository)
        {
        }
    }
}
