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
    public class BuyerController : ApiController
    {
        // GET: api/Buyer
        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            return ServicesLocator.Instance.BuyerService.Get();
        }

        // GET: api/Buyer/5
        [HttpGet]
        public Buyer Get(int id)
        {
            return ServicesLocator.Instance.BuyerService.Get(id);
        }


        // Create: api/Buyer
        [HttpPost]
        public void Create([FromBody]Buyer value)
        {
            ServicesLocator.Instance.BuyerService.Create(value);
        }

        // EDIT: api/Buyer
        [HttpPut]
        public void Update([FromBody]Buyer value)
        {
            ServicesLocator.Instance.BuyerService.Update(value);
        }

        // DELETE: api/Buyer/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.BuyerService.Delete(id);
        }
    }
}
