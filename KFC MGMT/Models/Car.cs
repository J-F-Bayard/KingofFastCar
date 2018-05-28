namespace KFC_MGMT.Models
{
    using System;
    
    public partial class Car
    {
        public int IdCar { get; set; }
        public string ChassisNumber { get; set; }
       // public int IdBrand { get; set; }
       // public string ModelName { get; set; }
        public int IdModel { get; set; }
        public string Version { get; set; }
        public DateTime Year { get; set; }
        public string ChassisType { get; set; }
        public string Condition { get; set; }
        public int Mileage { get; set; }
        public int Power { get; set; }
        public int Cylinder { get; set; }
        public string Location { get; set; }
        public string Fuel { get; set; }
        public string Transmition { get; set; }
        public string Color { get; set; }
        public bool MetalPainting { get; set; }
        public bool ServiceBook { get; set; }
        public bool LeftHand { get; set; }
        //public bool Active { get; set; }
    }
}
