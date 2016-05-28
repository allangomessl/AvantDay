using System;
using System.Linq;
using Avant.Domain.Utils;

namespace Avant.Domain
{
    public class OrderService : CrudService<Order>
    {
        private readonly ProductService _productService;

        public OrderService(ICrudRepository<Order> dataDepository, ProductService productService) : base(dataDepository)
        {
            _productService = productService;
        }

        public override void Validate(Order entity, ActionState state)
        {
            base.Validate(entity, state);
            if (state == ActionState.Insert)
                entity.Data = DateTime.Now;
            entity.Total = 0;
            foreach (var productOrder in entity.Products)
            {
                var product = _productService.Get(productOrder.ProductId);
                product.Stock = product.Stock - productOrder.Quantity;
                if (product.Stock < 0)
                    throw new Exception("Falta no Estoque");
                _productService.Update(product);
                entity.Total = entity.Total + product.Price * productOrder.Quantity;
            }
        }
    }
}
