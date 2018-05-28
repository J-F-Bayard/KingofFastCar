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
    public class HistoryController : ApiController
    {
        // GET: api/History
        [HttpGet]
        public IEnumerable<History> Get()
        {
            return ServicesLocator.Instance.HistoryService.Get();
        }

        // GET: api/History/5
        [HttpGet]
        public History Get(int id)
        {
            return ServicesLocator.Instance.HistoryService.Get(id);
        }

        // Create: api/History
        [HttpPost]
        public void Create([FromBody]History value)
        {
            ServicesLocator.Instance.HistoryService.Create(value);
        }

        // EDIT: api/History
        [HttpPut]
        public void Update([FromBody]History value)
        {
            ServicesLocator.Instance.HistoryService.Update(value);
        }

        // DELETE: api/History/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.HistoryService.Delete(id);
        }
    }
}