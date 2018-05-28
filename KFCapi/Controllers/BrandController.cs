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
    public class BrandController : ApiController
    {
        // GET: api/Brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return ServicesLocator.Instance.BrandService.Get();
        }

        // GET: api/Brand/5
        [HttpGet]
        public Brand Get(int id)
        {
            return ServicesLocator.Instance.BrandService.Get(id);
        }

        
        // Create: api/Brand
        [HttpPost]
        public void Create([FromBody]Brand value)
        {
            ServicesLocator.Instance.BrandService.Create(value);
        }

        // EDIT: api/Brand
        [HttpPut]
        public void Update([FromBody]Brand value)
        {
            ServicesLocator.Instance.BrandService.Update(value);
        }

        // DELETE: api/Brand/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.BrandService.Delete(id);
        }
    }
}
