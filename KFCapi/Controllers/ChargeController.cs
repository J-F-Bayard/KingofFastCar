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
    public class ChargeController : ApiController
    {
        // GET: api/Charge
        [HttpGet]
        public IEnumerable<Charge> Get()
        {
            return ServicesLocator.Instance.ChargeService.Get();
        }

        // GET: api/Charge/5
        [HttpGet]
        public Charge Get(int id)
        {
            return ServicesLocator.Instance.ChargeService.Get(id);
        }

        // Create: api/Charge
        [HttpPost]
        public void Create([FromBody]Charge value)
        {
            ServicesLocator.Instance.ChargeService.Create(value);
        }

        // EDIT: api/Charge
        [HttpPut]
        public void Update([FromBody]Charge value)
        {
            ServicesLocator.Instance.ChargeService.Update(value);
        }

        // DELETE: api/Charge/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.ChargeService.Delete(id);
        }
    }
}