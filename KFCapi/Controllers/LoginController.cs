using KFCapi.Models;
using KFCapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFCapi.Controllers
{
    public class LoginController : ApiController
    {
        
        public Login Login([FromBody]Login value)
        {
            return ServicesLocator.Instance.LoginService.CheckLogin(value.Email,value.Password);
        }

        public bool CheckLogin(string email, string passwd)
        {
            if (ServicesLocator.Instance.LoginService.CheckLogin(email, passwd).Authentified)
                return true;
            else
                return false;
        }
        
    }
}
