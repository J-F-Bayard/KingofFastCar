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
    public class SellerService : ISellerService
    {

        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Seller Create(Seller entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddVendeur", true);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Tva", entity.Tva);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Phone", entity.Phone);
            cmd.AddParameter("Street", entity.Street);
            cmd.AddParameter("Number", entity.Number);
            cmd.AddParameter("Zip", entity.Zip);
            cmd.AddParameter("Locality", entity.Locality);
            cmd.AddParameter("Country", entity.Country);
            cmd.AddParameter("Account", entity.Account);

            entity.IdSeller = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteVendeur", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Seller> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetVendeur", true);
            return c.ExecuteReader(cmd, (t) => new Seller()
            {
                IdSeller = (int)t["IdSeller"],
                Name = (string)t["Name"],
                Account = (string)t["Account"],
                Tva = (int)t["Tva"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"]
            }).ToList();

        }
        public Seller Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetVendeurById", true);
            cmd.AddParameter("IdSeller", key);
            return c.ExecuteReader(cmd, (t) => new Seller()
            {
                IdSeller = (int)t["IdSeller"],
                Name = (string)t["Name"],
                Account = (string)t["Account"],
                Tva = (int)t["Tva"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"]
            }).FirstOrDefault();
        }
        public Seller Get(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetVendeurByName", true);
            cmd.AddParameter("NameSeller", name);
            return c.ExecuteReader(cmd, (t) => new Seller()
            {
                IdSeller = (int)t["IdSeller"],
                Name = (string)t["Name"],
                Account = (string)t["Account"],
                Tva = (int)t["Tva"],
                Street = (string)t["Street"],
                Number = (string)t["Number"],
                Zip = (int)t["Zip"],
                Locality = (string)t["Locality"],
                Country = (string)t["Country"],
                Email = (string)t["Email"],
                Phone = (string)t["Phone"]
            }).FirstOrDefault();
        }
        public bool Update(Seller entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateVendeur", true);
            cmd.AddParameter("IdSeller", entity.IdSeller);
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