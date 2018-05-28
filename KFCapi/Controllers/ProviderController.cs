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
    public class ProviderController : ApiController
    {
        // GET: api/Provider
        [HttpGet]
        public IEnumerable<Provider> Get()
        {
            return ServicesLocator.Instance.ProviderService.Get();
        }

        // GET: api/Provider/5
        [HttpGet]
        public Provider Get(int id)
        {
            return ServicesLocator.Instance.ProviderService.Get(id);
        }

        // Create: api/Provider
        [HttpPost]
        public void Create([FromBody]Provider value)
        {
            ServicesLocator.Instance.ProviderService.Create(value);
        }

        // EDIT: api/Provider
        [HttpPut]
        public void Update([FromBody]Provider value)
        {
            ServicesLocator.Instance.ProviderService.Update(value);
        }

        // DELETE: api/Provider/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.ProviderService.Delete(id);
        }
    }
}