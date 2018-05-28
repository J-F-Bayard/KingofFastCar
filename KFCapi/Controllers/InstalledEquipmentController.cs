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
    public class InstalledEquipmentController : ApiController
    {
        // GET: api/InstalledEquipment
        [HttpGet]
        public IEnumerable<InstalledEquipment> Get()
        {
            return ServicesLocator.Instance.InstalledEquipmentService.Get();
        }

        // GET: api/InstalledEquipment/5
        [HttpGet]
        public InstalledEquipment Get(int id)
        {
            return ServicesLocator.Instance.InstalledEquipmentService.Get(id);
        }

        // Create: api/InstalledEquipment
        [HttpPost]
        public void Create([FromBody]InstalledEquipment value)
        {
            ServicesLocator.Instance.InstalledEquipmentService.Create(value);
        }

        // EDIT: api/InstalledEquipment
        [HttpPut]
        public void Update([FromBody]InstalledEquipment value)
        {
            ServicesLocator.Instance.InstalledEquipmentService.Update(value);
        }

        // DELETE: api/InstalledEquipment/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.InstalledEquipmentService.Delete(id);
        }
    }
}