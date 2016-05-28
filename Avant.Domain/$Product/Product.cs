using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public bool Promotion { get; set; }
        public bool Featured { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Stock { get; set; }
    }
}
