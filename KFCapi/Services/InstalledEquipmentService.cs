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
    public class InstalledEquipmentService : IInstalledEquipmentService
    {

        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public InstalledEquipment Create(InstalledEquipment entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddEquipementInstalles", true);
            cmd.AddParameter("IdVoiture", entity.IdCar);
            cmd.AddParameter("IdEquip", entity.IdEquipement);
            entity.IdInstalledEquipement = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
            
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteEquipementInstalles", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<InstalledEquipment> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetEquipementInstalles", true);
            return c.ExecuteReader(cmd, (t) => new InstalledEquipment()
            {
                IdInstalledEquipement = (int)t["IdInstalledEquipment"],
                IdEquipement = (int)t["IdEquipment"],
                IdCar = (int)t["IdCar"]
            }).ToList();
        }
        public InstalledEquipment Get(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetEquipementInstallesById", true);
            cmd.AddParameter("IdEquipmentInst", key);
            return c.ExecuteReader(cmd, (t) => new InstalledEquipment()
            {
                IdInstalledEquipement = (int)t["IdInstalledEquipment"],
                IdCar = (int)t["IdCar"],
                IdEquipement = (int)t["IdEquipment"]
            }).FirstOrDefault();
        }
        public IEnumerable<InstalledEquipment> GetByIdVoiture(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetEquipementInstallesByIdVoiture", true);
            cmd.AddParameter("IdCar", key);
            return c.ExecuteReader(cmd, (t) => new InstalledEquipment()
            {
                IdInstalledEquipement = (int)t["idInstalledEquipement"],
                IdEquipement = (int)t["IdEquipement"],
                IdCar = (int)t["IdCar"]
            }).ToList();
        }

        public bool Update(InstalledEquipment entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateInstalledEquipement", true);
            cmd.AddParameter("idEquipInst", entity.IdInstalledEquipement);
            cmd.AddParameter("IdCar", entity.IdCar);
            cmd.AddParameter("IdEquip", entity.IdEquipement);
            return 1 == c.ExecuteNonQuery(cmd);
            }
    }
}