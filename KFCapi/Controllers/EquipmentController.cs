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
    public class EquipmentController : ApiController
    {
        // GET: api/Equipment
        [HttpGet]
        public IEnumerable<Equipment> Get()
        {
            return ServicesLocator.Instance.EquipmentService.Get();
        }

        // GET: api/Equipment/5
        [HttpGet]
        public Equipment Get(int id)
        {
            return ServicesLocator.Instance.EquipmentService.Get(id);
        }

        // Create: api/Equipment
        [HttpPost]
        public void Create([FromBody]Equipment value)
        {
            ServicesLocator.Instance.EquipmentService.Create(value);
        }

        // EDIT: api/Equipment
        [HttpPut]
        public void Update([FromBody]Equipment value)
        {
            ServicesLocator.Instance.EquipmentService.Update(value);
        }

        // DELETE: api/Equipment/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.EquipmentService.Delete(id);
        }
    }
}