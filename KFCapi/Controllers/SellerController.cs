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
    public class SellerController : ApiController
    {
        // GET: api/Seller
        [HttpGet]
        public IEnumerable<Seller> Get()
        {
            return ServicesLocator.Instance.SellerService.Get();
        }

        // GET: api/Seller/5
        [HttpGet]
        public Seller Get(int id)
        {
            return ServicesLocator.Instance.SellerService.Get(id);
        }

        // Create: api/Seller
        [HttpPost]
        public void Create([FromBody]Seller value)
        {
            ServicesLocator.Instance.SellerService.Create(value);
        }

        // EDIT: api/Seller
        [HttpPut]
        public void Update([FromBody]Seller value)
        {
            ServicesLocator.Instance.SellerService.Update(value);
        }

        // DELETE: api/Seller/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.SellerService.Delete(id);
        }
    }
}