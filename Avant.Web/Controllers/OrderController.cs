using Avant.Domain;
using Avant.Domain.Utils;

namespace Avant.Web.Controllers
{
    public class OrderController : CrudController<Order>
    {
        public OrderController(OrderService service) : base(service)
        {
        }
    }
}
