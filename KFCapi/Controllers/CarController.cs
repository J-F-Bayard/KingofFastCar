using Newtonsoft.Json;
using KFCapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFCapi.Models;

namespace KFCapi.Controllers
{
    public class CarController : ApiController
    {
        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return ServicesLocator.Instance.CarService.Get();
        }

        // GET: api/Car/5
        [HttpGet]
        public Car Get(int id)
        {
            return ServicesLocator.Instance.CarService.Get(id);
        }

        // Create: api/Car
        [HttpPost]
        public void Create([FromBody]Car value)
        {
            ServicesLocator.Instance.CarService.Create(value);
        }

        // EDIT: api/Car
        [HttpPut]
        public void Update([FromBody]Car value)
        {
            ServicesLocator.Instance.CarService.Update(value);
        }

        // DELETE: api/Car/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.CarService.Delete(id);
        }
    }
}