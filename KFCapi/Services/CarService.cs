using KFCapi.Models;
using KFCapi.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ToolBox.DbContact;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Services
{
    public class CarService: ICarService
    {
        private Connection GetConnection()
        {
            return ServicesLocator.GetConnection();
        }
        public Car Create(Car entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.AddVoiture", true);
            cmd.AddParameter("ChassisNumber", entity.ChassisNumber);
            cmd.AddParameter("IdModel", entity.IdModel);
            cmd.AddParameter("Version", entity.Version);
            cmd.AddParameter("Year", entity.Year);
            cmd.AddParameter("ChassisType", entity.ChassisType);
            cmd.AddParameter("Condition", entity.Condition);
            cmd.AddParameter("Mileage", entity.Mileage);
            cmd.AddParameter("Power", entity.Power);
            cmd.AddParameter("Cylinder", entity.Cylinder);
            cmd.AddParameter("Location", entity.Location);
            cmd.AddParameter("Fuel", entity.Fuel);
            cmd.AddParameter("Transmition", entity.Transmition);
            cmd.AddParameter("Color", entity.Color);
            cmd.AddParameter("MetalPainting", Convert.ToByte(entity.MetalPainting));
            cmd.AddParameter("ServiceBook", Convert.ToByte(entity.ServiceBook));
            cmd.AddParameter("LeftHand", Convert.ToByte(entity.LeftHand));
            entity.IdCar = int.Parse(c.ExecuteScalar(cmd).ToString());
            return entity;
        }

        public bool Delete(int key)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.DeleteVoiture", true);
            cmd.AddParameter("Id", key);
            return 1 == c.ExecuteNonQuery(cmd);
        }
        public IEnumerable<Car> Get()
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetVoiture", true);
            return c.ExecuteReader(cmd, (t) => new Car()
            {
                IdCar = (int)t["IdCar"],
                ChassisNumber = (string)t["ChassisNumber"],
                IdModel = (int)t["IdModel"],
                Version = (t["Version"] is DBNull) ? "Inconnue" : Convert.ToString(t["Version"]),
                Year = (DateTime)t["Year"],
                ChassisType = (string)t["ChassisType"],
                Condition = (string)t["Condition"],
                Mileage = (int)t["Mileage"],
                Power = (int)t["Power"],
                Cylinder = (int)t["Cylinder"],
                Location = (string)t["Location"],
                Fuel = (string)t["Fuel"],
                Transmition = (string)t["Transmition"],
                Color = (string)t["Color"],
                MetalPainting = (bool)t["MetalPainting"],
                ServiceBook = (bool)t["ServiceBook"],
                LeftHand = (bool)t["LeftHand"]
            }).ToList();
        }
        
        public Car Get(int id)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.GetVoitureById", true);
            cmd.AddParameter("IdCar", id);
            return c.ExecuteReader(cmd, (t) => new Car()
            {
                IdCar = (int)t["IdCar"],
                ChassisNumber = (string)t["ChassisNumber"],
                IdModel = (int)t["IdModel"],
                Version = (t["VersionCar"] is DBNull) ? "Inconnue" : Convert.ToString(t["VersionCar"]),
                Year = (DateTime)t["YearCar"],
                ChassisType = (string)t["ChassisType"],
                Condition = (string)t["Condition"],
                Mileage = (int)t["Mileage"],
                Power = (int)t["PowerCar"],
                Cylinder = (int)t["Cylinder"],
                Location = (string)t["LocationCar"],
                Fuel = (string)t["Fuel"],
                Transmition = (string)t["Transmition"],
                Color = (string)t["Color"],
                MetalPainting = (bool)t["MetalPainting"],
                ServiceBook = (bool)t["ServiceBook"],
                LeftHand = (bool)t["LeftHand"]
            }).FirstOrDefault();
        }
       public bool Update(Car entity)
        {
            Connection c = GetConnection();
            Command cmd = new Command("dbo.UpdateVoiture", true);
            cmd.AddParameter("IdCar", entity.IdCar);
            cmd.AddParameter("ChassisNumber", entity.ChassisNumber);
            cmd.AddParameter("IdModel", entity.IdModel);
            cmd.AddParameter("Version", entity.Version);
            cmd.AddParameter("Year", entity.Year );
            cmd.AddParameter("ChassisType", entity.ChassisType);
            cmd.AddParameter("Condition", entity.Condition);
            cmd.AddParameter("Mileage", entity.Mileage);
            cmd.AddParameter("Power", entity.Power);
            cmd.AddParameter("Cylinder", entity.Cylinder);
            cmd.AddParameter("Location", entity.Location);
            cmd.AddParameter("Fuel", entity.Fuel);
            cmd.AddParameter("Transmition", entity.Transmition);
            cmd.AddParameter("Color", entity.Color);
            cmd.AddParameter("MetalPainting",Convert.ToByte( entity.MetalPainting) );
            cmd.AddParameter("ServiceBook", Convert.ToByte(entity.ServiceBook) );
            cmd.AddParameter("LeftHand", Convert.ToByte(entity.LeftHand) );
            return 1 == c.ExecuteNonQuery(cmd);           
        }
    }
}