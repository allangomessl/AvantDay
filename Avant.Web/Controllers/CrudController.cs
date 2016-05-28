using Avant.Domain.Utils;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Avant.Web.Controllers
{
    [Route("api/[controller]")]
    public class CrudController<T> : Controller
        where T : Entity
    {
        private readonly CrudService<T> _service;

        public CrudController(CrudService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(_service.Get(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]object entity)
        {
            var ent = JsonConvert.DeserializeObject<T>(JObject.FromObject(entity).ToString());
            _service.Insert(ent);
            return Ok(ent);
        }
        [HttpPut]
        public IActionResult Put([FromBody]object entity)
        {
            var ent = JsonConvert.DeserializeObject<T>(JObject.FromObject(entity).ToString());
            _service.Update(ent);
            return Ok(ent);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ent = _service.Get(id);
            _service.Delete(ent);
            return new NoContentResult();
        }
    }
}
