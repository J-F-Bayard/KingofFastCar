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
    public class EquipmentService : IEquipmentService
    {

        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Equipment Create(Equipment entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddEquipement", true);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Description", entity.Description);
            entity.IdEquipement = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
            
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteEquipement", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Equipment> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetEquipement", true);
            return c.ExecuteReader(cmd, (t) => new Equipment()
            {
                IdEquipement = (int)t["IdEquipment"],
                Name = (string)t["Name"],
                Description = (string)t["Description"]
            }).ToList();
        }
        public Equipment Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetEquipementById", true);
            cmd.AddParameter("IdEquipment", key);
            return c.ExecuteReader(cmd, (t) => new Equipment()
            {
                IdEquipement = (int)t["IdEquipment"],
                Name = (string)t["Name"],
                Description = (string)t["Description"]
            }).FirstOrDefault();
        }
        public Equipment Get(string name)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetEquipementByName", true);
            cmd.AddParameter("NameEquipement", name);
            return c.ExecuteReader(cmd, (t) => new Equipment()
            {
                IdEquipement = (int)t["IdEquipment"],
                Name = (string)t["Name"],
                Description = (string)t["Description"]
            }).FirstOrDefault();
        }
        public bool Update(Equipment entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateEquipement", true);
            cmd.AddParameter("IdEquipment", entity.IdEquipement);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Description", entity.Description);
            return 1 == c.ExecuteNonQuery(cmd);
        }
    }
}