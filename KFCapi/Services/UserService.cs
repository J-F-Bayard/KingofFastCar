using KFCapi.Models;
using KFCapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DbContact;

namespace KFCapi.Services
{
    public class UserService : IUserService
    {
        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public User Create(User entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddUser", true);
            cmd.AddParameter("LastName", entity.LastName);
            cmd.AddParameter("FirstName", entity.FirstName);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Password", entity.Password);
            
            entity.IdUser = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteUser", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<User> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetUser", true);
            return c.ExecuteReader(cmd, (t) => new User()
            {
                IdUser = (int)t["IdUser"],
                LastName = (string)t["LastName"],
                FirstName = (string)t["FirstName"],
                Email = (string)t["Email"]
            }).ToList();

        }
       
        public User GetByEmail(string email)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetUserByEmail", true);
            cmd.AddParameter("Email", email);
            return c.ExecuteReader(cmd, (t) => new User()
            {
                IdUser = (int)t["IdUser"],
                LastName = (string)t["LastName"],
                FirstName = (string)t["FirstName"],
                Email = (string)t["Email"]
            }).FirstOrDefault();
        }
        
        public bool Update(User entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateUser", true);
            cmd.AddParameter("IdUser", entity.IdUser);
            cmd.AddParameter("LastName", entity.LastName);
            cmd.AddParameter("FirstName", entity.FirstName);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Password", entity.Password);

            return 1 == c.ExecuteNonQuery(cmd);
        }
        public User Get(int id)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetUser", true);
            cmd.AddParameter("IdUser", id);
            return c.ExecuteReader(cmd, (t) => new User()
            {
                IdUser = (int)t["IdUser"],
                LastName = (string)t["LastName"],
                FirstName = (string)t["FirstName"],
                Email = (string)t["Email"]
            }).FirstOrDefault();
        }
    }
}