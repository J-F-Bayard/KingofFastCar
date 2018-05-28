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
    public class UserController : ApiController
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return ServicesLocator.Instance.UserService.Get();
        }

        // GET: api/User/5
        [HttpGet]
        public User Get(int id)
        {
            return ServicesLocator.Instance.UserService.Get(id);
        }

        // Create: api/User
        [HttpPost]
        public void Create([FromBody]User value)
        {
            ServicesLocator.Instance.UserService.Create(value);
        }

        // EDIT: api/User
        [HttpPut]
        public void Update([FromBody]User value)
        {
            ServicesLocator.Instance.UserService.Update(value);
        }

        // DELETE: api/User/5
        [HttpDelete]
        public void Delete(int id)
        {
            ServicesLocator.Instance.UserService.Delete(id);
        }
    }
}