using KFCapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

using ToolBox.DbContact;
using KFCapi.Models;

namespace KFCapi.Services
{
    public class LoginService : ILoginService
    {
        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }

        public Login CheckLogin(string email, string password)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.CheckLogin", true);
            cmd.AddParameter("Email", email);
            cmd.AddParameter("Passwd", password);
            return c.ExecuteReader(cmd, (t) => new Login()
            {
                Authentified = (bool)t["Authentified"]
            }).FirstOrDefault();
        }

        
        public IEnumerable<Models.Login> Get()
        {
            throw new NotImplementedException();
        }

        public Models.Login Get(int Key)
        {
            throw new NotImplementedException();
        }

        public Models.Login Create(Models.Login Entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.Login Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Key)
        {
            throw new NotImplementedException();
        }
    }
}