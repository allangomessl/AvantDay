using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}