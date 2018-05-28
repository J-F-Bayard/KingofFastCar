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
    public class ModelService : IModelService
    {
        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Model Create(Model entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddModele", true);
            cmd.AddParameter("idBrand", entity.IdBrand);
            cmd.AddParameter("Name", entity.Name);
            entity.IdModel = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteModele", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Model> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetModele", true);
            return c.ExecuteReader(cmd, (t) => new Model()
            {
                IdModel = (int)t["IdModel"],
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]
            }).ToList();
        }
        public Model Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetModeleById", true);
            cmd.AddParameter("IdModel", key);
            return c.ExecuteReader(cmd, (t) => new Model()
            {
                IdModel = (int)t["IdModel"],
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]
            }).FirstOrDefault();
        }
        public Model GetByModelName(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetModeleByModelName", true);
            cmd.AddParameter("@ModelName", name);
            return c.ExecuteReader(cmd, (t) => new Model()
            {
                IdModel = (int)t["IdModel"],
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]
            }).FirstOrDefault();
        }
        public Model GetByBrandName(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetModeleByBrandName", true);
            cmd.AddParameter("@BrandName", name);
            return c.ExecuteReader(cmd, (t) => new Model()
            {
                IdModel = (int)t["IdModel"],
                IdBrand = (int)t["IdBrand"],
                Name = (string)t["Name"]
            }).FirstOrDefault();
        }
        public bool Update(Model entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateModel", true);
            cmd.AddParameter("IdModel", entity.IdModel);
            cmd.AddParameter("IdBrand", entity.IdBrand);
            cmd.AddParameter("Name", entity.Name);
            return 1 == c.ExecuteNonQuery(cmd);
        }
    }
}