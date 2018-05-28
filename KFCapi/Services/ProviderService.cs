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
    public class ProviderService : IProviderService
    {

        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Provider Create(Provider entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddFournisseur", true);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Account", entity.Account);
            cmd.AddParameter("Tva", entity.Tva);
            cmd.AddParameter("Street", entity.Street);
            cmd.AddParameter("Number", entity.Number);
            cmd.AddParameter("Zip", entity.Zip);
            cmd.AddParameter("Locality", entity.Locality);
            cmd.AddParameter("Country", entity.Country);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Phone", entity.Phone);

            entity.IdProvider = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteFournisseur", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Provider> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetFournisseur", true);
            return c.ExecuteReader(cmd, (t) => new Provider()
            {
                IdProvider = (int)t["IdProvider"],
                Name = (string)t["Name"],
                Account = (string)t["Account"],
                Tva = (string)t["Tva"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"]
        }).ToList();
                       
        }
        public Provider Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetFournisseurById", true);
            cmd.AddParameter("IdProvider", key);
            return c.ExecuteReader(cmd, (t) => new Provider()
            {
                IdProvider = (int)t["IdProvider"],
                Name = (string)t["Name"],
                Account = (string)t["Account"],
                Tva = (string)t["Tva"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"]
            }).FirstOrDefault();
        }
        public Provider Get(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetFournisseurByName", true);
            cmd.AddParameter("NameProvider", name);
            return c.ExecuteReader(cmd, (t) => new Provider()
            {
                IdProvider = (int)t["IdProvider"],
                Name = (string)t["Name"],
                Account = (string)t["Account"],
                Tva = (string)t["Tva"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"]
            }).FirstOrDefault();
        }
        public bool Update(Provider entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateFournisseur", true);
            cmd.AddParameter("IdProvider", entity.IdProvider);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Account", entity.Account);
            cmd.AddParameter("Tva", entity.Tva);
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