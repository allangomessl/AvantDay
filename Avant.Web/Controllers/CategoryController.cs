using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avant.Data;
using Avant.Data.Repositories;
using Avant.Domain;
using Avant.Domain.Utils;
using Microsoft.AspNet.Mvc;

namespace Avant.Web.Controllers
{
    public class CategoryController : CrudController<Category>
    {
        public CategoryController(CategoryService service) : base(service)
        {
        }
    }
}
