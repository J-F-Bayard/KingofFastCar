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
    public class HistoryService : IHistoryService
    {
        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public History Create(History entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddDossier", true);
            cmd.AddParameter("IdVoiture", entity.IdCar);
            cmd.AddParameter("IdVendeur", entity.IdSeller);
            cmd.AddParameter("IdAcheteur", entity.IdBuyer);
            cmd.AddParameter("PrixAchat", entity.BuyPrice);
            cmd.AddParameter("PrixVente", entity.SoldPrice);
            cmd.AddParameter("DateVente", entity.SoldDate);
            cmd.AddParameter("FactureVente", entity.SoldBill);
            cmd.AddParameter("FactureAchat", entity.BuyBill);
            cmd.AddParameter("DateAchat", entity.BuyDate);
            entity.IdHistory = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteDossier", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<History> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetDossier", true);
            return c.ExecuteReader(cmd, (t) => new History()
            {
                IdHistory = (int)t["IdHistory"],
                IdCar = (int)t["IdCar"],
                IdSeller = (int)t["IdSeller"],
                IdBuyer = (t["IdBuyer"] is DBNull) ? 0 : Convert.ToInt32(t["IdBuyer"]),
                BuyPrice = (int)t["BuyingPrice"],
                SoldPrice = (t["SellingPrice"] is DBNull) ? 0: Convert.ToInt32(t["SellingPrice"]),
                BuyBill = (t["BuyBill"] is DBNull) ? "" : Convert.ToString(t["BuyBill"]),
                SoldBill = (t["SoldBill"] is DBNull) ? "" : Convert.ToString(t["SoldBill"]),
                BuyDate = (DateTime)t["BuyDate"],
                SoldDate = (t["SoldDate"] is DBNull) ? Convert.ToDateTime(t["BuyDate"]) : Convert.ToDateTime(t["SoldDate"])

    }).ToList();
        }
        public History Get(int id)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetDossierById", true);
            cmd.AddParameter("IdHistory", id);
            return c.ExecuteReader(cmd, (t) => new History()
            {
                IdHistory = (int)t["IdHistory"],
                IdCar = (int)t["IdCar"],
                IdSeller = (int)t["IdSeller"],
                IdBuyer = (t["IdBuyer"] is DBNull) ? 0 : Convert.ToInt32(t["IdBuyer"]),
                BuyPrice = (int)t["BuyingPrice"],
                SoldPrice = (t["SellingPrice"] is DBNull) ? 0 : Convert.ToInt32(t["SellingPrice"]),
                BuyBill = (t["BuyBill"] is DBNull) ? "" : Convert.ToString(t["BuyBill"]),
                SoldBill = (t["SoldBill"] is DBNull) ? "" : Convert.ToString(t["SoldBill"]),
                BuyDate = (DateTime)t["BuyDate"],
                SoldDate = (t["SoldDate"] is DBNull) ? Convert.ToDateTime(t["BuyDate"]) : Convert.ToDateTime(t["SoldDate"])
            }).FirstOrDefault();
        }
        public History GetByCar(int id)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetDossierByCarId", true);
            cmd.AddParameter("IdCar", id);
            return c.ExecuteReader(cmd, (t) => new History()
            {
                IdHistory = (int)t["IdHistory"],
                IdCar = (int)t["IdCar"],
                IdSeller = (int)t["IdSeller"],
                IdBuyer = (t["IdBuyer"] is DBNull) ? 0 : Convert.ToInt32(t["IdBuyer"]),
                BuyPrice = (int)t["BuyingPrice"],
                SoldPrice = (t["sellingPrice"] is DBNull) ? 0 : Convert.ToInt32(t["sellingPrice"]),
                BuyDate = (DateTime)t["BuyDate"],
                SoldDate = (t["SoldDate"] is DBNull) ? Convert.ToDateTime(t["BuyDate"]) : Convert.ToDateTime(t["sellingPrice"]),
                BuyBill = (string)t["BuyBill"],
                SoldBill = (t["SoldBill"] is DBNull) ? "" : (string)t["BuyBill"]
            }).FirstOrDefault();
        }
        public bool Update(History entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateDossier", true);
            cmd.AddParameter("IdHistory", entity.IdHistory);
            cmd.AddParameter("IdCar", entity.IdCar);
            cmd.AddParameter("IdSeller", entity.IdSeller);
            cmd.AddParameter("IdBuyer", entity.IdBuyer);
            cmd.AddParameter("BuyPrice", entity.BuyPrice);
            cmd.AddParameter("SoldPrice", entity.SoldPrice);
            cmd.AddParameter("SoldBill", entity.SoldBill);
            cmd.AddParameter("SoldDate", entity.SoldDate);
            cmd.AddParameter("BuyDate", entity.BuyDate);
            cmd.AddParameter("BuyBill", entity.BuyBill);

            return 1 == c.ExecuteNonQuery(cmd);
        }
    }
}