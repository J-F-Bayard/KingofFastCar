using KFCapi.Models;
using KFCapi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFCapi.Controllers
{
    public class ModelController : ApiController
    {
        // GET: api/Model
        [HttpGet]
        public IEnumerable<Model> Get()
        {
            return ServicesLocator.Instance.ModelService.Get();
        }

        // GET: api/Model/5
        [HttpGet]
        public Model Get(int id)
        {
            return ServicesLocator.Instance.ModelService.Get(id);
        }

        // Create: api/Model
        [HttpPost]
        public void Create([FromBody]Model value)
        {
            ServicesLocator.Instance.ModelService.Create(value);
        }

        // EDIT: api/Model
        [HttpPut]
        public void Update([FromBody]Model value)
        {
            ServicesLocator.Instance.ModelService.Update(value);
        }

        // DELETE: api/Model/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.ModelService.Delete(id);
        }
    }
}