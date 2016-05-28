using System;
using System.Collections.Generic;
using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class Order : Entity
    {
        public decimal Total { get; set; }
        public DateTime Data { get; set; }
        public Customer Customer { get; set; }
        public IList<ProductOrder> Products { get; set; }
    }
}
