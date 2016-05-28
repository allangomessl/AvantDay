using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avant.Domain;
using Avant.Domain.Utils;

namespace Avant.Web.Controllers
{
    public class ProductController : CrudController<Product>
    {
        public ProductController(ProductService service) : base(service)
        {
        }
    }
}
