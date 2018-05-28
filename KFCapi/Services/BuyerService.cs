using KFCapi.Models;
using KFCapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DbContact;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Services
{
    public class BuyerService : IBuyerService
    {

        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Buyer Create(Buyer entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddAcheteur", true);
            cmd.AddParameter("LastName", entity.LastName);
            cmd.AddParameter("FirstName", entity.FirstName);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Phone", entity.Phone);
            cmd.AddParameter("Street", entity.Street);
            cmd.AddParameter("Number", entity.Number);
            cmd.AddParameter("Zip", entity.Zip);
            cmd.AddParameter("Locality", entity.Locality);
            cmd.AddParameter("Country", entity.Country);
            cmd.AddParameter("Account", entity.Account);

            entity.IdBuyer = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteAcheteur", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Buyer> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetAcheteur", true);
            return c.ExecuteReader(cmd, (t) => new Buyer()
            {
                IdBuyer = (int)t["IdBuyer"],
                LastName = (string)t["LastName"],
                FirstName = (string)t["FirstName"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Account = (string)t["Account"]
            }).ToList();

        }
        public Buyer Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetAcheteurById", true);
            cmd.AddParameter("IdBuyer", key);
            return c.ExecuteReader(cmd, (t) => new Buyer()
            {
                IdBuyer = (int)t["IdBuyer"],
                LastName = (string)t["LastName"],
                FirstName = (string)t["FirstName"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Account = (string)t["Account"]
            }).FirstOrDefault();
        }
        public Buyer Get(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetAcheteurByName", true);
            cmd.AddParameter("LastName", name);
            return c.ExecuteReader(cmd, (t) => new Buyer()
            {
                IdBuyer = (int)t["IdBuyer"],
                LastName = (string)t["LastName"],
                FirstName = (string)t["FirstName"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Account = (string)t["Account"]
            }).FirstOrDefault();
        }
        public bool Update(Buyer entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateAcheteur", true);
            cmd.AddParameter("IdBuyer", entity.IdBuyer);
            cmd.AddParameter("LastName", entity.LastName);
            cmd.AddParameter("FirstName", entity.FirstName);
            cmd.AddParameter("Account", entity.Account);
            cmd.AddParameter("Street", entity.Street);
            cmd.AddParameter("Number", entity.Number);
            cmd.AddParameter("Zip", entity.Zip);
            cmd.AddParameter("Locality", entity.Locality);
            cmd.AddParameter("Country", entity.Country);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Phone", entity.Phone);

            return 1 == c.ExecuteNonQuery(cmd);
        }
    }
}