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
    public class ChargeService : IChargeService
    {
        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Charge Create(Charge entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddFrais", true);
            cmd.AddParameter("IdDossier", entity.IdHistory);
            cmd.AddParameter("IdProvider", entity.IdProvider);
            cmd.AddParameter("Entitled", entity.Entitled);
            cmd.AddParameter("Amount", entity.Amount);
            cmd.AddParameter("BillNumber", entity.BillNumber);
            cmd.AddParameter("DeliveryDate", entity.DeliveryDate);
            entity.IdCharge = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteFrais", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Charge> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetFrais", true);
            return c.ExecuteReader(cmd, (t) => new Charge()
            {
                IdCharge = (int)t["IdFrais"],
                IdHistory = (int)t["IdDossier"],
                IdProvider = (int)t["idFournisseur"],
                Entitled = (string)t["Entitled"],
                Amount = (double)t["Amount"],
                BillNumber = (string)t["BillNumber"],
                DeliveryDate = (DateTime)t["DeliveryDate"]
            }).ToList();
        }
        public Charge Get(int id)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetFraisById", true);
            cmd.AddParameter("IdCharge", id);
            return c.ExecuteReader(cmd, (t) => new Charge()
            {
                IdCharge = (int)t["IdCharge"],
                IdHistory = (int)t["IdHistory"],
                IdProvider = (int)t["IdProvider"],
                Entitled = (string)t["Entitled"],
                Amount = (double)t["Amount"],
                BillNumber = (string)t["BillNumber"],
                DeliveryDate = (DateTime)t["DeliveryDate"]
            }).FirstOrDefault();
        }
        public IEnumerable<Charge> GetByHistory(int id)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetFraisByHistory", true);
            cmd.AddParameter("IdHistory", id);
            return c.ExecuteReader(cmd, (t) => new Charge()
            {
                IdCharge = (int)t["IdFrais"],
                IdHistory = (int)t["IdDossier"],
                IdProvider = (int)t["idFournisseur"],
                Entitled = (string)t["Entitled"],
                Amount = (int)t["Amount"],
                BillNumber = (string)t["BillNumber"],
                DeliveryDate = (DateTime)t["DeliveryDate"]
            }).ToList();
        }
        public bool Update(Charge entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateFrais", true);

            cmd.AddParameter("IdCharge", entity.IdCharge);
            cmd.AddParameter("IdHistory", entity.IdHistory);
            cmd.AddParameter("IdProvider", entity.IdProvider);
            cmd.AddParameter("Entitled", entity.Entitled);
            cmd.AddParameter("Amount", entity.Amount);
            cmd.AddParameter("BillNumber", entity.BillNumber);
            cmd.AddParameter("DeliveryDate", entity.DeliveryDate);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        
    }
}