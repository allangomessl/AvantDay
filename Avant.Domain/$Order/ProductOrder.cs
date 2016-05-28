using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class ProductOrder : Entity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}