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
    public class BrandService : IBrandService
    {

        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Brand Create(Brand entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddMarque", true);
            cmd.AddParameter("Name", entity.Name);
            //entity.IdBrand = (int)c.ExecuteScalar(cmd);
            entity.IdBrand = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
            
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteMarque", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Brand> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetMarque", true);
            return c.ExecuteReader(cmd, (t) => new Brand()
            {
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]                
            }).ToList();
        }
        public Brand Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetMarqueById", true);
            cmd.AddParameter("IdBrand", key);
            return c.ExecuteReader(cmd, (t) => new Brand()
            {
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]
            }).FirstOrDefault();
        }
       
        public Brand GetByName(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetMarqueByBrandName", true);
            cmd.AddParameter("BrandName", name);
            return c.ExecuteReader(cmd, (t) => new Brand()
            {
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]
            }).FirstOrDefault();
        }
        public bool Update(Brand entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateMarque", true);
            cmd.AddParameter("IdBrand", entity.IdBrand);
            cmd.AddParameter("Name", entity.Name);            
            return 1 == c.ExecuteNonQuery(cmd);
        }
    }
}